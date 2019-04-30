using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace OmiconShop.Application.Logs
{
    public class CreateLogFiles
    {
        string logFormat;
        string errorTime;

        public CreateLogFiles()
        {
            logFormat = string.Concat(DateTime.Now.ToShortDateString().ToString(), " ",
                DateTime.Now.ToLongTimeString().ToString(), " ==> ");

            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString();
            string day = DateTime.Now.Month.ToString();
            var date = string.Concat(year, "_", month, "_", day);

            errorTime = string.Concat(date, ".txt");
        }

        public async void CreateErrorLog(string errMsg)
        {
            var path = DirectoryCreation();

            using (StreamWriter sw = new StreamWriter(string.Concat(path, errorTime), true))
            {
                await sw.WriteLineAsync(logFormat + errMsg);
                sw.Flush();
                sw.Close();
            }
        }

        string DirectoryCreation()
        {
            string path = string.Concat(AppDomain.CurrentDomain.BaseDirectory, "App_Data\\Log\\");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            return path;
        }
    }
}