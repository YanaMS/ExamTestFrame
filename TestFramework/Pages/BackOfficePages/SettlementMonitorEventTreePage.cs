using OpenQA.Selenium;
using System;

namespace TestFramework.Pages.BackOfficePages
{
    public class SettlementMonitorEventTreePage: BasePage
    {
        private IWebElement GoToSettlementMonitor =>
            _driver.FindElement(By.XPath("//li[@class='nav-menu-item']/a[@href='/monitors/settlement']"));
        private IWebElement OpenCalendar =>
            _driver.FindElement(By.XPath("//span[@class='mx-input-append']"));
        private IWebElement CalendarField =>
            _driver.FindElement(By.XPath($"//*[@placeholder='Выберите период']"));
        private IWebElement EventsTreeRefreshButton =>
            _driver.FindElement(By.XPath("//i[contains(text(),'refresh')]"));
        private IWebElement SelectSportInEventTree(string sportName) =>
            _driver.FindElement(By.XPath($"//label[contains(text(),'{sportName}')]"));
        private IWebElement SelectCategoryInEventTree(string categoryName) =>
            _driver.FindElement(By.XPath($"//label[contains(text(),'{categoryName}')]"));
        private IWebElement SelectTournamentInEventTree(string tournamentName) =>
            _driver.FindElement(By.XPath($"//label[contains(text(),'{tournamentName}')]"));
        private IWebElement ChooseEventInEventsTree(string eventName) =>
            _driver.FindElement(By.XPath($"//div[.//span[text()='{eventName}'] and span[@class='bo-checkbox']]//span[@class='material-icons']"));
        private IWebElement OpenEventStageMenu =>
            _driver.FindElement(By.XPath("//div[@class='event-list-filter']/div[3]/div[1]/div[1]"));
        private IWebElement ChooseEventStageFromDropDownMenu(string eventStage) =>
            _driver.FindElement(By.XPath($"//*[text()='{eventStage}']"));
        private IWebElement PinnedEventsSection =>
            _driver.FindElement(By.XPath(".//section[@class='settlement-event-list pinned']"));
        private IWebElement FirstPinnedEvent =>
            PinnedEventsSection.FindElement(By.XPath(".//div[@class='alert-item']"));
        private IWebElement SettledStatus =>
            FirstPinnedEvent.FindElement(By.XPath(".//span[contains(@class, 'label boLabel')]"));
        private IWebElement EventStage => 
            FirstPinnedEvent.FindElement(By.XPath(".//div[@class='event-stage']//span[@class='value']"));
        private IWebElement EventName =>
            FirstPinnedEvent.FindElement(By.XPath(".//div[@class='event-title has-tooltip']"));
        private IWebElement EventMarkets =>
            PinnedEventsSection.FindElement(By.XPath(".//div[@class='alert-item']"));

        public void GoToSettlemenMonitor()
        {
            GoToSettlementMonitor.Click();
        }

        public SettlementMonitorEventTreePage SetDateInCalendar(DateTime fromDate, DateTime toDate)
        {
            var setDate = $"{fromDate.ToString("dd.MM.yy")} - {toDate.ToString("dd.MM.yy")}";
            OpenCalendarInBSM();
            CalendarField.Clear();
            CalendarField.SendKeys(setDate);
            EventsTreeRefreshButton.Click();
            return this;
        }

        public void OpenCalendarInBSM()
        {
            OpenCalendar.Click();
        }

        public void EventTreeRefresh()
        {
            EventsTreeRefreshButton.Click();
        }

        public SettlementMonitorEventTreePage SelectEventInEventTree(string sportName, string categoryName, string tournamentName, string eventName)
        {
            SelectSportInEventTree(sportName).Click();
            SelectCategoryInEventTree(categoryName).Click();
            SelectTournamentInEventTree(tournamentName).Click();
            ChooseEventInEventsTree(eventName).Click();
            return this;
        }

        public SettlementMonitorEventTreePage SelectEventStage(string eventStageName)
        {
            OpenEventStageMenu.Click();
            ChooseEventStageFromDropDownMenu(eventStageName).Click();
            return this;
        }

        public string GetEventName()
        {
            return EventName.Text;
        }

        public string GetSettledStatus()
        {
            return SettledStatus.Text;
        }

        public string GetEventStage()
        {
            return EventStage.Text;
        }

        public void OpenMarketsForSelectedEvent()
        {
            EventMarkets.Click();
        }


    }
}
