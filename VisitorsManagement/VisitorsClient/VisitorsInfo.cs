using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace VisitorsClient
{
   public class VisitorsInfo
    {
        public string VisitorId { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string VisitorsOrg { get; set; }
        public string WhomToSee { get; set; }
        public string HostDept { get; set; }
        public string VisitorSatatus { get; set; }
        public string DayVisited { get; set; }
        public DateTime TimeIn { get; set; }
        public DateTime TimeOut { get; set; }
        public Image VisitorPhoto { get; set; }
    }
}
