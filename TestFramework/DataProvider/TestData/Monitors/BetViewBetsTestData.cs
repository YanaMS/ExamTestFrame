using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using TestFramework.DataProvider.Model.Monitors;

namespace TestFramework.DataProvider.TestData.Monitors
{
    class BetViewBetsTestData
    {
        public static RequestToBetViewBetsModel CommonRequestToBetViewService => new RequestToBetViewBetsModel()
        {
            InFilter = CommonInFilter,
            ODataFilter = "(acceptTime le 2019-07-06T21:00:00.000Z) and (acceptTime ge 2019-07-05T21:00:00.000Z)",
            Take = 50
        };

        public static InFilter CommonInFilter => new InFilter()
        {
        Sports = new string[] { },
        CategoryIds = new string[] { },
        TournamentIds = new string[] { },
        BetTypes = new string[] { },
        SegmentIds = new string[] { },
        Currencies = new string[] { },
        PlayerIds = new string[] {"611907224"},
        ResultIds = new string[] { },
        AfsIds = new string[] { },
        TraderIds = new string[] { },
        Channels = new string[] {"DESKTOP_AIR_PM"},
        };
    }
}
