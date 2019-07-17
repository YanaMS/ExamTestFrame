using System;
using System.Collections.Generic;
using System.Text;
using TestFramework.DataProvider.Model;

namespace TestFramework.DataProvider.TestData.Monitors
{
    class BetsFilterInSettlementMonitor
    {
        public static BetsFilterInSettlementMonitorModel CommonBetsFilter => new BetsFilterInSettlementMonitorModel()
        {
            AcceptTimeFrom = new DateTime(19, 08, 07),
            AcceptTimeTo = new DateTime(19, 07, 10),
            BetAmountFrom = 3,
            BetAmountTo = 100,
            Segment = "Без статуса",
            Channel = "Desktop",
        };
    }
}
