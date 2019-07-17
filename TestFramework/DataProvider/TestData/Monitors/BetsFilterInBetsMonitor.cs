using System;
using System.Collections.Generic;
using System.Text;
using TestFramework.DataProvider.Model.Monitors;

namespace TestFramework.DataProvider.TestData.Monitors
{
    class BetsFilterInBetsMonitor
    {
        public static BetsFilterInBetsMonitorModel CommonBetsFilterInBetsMonitor => new BetsFilterInBetsMonitorModel()
        {
            AcceptedTimeItems = "Временной интервал",
            AcceptTimeFrom = new DateTime(19, 08, 07, 00,00,00),
            AcceptTimeTo = new DateTime(19, 10, 07, 00, 00, 00),
            PlayerId = "304567591",
        };

        public static BetsFilterInBetsMonitorModel CommonBetsFilterInBetsMonitor2 => new BetsFilterInBetsMonitorModel()
        {
            AcceptedTimeItems = "Временной интервал",
            AcceptTimeFrom = new DateTime(19, 06, 07, 00, 00, 00),
            AcceptTimeTo = new DateTime(19, 07, 07, 00, 00, 00),
            Channel = "Desktop",
            PlayerId = "611907224",
        };
    }
}
