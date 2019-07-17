using System.Collections.Generic;
using TestFramework.Utils;
using TestFramework.DataProvider.Model.Monitors;
using Newtonsoft.Json;
using TestFramework.DataProvider.BackOffice;
using TestFramework.DataProvider.TestData.Monitors;

namespace TestFramework.Requests
{
    public class BetViewRequest
    {
        private ApiClient client;
        private string token = null;

        public BetViewRequest()
        {
            client = new ApiClient("http://bet-view-new.kube.private");
        }

        public void AuthorizationInBackOffice(LoginProviderBackOffice login)
        {
            token = TokenManager.AuthorizeMonitor(login);
        }

        public List<string> RequestToBetViewBetsMethod()
        {
            var data = BetViewBetsTestData.CommonRequestToBetViewService;
            var requestToBetView = data;
            var betViewResponce = client.PostWithToken("/bets", token, JsonConvert.SerializeObject(requestToBetView));
            var resultObject = JsonConvert.DeserializeObject<List<BetsViewBetsResponseModel>>(betViewResponce);
            var eventNames = new List<string>();
            foreach (var element in resultObject)
            {
                eventNames.Add(element.EventName);
            }
            return eventNames;
        }
    }
}
