namespace Watcher
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblServiceName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblIsConnected = new System.Windows.Forms.Label();
            this.lblServerTime = new System.Windows.Forms.Label();
            this.btnReboot = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblFault = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblWCFEndpointAddress = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblSQLAddress = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblSQLCleanPeriod = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblSQLActiveDays = new System.Windows.Forms.Label();
            this.btnSQLCleanTrendTable = new System.Windows.Forms.Button();
            this.btnSQLCleanTableAll = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.lblServiceVersion = new System.Windows.Forms.Label();
            this.ntTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.tmrSQL = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.19298F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.80702F));
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblServiceName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblIsConnected, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblServerTime, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnReboot, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblStatus, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblFault, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblWCFEndpointAddress, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.lblSQLAddress, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.lblSQLCleanPeriod, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.lblSQLActiveDays, 1, 10);
            this.tableLayoutPanel1.Controls.Add(this.btnSQLCleanTrendTable, 0, 12);
            this.tableLayoutPanel1.Controls.Add(this.btnSQLCleanTableAll, 0, 11);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblServiceVersion, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 13;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.238319F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.238319F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.238319F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.238319F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.238319F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.238319F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.239687F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.205418F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.238319F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.238319F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.239687F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.204324F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.204324F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(510, 407);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Имя сервиса:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Время сервера:";
            // 
            // lblServiceName
            // 
            this.lblServiceName.AutoSize = true;
            this.lblServiceName.Location = new System.Drawing.Point(141, 29);
            this.lblServiceName.Name = "lblServiceName";
            this.lblServiceName.Size = new System.Drawing.Size(25, 13);
            this.lblServiceName.TabIndex = 7;
            this.lblServiceName.Text = "???";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Соединен:";
            // 
            // lblIsConnected
            // 
            this.lblIsConnected.AutoSize = true;
            this.lblIsConnected.Location = new System.Drawing.Point(141, 116);
            this.lblIsConnected.Name = "lblIsConnected";
            this.lblIsConnected.Size = new System.Drawing.Size(25, 13);
            this.lblIsConnected.TabIndex = 3;
            this.lblIsConnected.Text = "???";
            // 
            // lblServerTime
            // 
            this.lblServerTime.AutoSize = true;
            this.lblServerTime.Location = new System.Drawing.Point(141, 145);
            this.lblServerTime.Name = "lblServerTime";
            this.lblServerTime.Size = new System.Drawing.Size(25, 13);
            this.lblServerTime.TabIndex = 2;
            this.lblServerTime.Text = "???";
            // 
            // btnReboot
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.btnReboot, 2);
            this.btnReboot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnReboot.Location = new System.Drawing.Point(3, 206);
            this.btnReboot.Name = "btnReboot";
            this.btnReboot.Size = new System.Drawing.Size(504, 31);
            this.btnReboot.TabIndex = 9;
            this.btnReboot.Text = "Перезагрузка";
            this.btnReboot.UseVisualStyleBackColor = true;
            this.btnReboot.Click += new System.EventHandler(this.btnReboot_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Статус:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(141, 87);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(25, 13);
            this.lblStatus.TabIndex = 10;
            this.lblStatus.Text = "???";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Попытки:";
            // 
            // lblFault
            // 
            this.lblFault.AutoSize = true;
            this.lblFault.Location = new System.Drawing.Point(141, 174);
            this.lblFault.Name = "lblFault";
            this.lblFault.Size = new System.Drawing.Size(25, 13);
            this.lblFault.TabIndex = 12;
            this.lblFault.Text = "???";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "WCF-адрес:";
            // 
            // lblWCFEndpointAddress
            // 
            this.lblWCFEndpointAddress.AutoSize = true;
            this.lblWCFEndpointAddress.Location = new System.Drawing.Point(141, 0);
            this.lblWCFEndpointAddress.Name = "lblWCFEndpointAddress";
            this.lblWCFEndpointAddress.Size = new System.Drawing.Size(25, 13);
            this.lblWCFEndpointAddress.TabIndex = 14;
            this.lblWCFEndpointAddress.Text = "???";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 240);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "SQL-адрес:";
            // 
            // lblSQLAddress
            // 
            this.lblSQLAddress.AutoSize = true;
            this.lblSQLAddress.Location = new System.Drawing.Point(141, 240);
            this.lblSQLAddress.Name = "lblSQLAddress";
            this.lblSQLAddress.Size = new System.Drawing.Size(25, 13);
            this.lblSQLAddress.TabIndex = 16;
            this.lblSQLAddress.Text = "???";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 269);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "Период очистки:";
            // 
            // lblSQLCleanPeriod
            // 
            this.lblSQLCleanPeriod.AutoSize = true;
            this.lblSQLCleanPeriod.Location = new System.Drawing.Point(141, 269);
            this.lblSQLCleanPeriod.Name = "lblSQLCleanPeriod";
            this.lblSQLCleanPeriod.Size = new System.Drawing.Size(25, 13);
            this.lblSQLCleanPeriod.TabIndex = 18;
            this.lblSQLCleanPeriod.Text = "???";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 298);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Актуальные дни:";
            // 
            // lblSQLActiveDays
            // 
            this.lblSQLActiveDays.AutoSize = true;
            this.lblSQLActiveDays.Location = new System.Drawing.Point(141, 298);
            this.lblSQLActiveDays.Name = "lblSQLActiveDays";
            this.lblSQLActiveDays.Size = new System.Drawing.Size(25, 13);
            this.lblSQLActiveDays.TabIndex = 20;
            this.lblSQLActiveDays.Text = "???";
            // 
            // btnSQLCleanTrendTable
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.btnSQLCleanTrendTable, 2);
            this.btnSQLCleanTrendTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSQLCleanTrendTable.Location = new System.Drawing.Point(3, 367);
            this.btnSQLCleanTrendTable.Name = "btnSQLCleanTrendTable";
            this.btnSQLCleanTrendTable.Size = new System.Drawing.Size(504, 37);
            this.btnSQLCleanTrendTable.TabIndex = 21;
            this.btnSQLCleanTrendTable.Text = "SQL очистка трендовых таблиц";
            this.btnSQLCleanTrendTable.UseVisualStyleBackColor = true;
            this.btnSQLCleanTrendTable.Click += new System.EventHandler(this.btnSQLCleanTrendTable_Click);
            // 
            // btnSQLCleanTableAll
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.btnSQLCleanTableAll, 2);
            this.btnSQLCleanTableAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSQLCleanTableAll.Location = new System.Drawing.Point(3, 330);
            this.btnSQLCleanTableAll.Name = "btnSQLCleanTableAll";
            this.btnSQLCleanTableAll.Size = new System.Drawing.Size(504, 31);
            this.btnSQLCleanTableAll.TabIndex = 22;
            this.btnSQLCleanTableAll.Text = "SQL очистка всех таблиц";
            this.btnSQLCleanTableAll.UseVisualStyleBackColor = true;
            this.btnSQLCleanTableAll.Click += new System.EventHandler(this.btnSQLCleanTableAll_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 58);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Версия сервиса:";
            // 
            // lblServiceVersion
            // 
            this.lblServiceVersion.AutoSize = true;
            this.lblServiceVersion.Location = new System.Drawing.Point(141, 58);
            this.lblServiceVersion.Name = "lblServiceVersion";
            this.lblServiceVersion.Size = new System.Drawing.Size(25, 13);
            this.lblServiceVersion.TabIndex = 7;
            this.lblServiceVersion.Text = "???";
            // 
            // ntTray
            // 
            this.ntTray.Icon = ((System.Drawing.Icon)(resources.GetObject("ntTray.Icon")));
            this.ntTray.Text = "Watcher";
            this.ntTray.Visible = true;
            this.ntTray.Click += new System.EventHandler(this.ntTray_Click);
            // 
            // tmrSQL
            // 
            this.tmrSQL.Enabled = true;
            this.tmrSQL.Interval = 1000;
            this.tmrSQL.Tick += new System.EventHandler(this.tmrSQL_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 407);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Watcher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblServerTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblIsConnected;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblServiceName;
        private System.Windows.Forms.Button btnReboot;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.NotifyIcon ntTray;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblFault;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblWCFEndpointAddress;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblSQLAddress;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblSQLCleanPeriod;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblSQLActiveDays;
        private System.Windows.Forms.Button btnSQLCleanTrendTable;
        private System.Windows.Forms.Timer tmrSQL;
        private System.Windows.Forms.Button btnSQLCleanTableAll;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblServiceVersion;
    }
}

