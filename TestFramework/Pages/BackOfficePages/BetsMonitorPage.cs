using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestFramework.Pages.BackOfficePages
{
    public class BetsMonitorPage : BasePage
    {
        private IWebElement GoToBetsMonitor =>
            _driver.FindElement(By.XPath("//li[@class='nav-menu-item']/a[@href='/monitors/bets']"));

        private IWebElement ExpandAcceptedTimeMenu =>
            _driver.FindElement(By.XPath("//span[@class='multiselect__single']"));

        private IWebElement SelectAcceptTimeItem(string acceptTimeItemName) =>
            _driver.FindElement(
                By.XPath($"//li[@class='multiselect__element']//span[contains(text(),'{acceptTimeItemName}')]"));

        private IWebElement ExpandChannelMenu =>
            _driver.FindElement(By.XPath("//span[contains(text(),'Выбрать канал')]"));

        private IWebElement SelectChannel(string ChannelName) =>
            _driver.FindElement(
                By.XPath($"//li[@class='multiselect__element']//span[contains(text(),'{ChannelName}')]"));

        private IWebElement BetsTimePickerFrom =>
            _driver.FindElements(By.XPath(".//input[@class='mx-input']"))[0];

        private IWebElement BetsTimePickerTo =>
            _driver.FindElements(By.XPath(".//input[@class='mx-input']"))[1];

        private IWebElement CloseCalendarFrom =>
            _driver.FindElement(By.XPath("//label[contains(text(),'От:')]"));

        private IWebElement CloseCalendarTo =>
            _driver.FindElement(By.XPath("//label[contains(text(),'До:')]"));

        private IWebElement GoToPlayerIdField =>
            _driver.FindElement(By.XPath("//input[contains(@placeholder, 'ID')]/.."));

        private IWebElement PlayerIdInsert =>
            _driver.FindElement(By.XPath("//input[contains(@placeholder, 'ID')]"));

        private IWebElement SelectInsertedPlayerIdFromList =>
            _driver.FindElement(
                By.XPath("//div[@class='bo-player-id bo-multiselect']//div[@class='multiselect__content-wrapper']"));

        private IWebElement FilterButton =>
            _driver.FindElement(By.XPath("//button[@class='warning raised lg']"));

        private IWebElement[] FilteredPlayers =>
            _driver.FindElements(By.XPath("//td[@class='bet-view-table-cell playerId']")).ToArray();

        private IWebElement[] DateCells =>
            _driver.FindElements(By.XPath("//td[@class='bet-view-table-cell betAcceptTime']")).ToArray();

        private IWebElement[] CollectEventsName =>
            _driver.FindElements(By.XPath("//div[@class='eventName-text has-tooltip']")).ToArray();

        private IEnumerable<IWebElement> SpinnerElements =>
            _driver.FindElements(By.XPath("//div[@class='spinner']"));

        public DateTime[] GetBetsDate()
        {
            return DateCells.Select(i => DateTime.Parse(i.Text)).ToArray();
        }

        public string[] GetPlayers()
        {
            return FilteredPlayers.Select(i => i.Text).ToArray();
        }

        public string[] GetAllEventNames()
        {
            return CollectEventsName.Select(i => i.Text).ToArray();
        }

        public void OpenBetsMonitor()
        {
            GoToBetsMonitor.Click();
        }

        public BetsMonitorPage SelectAcceptedTimeInterval(string acceptTimeItemName)
        {
            ExpandAcceptedTimeMenu.Click();
            SelectAcceptTimeItem(acceptTimeItemName).Click();
            return this;
        }

        public BetsMonitorPage SelectChannelName(string channelName)
        {
            ExpandChannelMenu.Click();
            SelectChannel(channelName).Click();
            return this;
        }

        public BetsMonitorPage SetDateInBetsCalendar(DateTime fromDate, DateTime toDate)
        {
            var setDateFrom = $"{fromDate.ToString("dd.MM.yy")}";
            var setDateTo = $"{toDate.ToString("dd.MM.yy")}";
            BetsTimePickerFrom.SendKeys(setDateFrom);
            CloseCalendarFrom.Click();
            BetsTimePickerTo.SendKeys(setDateTo);

            CloseCalendarTo.Click();
            return this;
        }

        public BetsMonitorPage SearchByPlayerId(string userId)
        {
            GoToPlayerIdField.Click();
            PlayerIdInsert.SendKeys(userId);
            SelectInsertedPlayerIdFromList.Click();
            return this;
        }

        public void ClickOnFilterButton()
        {
            FilterButton.Click();
            WaitForBetsListLoaded();
        }

        private void WaitForBetsListLoaded()
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
      
            wait.Until(driver => SpinnerElements.Count() > 0);
            wait.Until(driver => SpinnerElements.Count() == 0);
        }
    }
}
