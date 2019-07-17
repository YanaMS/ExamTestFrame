using System;
using System.Collections.Generic;
using System.Text;

namespace TestFramework.DataProvider.Model.Monitors
{
    public class BetsFilterInBetsMonitorModel
    {
        public string AcceptedTimeItems { get; set; }
        public DateTime AcceptTimeFrom { get; set; }
        public DateTime AcceptTimeTo { get; set; }
        public string PlayerId { get; set; }
        public string Channel { get; set; }
    }
}
