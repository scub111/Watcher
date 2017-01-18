using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Watcher
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }


        public static void SaveLog(string text)
        {
            try
            {
                //Pass the filepath and filename to the StreamWriter Constructor
                StreamWriter stream = new StreamWriter(Path.GetDirectoryName(Application.ExecutablePath) + "\\" + "Log.txt", true);

                //Write a line of text
                stream.WriteLine(string.Format("{0} - {1}", DateTime.Now, text));

                //Close the file
                stream.Close();
            }
            catch
            {
            }
        }
    }
}
