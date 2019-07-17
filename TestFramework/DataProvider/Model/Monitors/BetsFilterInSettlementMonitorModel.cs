using System;
using NUnit.Framework;

namespace TestFramework.DataProvider.Model
{
    public class BetsFilterInSettlementMonitorModel
    {
        public string AcceptedTimeItems { get; set; }
        public DateTime AcceptTimeFrom { get; set; }
        public DateTime AcceptTimeTo { get; set; }
        public int BetAmountFrom { get; set; }
        public int BetAmountTo { get; set; }
        public string Segment { get; set; }
        public string Channel { get; set; }
    }
}