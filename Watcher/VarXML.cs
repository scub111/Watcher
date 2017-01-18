using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Watcher
{
    /// <summary>
    /// Основной класс глобальных переменных, которых можно сохранить в XML-файд
    /// </summary>
    public class VarXML
    {
        /// <summary>
        /// Конструктор <see cref="GlobalVarBase"/> class.
        /// </summary>
        public VarXML()
        {
            this.FileXml = "Config.xml";
            Init();
        }

        /// <summary>
        /// Конструктор <see cref="GlobalVarBase"/> class.
        /// </summary>
        public VarXML(string strFileXml)
        {
            this.FileXml = strFileXml;
            WCFEndpointAddress = "WCFEndpointAddress";
            ServiceName = "ServiceName";
            TimerPeriod = 5000;
            RebootComputer = false;
            SQLAddress = "SQLAddress";
            SQLCleanPeriod = 86400;
            SQLActiveDays = 30;
            FaultCountLimit = 5;
            SQLDateTimeFormat = "MM/dd/yyyy HH:mm:ss";
            Init();
       }

        void Init()
        {
            FilePath = Path.GetDirectoryName(Application.ExecutablePath) + "\\" + FileXml;
        }

        /// <summary>
        /// Название файла, куда будет сохняться данные.
        /// </summary>
        [XmlIgnore]
        string FileXml;

        /// <summary>
        /// Путь к файлу.
        /// </summary>
        [XmlIgnore]
        public string FilePath;

        /// <summary>
        /// Адрес WCF-сервиса.
        /// </summary>
        public string WCFEndpointAddress;

        /// <summary>
        /// Имя сервиса.
        /// </summary>
        public string ServiceName;

        /// <summary>
        /// Перезагрузка компьюетра в случае необходимости.
        /// </summary>
        public bool RebootComputer;

        /// <summary>
        /// Период опроса.
        /// </summary>
        public int TimerPeriod;

        /// <summary>
        /// Предел попыток запустить сервис, после которого будет перезагружен компьютер.
        /// </summary>
        public int FaultCountLimit;

        /// <summary>
        /// Адрес БД для очистки.
        /// </summary>
        public string SQLAddress;

        /// <summary>
        /// Период очистки БД.
        /// </summary>
        public int SQLCleanPeriod;

        /// <summary>
        /// Время в днях актуальной исторической инфмормации.
        /// </summary>
        public int SQLActiveDays;

        /// <summary>
        /// Формат времени базы данных.
        /// </summary>
        public string SQLDateTimeFormat;

        /// <summary>
        /// Сохранить данные в XML-файл.
        /// </summary>
        public void SaveToXML()
        {
            XmlSerializer xmlSer = new XmlSerializer(typeof(VarXML));
            TextWriter textWriter = new StreamWriter(FilePath);
            xmlSer.Serialize(textWriter, this);
            textWriter.Close();
        }

        /// <summary>
        /// Загрузить данные из XML-файла.
        /// </summary>
        /// <returns></returns>
        public void LoadFromXML()
        {
            if (File.Exists(FilePath))
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(VarXML));
                TextReader textReader = new StreamReader(FilePath);
                VarXML obj = (VarXML)deserializer.Deserialize(textReader);
                textReader.Close();

                WCFEndpointAddress = obj.WCFEndpointAddress;
                ServiceName = obj.ServiceName;
                TimerPeriod = obj.TimerPeriod;
                RebootComputer = obj.RebootComputer;
                FaultCountLimit = obj.FaultCountLimit;
                SQLAddress = obj.SQLAddress;
                SQLCleanPeriod = obj.SQLCleanPeriod;
                SQLActiveDays = obj.SQLActiveDays;
                SQLDateTimeFormat = obj.SQLDateTimeFormat;
            }
        }
    }

}
