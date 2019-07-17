using Newtonsoft.Json;

namespace TestFramework.DataProvider.Model.Monitors
{
    public class InFilter
    {
        public string[] Sports { get; set; }
        public string[] CategoryIds { get; set; }
        public string[] TournamentIds { get; set; }
        public string[] BetTypes { get; set; }
        public string[] SegmentIds { get; set; }
        public string[] Currencies { get; set; }
        public string[] PlayerIds { get; set; }
        public string[] ResultIds { get; set; }
        public string[] AfsIds { get; set; }
        public string[] TraderIds { get; set; }
        public string[] Channels { get; set; }
    }

    public class RequestToBetViewBetsModel
    {
        [JsonProperty(PropertyName = "inFilter")]
        public InFilter InFilter = new InFilter();
        [JsonProperty(PropertyName = "oDataFilter")]
        public string ODataFilter { get; set; }
        [JsonProperty(PropertyName = "take")]
        public int Take { get; set; }
    }
}

