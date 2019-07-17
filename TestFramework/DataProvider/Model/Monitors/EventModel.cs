using System;
using System.Collections.Generic;
using System.Text;

namespace TestFramework.DataProvider.BackOffice
{
    public class EventModel
    {
        public string EventTime { get; set; }
        public DateTime EventDate { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public string EventStage { get; set; }
        public string EventScore { get; set; }
        public string EventSettlementState { get; set; }
        public string Sport { get; set; }
        public string Category { get; set; }
        public string Tournament { get; set; }
        public string OutcomeResult { get; set; }
    }
}
