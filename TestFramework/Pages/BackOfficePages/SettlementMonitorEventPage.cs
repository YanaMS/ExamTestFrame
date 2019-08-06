using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using TestFramework.Utils.Extensions;

namespace TestFramework.Pages.BackOfficePages
{
    public class SettlementMonitorEventPage: BasePage
    {

        private IWebElement BetLogPopUpOpenButton =>
            _driver.FindElement(By.XPath(".//td[@class='mn-table-cell bet-table-cell log']"));
        private IWebElement CloseBlockAutosettlementDashboard =>
            _driver.FindElement(By.XPath(".//button[@class='icon transparent close-button']"));
        private IWebElement BetLogPopUp =>
            _driver.FindElement(By.XPath(".//div[@class='modal-dialog']"));
        private IWebElement EventNameInBetLogPopUp =>
            BetLogPopUp.FindElement(By.XPath(".//td[@class='eventName']"));
        private IWebElement EventStatusInBetLogPopUp =>
            BetLogPopUp.FindElement(By.XPath(".//span[@class='label boLabel resettled']"));
        private IWebElement OutcomeResultInBetLogPopUp =>
            BetLogPopUp.FindElement(By.XPath(".//td[@class='result']"));
        private IWebElement OpenBetsFilter =>
            _driver.FindElement(By.XPath(".//button[@class='default white bordered']"));
        private IWebElement BetsTimePickerFrom =>
            _driver.FindElement(By.XPath(".//input[@class='mx-input']"));
        private IWebElement CloseCalendar =>
            _driver.FindElement(By.XPath("//label[contains(text(),'От:')]"));
        private IWebElement BetAmountFrom =>
            _driver.FindElement(By.XPath(".//input[@placeholder='От']"));
        private IWebElement OpenPlayerSegmentMenu =>
            _driver.FindElement(By.XPath("//span[(contains(text(),'Все сегменты')) or (contains(text(),'All segments'))]"));
        private IWebElement SelectPlayerSegmentName(string segmentName) =>
            _driver.FindElement(By.XPath($"//span[contains(text(),'{segmentName}')]"));
        private IWebElement ClosePlayerSegmentMenu =>
            _driver.FindElements(By.XPath("//div[@class='multiselect__select']"))[1];
        private IWebElement OpenChannelMenu =>
            _driver.FindElement(By.XPath("//span[(contains(text(),'Все каналы')) or (contains(text(),'All channels'))]"));
        private IWebElement SelectChannelName(string channelName) =>
            _driver.FindElement(By.XPath($"//span[contains(text(),'{channelName}')]"));
        private IWebElement CloseChannelMenu =>
            _driver.FindElements(By.XPath("//div[@class='multiselect__select']"))[2];
        private IWebElement ApproveButton =>
            _driver.FindElement(By.XPath("//button[@class='warning raised']"));
        private IWebElement PlayerId =>
            _driver.FindElement(By.XPath("//span[@class='player-profit-status good']"));
        private IWebElement[] DateTimeGroupCells =>
            _driver.FindElements(By.XPath("//td[@class='mn-table-cell bet-table-cell betAcceptTime']")).ToArray();
        private IWebElement[] DateCells =>
            DateTimeGroupCells.Select(i =>
                i.FindElement(By.XPath("//div[@class='mn-table-cell-content bet-table-cell-content'][2]"))).ToArray();

        public DateTime[] GetBetsDate()
        {
            return DateCells.Select(i => DateTime.Parse(i.Text)).ToArray();
        }

        private void WaitButtonEnabled(IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => element.Displayed && element.Enabled);
        }

        public void ClickOnBetsFilterButton()
        {
            try
            {
                CloseBlockAutosettlementDashboard.Click();
            }
            catch
            {
            }
            finally
            {
                WaitButtonEnabled(OpenBetsFilter);
                OpenBetsFilter.Click();
            }
        }

        public SettlementMonitorEventPage SetDateInBetsCalendar(DateTime fromDate)
        {
            var setDate = $"{fromDate.ToString("dd.MM.yy")}";
            BetsTimePickerFrom.SendKeys(setDate);
            CloseCalendar.Click();
            return this;
        }

        public SettlementMonitorEventPage SetBetAmountFrom(int amountFrom)
        {
            var setAmountFrom = amountFrom.ToString();
            BetAmountFrom.SendKeys(setAmountFrom);
            return this;
        }

        public SettlementMonitorEventPage SelectSegment(string playerSegmentName)
        {
            OpenPlayerSegmentMenu.Click();
            SelectPlayerSegmentName(playerSegmentName).Click();
            ClosePlayerSegmentMenu.Click();
            return this;
        }

        public SettlementMonitorEventPage SelectChannel(string playerChannelName)
        {
            OpenChannelMenu.Click();
            SelectChannelName(playerChannelName).Click();
            CloseChannelMenu.Click();

            return this;
        }

        public void ClickApproveButton()
        {
            ApproveButton.ClickToSuccess();

        }

        public void GoToPlayerBetHistory()
        {
            PlayerId.Click();
        }

        public void OpenBetLogPopUp()
        {
            try
            {
                CloseBlockAutosettlementDashboard.Click();
            }
            catch
            {

            }
            finally
            {
                BetLogPopUpOpenButton.Click();
            }
        }

        public string GetEventNameInBetLogPopUp()
        {
            return EventNameInBetLogPopUp.Text;
        }

        public string GetBetStatusInBetLogPopUp()
        {
            return EventStatusInBetLogPopUp.Text;
        }

        public string GetOutcomeResultInBetLogPopUp()
        {
            return OutcomeResultInBetLogPopUp.Text;
        }
    }
}
