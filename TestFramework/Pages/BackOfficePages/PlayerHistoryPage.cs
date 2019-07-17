using OpenQA.Selenium;
using System.Linq;
using TestFramework.DataProvider.Model.Monitors;

namespace TestFramework.Pages.BackOfficePages
{
    public class PlayerHistoryPage : BasePage
    {
        private IWebElement Channel => _driver.FindElement(By.XPath("//td[@class='channel']/label"));
        
        public PlayerHistoryPage SwitchToPlayerHistoryPage()
        {
            _driver.SwitchTo().Window(_driver.WindowHandles.Last());
            return this;
        }

        public BetsInPlayerHistoryModel GetChannelFromPlayerHistory()
        {
            return new BetsInPlayerHistoryModel
            {
                Channel = Channel.GetAttribute("title")
            };
        }
    }
}
