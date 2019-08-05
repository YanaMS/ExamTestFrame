using System;
using System.Collections.Generic;
using System.Text;
using TestFramework.DataProvider.BackOffice;

namespace TestFramework.DataProvider.TestData
{
    public static class EventTestData
    {
        public static EventModel CommonBasketballEvent => new EventModel
        {
            EventTime = "19:00",
            EventDate = new DateTime(19, 06, 07),
            EventName = "Фалько Сомбатхей - Сольнок",
            EventDescription = "Баскетбол. Венгрия. Дивизион А",
            EventStage = "Finished",
            EventScore = "90-72 (18-22, 26-11, 28-20, 18-19)",
            EventSettlementState = "Settled",
            Category = "Венгрия",
            Sport = "Баскетбол",
            Tournament = "Дивизион А",
            

        };

        public static EventModel CommonTennisEvent => new EventModel
        {
            EventTime = "13:20",
            EventDate = new DateTime(19, 07, 04),
            EventName = "Завацкая Катарина - Гамис Андреа",
            EventDescription = "Теннис. ITF. Женщины. Биелла. Грунт",
            EventStage = "Finished",
            EventScore = "2-0 (7-5, 6-1)",
            EventSettlementState = "Resettled",
            Category = "ITF",
            Sport = "Теннис",
            Tournament = "Женщины. Биелла. Грунт",
            OutcomeResult = "LOSE"
               
        };

        public static EventModel CommonFootballEvent => new EventModel
        {
            EventTime = "16:00",
            EventDate = new DateTime(19, 07, 09),
            EventName = "Астана - ЧФР Клуж",
            EventDescription = "Футбол. Лига чемпионов УЕФА. Плей-офф",
            EventStage = "Finished",
            EventScore = "1-0 (0-0, 1-0)",
            EventSettlementState = "Settled",
            Category = "Европа",
            Sport = "Футбол",
            Tournament = "Лига чемпионов УЕФА. Квалификация"
        };
    }
}
