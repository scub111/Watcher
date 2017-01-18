using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.DirectoryServices;
using System.Linq;
using System.Management;
using System.Windows.Forms;
using Watcher.ServiceReference1;

namespace Watcher
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Основные переменные.
        /// </summary>
        private VarXML varXml;

        /// <summary>
        /// Объект удаленной службы.
        /// </summary>
        DataServiceClient DataClient { get; set; }

        /// <summary>
        /// Поток проверки удаленной службы.
        /// </summary>
        ThreadTimer tmrCheckService { get; set; }

        /// <summary>
        /// Подключение к службе.
        /// </summary>
        bool IsConnected { get; set; }


        /// <summary>
        /// Версия сервиса.
        /// </summary>
        string ServiceVersion { get; set; }

        /// <summary>
        /// Время на сервере.
        /// </summary>
        DateTime ServerTime { get; set; }

        /// <summary>
        /// ID сайта.
        /// </summary>
        string SiteID { get; set; }

        /// <summary>
        /// Статус сервиса.
        /// </summary>
        string Status { get; set; }

        /// <summary>
        /// Количество попыток запустить сервер.
        /// </summary>
        int FaultCount { get; set; }

        /// <summary>
        /// Количество попыток перезагрузки компьютера.
        /// </summary>
        int TryRebootCount { get; set; }

        /// <summary>
        /// Максимальное количество попыток перезагрузки компьютера.
        /// </summary>
        int TryRebootCountLimit { get; set; }

        /// <summary>
        /// Начальное время запуска процедуры очистки трендовых таблиц.
        /// </summary>
        DateTime SQLCleanTrendTableT0 { get; set; }

        /// <summary>
        /// Список трендовых таблиц для очистки.
        /// </summary>
        Collection<string> SQLCleanTrendTables { get; set; }

        /// <summary>
        /// Получен ли список необходимых в очистке таблиц.
        /// </summary>
        bool SQLInited { get; set; }

        /// <summary>
        /// Фоновый поток для очистки трендовых таблиц.
        /// </summary>
        BackgroundWorker SQLCleanTrendTableWorker { get; set; }

        /// <summary>
        /// Список всех таблиц в БД.
        /// </summary>
        Collection<string> SQLCleanTableAlls { get; set; }

        /// <summary>
        /// Фоновый поток для очистки трендовых таблиц.
        /// </summary>
        BackgroundWorker SQLCleanTableAllWorker { get; set; }

        /// <summary>
        /// Начальное время запуска процедуры очистки всех таблиц.
        /// </summary>
        DateTime SQLCleanTableAllT0 { get; set; }

        /// <summary>
        /// Состояние сервиса.
        /// </summary>
        public enum eStates
        {
            Start = 2,
            Stop = 4,
            Pause = 6,
        }

        public MainForm()
        {
            InitializeComponent();
            varXml = new VarXML("Settings.xml");
            DataClient = new DataServiceClient();
            tmrCheckService = new ThreadTimer();
            IsConnected = true;
            TryRebootCountLimit = 2;

            SQLCleanTrendTables = new Collection<string>();
            SQLInited = false;

            SQLCleanTrendTableWorker = new BackgroundWorker();
            SQLCleanTrendTableWorker.WorkerReportsProgress = true;
            SQLCleanTrendTableWorker.DoWork += SQLCleanTrendTableWorker_DoWork;
            SQLCleanTrendTableWorker.ProgressChanged += SQLCleanTrendTableWorker_ProgressChanged;

            SQLCleanTableAlls = new Collection<string>();

            SQLCleanTableAllWorker = new BackgroundWorker();
            SQLCleanTableAllWorker.WorkerReportsProgress = true;
            SQLCleanTableAllWorker.DoWork += SQLCleanTableAllWorker_DoWork;
            SQLCleanTableAllWorker.ProgressChanged += SQLCleanTableAllWorker_ProgressChanged;
        }

        /// <summary>
        /// Find the siteId for a specified website name. This assumes that the website's
        /// ServerComment property contains the website name.
        /// </summary>
        /// <param name="siteName"></param>
        /// <returns></returns>
        public static string GetSiteIDByName(string siteName)
        {
            DirectoryEntry root = new DirectoryEntry("IIS://" + "localhost" + "/W3SVC");
            foreach (DirectoryEntry e in root.Children)
            {
                if (e.SchemaClassName == "IIsWebServer")
                {
                    if (e.Properties["ServerComment"].Value.ToString().Equals(siteName, StringComparison.OrdinalIgnoreCase))
                    {
                        return e.Name;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Return a string array of the available website names
        /// </summary>
        /// <returns></returns>
        public static string[] EnumerateSites()
        {
            List<string> siteNames = new List<string>();
            try
            {
                DirectoryEntry root = new DirectoryEntry("IIS://" + "localhost" + "/W3SVC");
                foreach (DirectoryEntry e in root.Children)
                {
                    if (e.SchemaClassName == "IIsWebServer")
                    {
                        siteNames.Add(e.Properties["ServerComment"].Value.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Can't enumerate websites");
            }
            return siteNames.ToArray();
        }

        /// <summary>
        /// Show the running/stopped state for the specified site ID
        /// </summary>
        /// <param name="siteId">Numeric site ID</param>
        public static string GetStatus(string siteId)
        {
            string result = "unknown";
            DirectoryEntry root = new DirectoryEntry("IIS://" + "localhost" + "/W3SVC/" + siteId);
            PropertyValueCollection pvc;
            pvc = root.Properties["ServerState"];
            if (pvc.Value != null)
                result = (pvc.Value.Equals((int)eStates.Start) ? "Running" :
                          pvc.Value.Equals((int)eStates.Stop)  ? "Stopped" :
                          pvc.Value.Equals((int)eStates.Pause) ? "Paused"  :
                          pvc.Value.ToString());
            return result;
        }

        /// <summary>
        /// Given an eStates of "Start" or "Stop", set the state on the currently
        /// selected website
        /// </summary>
        /// <param name="state">Either eStates.Stop or eStates.Start to stop or start the website</param>
        public static void SiteInvoke(string siteID, eStates state)
        {            
            try
            {
                ConnectionOptions connectionOptions = new ConnectionOptions();
                connectionOptions.Impersonation = ImpersonationLevel.Impersonate;
                ManagementScope managementScope =
                    new ManagementScope(@"\\" + "localhost" + @"\root\microsoftiisv2", connectionOptions);

                managementScope.Connect();
                if (managementScope.IsConnected)
                {
                    SelectQuery selectQuery =
                        new SelectQuery("Select * From IIsWebServer Where Name = 'W3SVC/" + siteID + "'");
                    using (ManagementObjectSearcher managementObjectSearcher =
                            new ManagementObjectSearcher(managementScope, selectQuery))
                    {
                        foreach (ManagementObject objMgmt in managementObjectSearcher.Get())
                            objMgmt.InvokeMethod(state.ToString(), new object[0]);
                    }
                }
            }
            catch
            {
            }
        }

        void tmrCheckService_WorkChanged(object sender, EventArgs e)
        {
            try
            {
                ServiceVersion = DataClient.GetVersion();
                ServerTime = DataClient.GetSqlCurrentTime();
                IsConnected = true;
                FaultCount = 0;
            }
            catch
            {
                IsConnected = false;
                FaultCount++;
            }

            try
            {
                Status = GetStatus(SiteID);
            }
            catch
            {
            }

            try
            {
                if (!IsConnected)
                {
                    if (SiteID != "")
                    {
                        SiteInvoke(SiteID, eStates.Stop);
                        System.Threading.Thread.Sleep(500);
                        SiteInvoke(SiteID, eStates.Start);
                        Program.SaveLog(string.Format("Команда на перезагрузку сервиса {0}.", varXml.ServiceName));
                    }

                    if (varXml.RebootComputer && FaultCount >= varXml.FaultCountLimit)
                    {
                        if (TryRebootCount <= TryRebootCountLimit)
                        {
                            Process.Start("shutdown.exe", "-r -t 0");
                            Program.SaveLog(string.Format("Команда на перезагрузку компьютера."));
                            TryRebootCount++;
                        }
                    }
                }
            }
            catch
            {
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                varXml.LoadFromXML();
                //varXml.SaveToXML();
                lblWCFEndpointAddress.Text = varXml.WCFEndpointAddress;
                lblServiceName.Text = varXml.ServiceName;

                if (!string.IsNullOrEmpty(varXml.ServiceName))
                    SiteID = GetSiteIDByName(varXml.ServiceName);

                tmrCheckService.Period = varXml.TimerPeriod * 1000;
                tmrCheckService.WorkChanged += tmrCheckService_WorkChanged;
                tmrCheckService.InterfaceChanged += tmrCheckService_InterfaceChanged;

                lblSQLAddress.Text = varXml.SQLAddress;
                lblSQLCleanPeriod.Text = varXml.SQLCleanPeriod.ToString();
                lblSQLActiveDays.Text = varXml.SQLActiveDays.ToString();

                if (!string.IsNullOrEmpty(varXml.WCFEndpointAddress))
                {
                    DataClient.Endpoint.Address = new System.ServiceModel.EndpointAddress(varXml.WCFEndpointAddress);
                    DataClient.Endpoint.Binding.OpenTimeout = DataClient.Endpoint.Binding.CloseTimeout = new TimeSpan(0, 0, 3);
                    DataClient.Endpoint.Binding.SendTimeout = DataClient.Endpoint.Binding.ReceiveTimeout = new TimeSpan(0, 0, 15);
                    tmrCheckService.Run();
                }
                WindowState = FormWindowState.Minimized;
                Hide();
                Program.SaveLog("Приложение запущено.");
            }
            catch
            {
            }
        }

        void tmrCheckService_InterfaceChanged(object sender, EventArgs e)
        {
            lblIsConnected.Text = IsConnected.ToString();
            lblServerTime.Text = ServerTime.ToString();
            lblServiceVersion.Text = ServiceVersion;
            lblStatus.Text = Status;

            if (varXml.RebootComputer)
                lblFault.Text = string.Format("{0} / {1}", FaultCount, varXml.FaultCountLimit);
            else
                lblFault.Text = string.Format("{0}", FaultCount);
        }

        void SQLCleanTrendTableWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!SQLInited)
            {
                SqlConnection connection = new SqlConnection(varXml.SQLAddress);
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM INFORMATION_SCHEMA.TABLES", connection);
                    SqlDataReader reader = command.ExecuteReader();

                    string temp = "";
                    while (reader.Read())
                    {
                        temp = reader.GetString(2);
                        if (temp[0] != '_')
                            SQLCleanTrendTables.Add(temp);
                    }

                    connection.Close();
                    SQLInited = true;
                }
                catch
                {
                }
                finally
                {
                    connection.Close();
                }
            }

            SQLCleanTrendTableWorker.ReportProgress(0);

            if (SQLInited)
            {
                string strcom = "";
                DateTime dateLast;
                for (int i = 0; i < SQLCleanTrendTables.Count; i++)
                {
                    SqlConnection connection = new SqlConnection(varXml.SQLAddress);
                    try
                    {
                        dateLast = DateTime.Now - new TimeSpan(varXml.SQLActiveDays, 0, 0, 0);
                        strcom = string.Format("DELETE FROM {0} WHERE SqlTime < '{1}'; ", SQLCleanTrendTables[i], dateLast.ToString(varXml.SQLDateTimeFormat));
                        connection.Open();
                        SqlCommand command = new SqlCommand(strcom, connection);
                        command.CommandTimeout = 300;
                        command.ExecuteNonQuery();
                        SQLCleanTrendTableWorker.ReportProgress(i + 1);
                    }
                    catch
                    {
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        void SQLCleanTrendTableWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (SQLInited)
            {
                if (e.ProgressPercentage == 0)
                    SQLCleanTrendTableT0 = DateTime.Now;

                if (e.ProgressPercentage != SQLCleanTrendTables.Count)
                    btnSQLCleanTrendTable.Text = string.Format("SQL очистка трендовых таблиц ({0}/{1})", e.ProgressPercentage, SQLCleanTrendTables.Count);
                else
                {
                    TimeSpan diff = DateTime.Now - SQLCleanTrendTableT0;
                    btnSQLCleanTrendTable.Text = string.Format("SQL очистка трендовых таблиц ({0}/{1}) за {2:0.##} сек", e.ProgressPercentage, SQLCleanTrendTables.Count, diff.TotalSeconds);
                    Program.SaveLog(string.Format("{0}.", btnSQLCleanTrendTable.Text));
                }
            }
        }

        void SQLCleanTableAllWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            SQLCleanTableAlls.Clear();
            SqlConnection connection = new SqlConnection(varXml.SQLAddress);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM INFORMATION_SCHEMA.TABLES", connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                    SQLCleanTableAlls.Add(reader.GetString(2));

                reader.Close();

                SQLCleanTableAllWorker.ReportProgress(0);

                string strcom = "";
                for (int i = 0; i < SQLCleanTableAlls.Count; i++)
                {
                    strcom = string.Format("DROP TABLE {0} ; ", SQLCleanTableAlls[i]);
                    command.CommandText = strcom;
                    command.CommandTimeout = 300;
                    command.ExecuteNonQuery();
                    SQLCleanTableAllWorker.ReportProgress(i + 1);
                }
            }
            catch
            {
            }
            finally
            {
                connection.Close();
            }
        }

        void SQLCleanTableAllWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 0)
                SQLCleanTableAllT0 = DateTime.Now;

            if (e.ProgressPercentage != SQLCleanTableAlls.Count)
                btnSQLCleanTableAll.Text = string.Format("SQL очистка всех таблиц ({0}/{1})", e.ProgressPercentage, SQLCleanTableAlls.Count);
            else
            {
                TimeSpan diff = DateTime.Now - SQLCleanTableAllT0;
                btnSQLCleanTableAll.Text = string.Format("SQL очистка всех таблиц ({0}/{1}) за {2:0.##} сек", e.ProgressPercentage, SQLCleanTableAlls.Count, diff.TotalSeconds);
                Program.SaveLog(string.Format("{0}.", btnSQLCleanTableAll.Text));
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.SaveLog("Ручное закрытие приложения.");
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnReboot_Click(object sender, EventArgs e)
        {
            if (!varXml.RebootComputer)
            {
                if (SiteID != "")
                {
                    SiteInvoke(SiteID, eStates.Stop);
                    SiteInvoke(SiteID, eStates.Start);
                    Program.SaveLog(string.Format("Команда на перезагрузку сервиса {0}.", varXml.ServiceName));
                }
            }
            else
            {
                Process.Start("shutdown.exe", "-r -t 0");
                Program.SaveLog(string.Format("Команда на перезагрузку компьютера.", varXml.ServiceName));
            }
        }

        private void ntTray_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
                this.Hide();
        }

        private void btnSQLCleanTrendTable_Click(object sender, EventArgs e)
        {
            if (!SQLCleanTrendTableWorker.IsBusy)
                SQLCleanTrendTableWorker.RunWorkerAsync();
        }

        private void tmrSQL_Tick(object sender, EventArgs e)
        {
            if (!SQLCleanTrendTableWorker.IsBusy)
               SQLCleanTrendTableWorker.RunWorkerAsync();

            if (tmrSQL.Interval != varXml.SQLCleanPeriod * 1000)
                tmrSQL.Interval = varXml.SQLCleanPeriod * 1000;
        }

        private void btnSQLCleanTableAll_Click(object sender, EventArgs e)
        {
            if (!SQLCleanTableAllWorker.IsBusy)
                SQLCleanTableAllWorker.RunWorkerAsync();
        }
    }
}
