using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebLogger.DataItems
{
    public class LogItem
    {
        public DateTime LogItemTimeStamp { get; set; }
        public string Header {get; set;}
        public string Message { get; set; }
    }
}
