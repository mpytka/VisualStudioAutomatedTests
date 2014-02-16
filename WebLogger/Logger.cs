using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebLogger.DataItems;
using System.Collections.Generic;
using System.IO;

namespace WebLogger
{
    public class Logger
    {
        List<LogItem> Logs { get; set; }

        public Logger()
        {
            this.Logs = new List<LogItem>();
        }

        public void AddNewLog(string header, string message)
        {
            this.Logs.Add(new LogItem()
            {
                LogItemTimeStamp = DateTime.Now,
                Header = header,
                Message = message,
            });
        }

        public void SaveLogs(string testName)
        {
            if (!Directory.Exists("Logs")) 
                Directory.CreateDirectory("Logs");
            using (var sw = new StreamWriter(String.Format("Logs\\{0}{1}.txt", testName, DateTime.Now.ToLongTimeString().Replace(':', '_'))))
            {
                foreach (var item in this.Logs)
                {
                    sw.WriteLine("{0} >> {1} | {2}", item.LogItemTimeStamp.ToString(), item.Header, item.Message);
                }
            }
        }

    }
}
