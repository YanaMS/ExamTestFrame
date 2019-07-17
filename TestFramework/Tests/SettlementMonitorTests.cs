using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using OpenQA.Selenium;
using TestFramework.DataProvider.BackOffice;
using TestFramework.DataProvider.TestData;
using TestFramework.DataProvider.TestData.Monitors;
using TestFramework.Pages.BackOfficePages;
using TestFramework.Requests;

namespace TestFramework.Tests
{
    class SettlementMonitorTests : BaseUITest
    {
        private BackOfficeLoginPage _backOfficeLoginPage;
        private SettlementMonitorEventTreePage _settlementMonitorPage;
        private SettlementMonitorEventPage _settlementMonitorEventPage;
        private PlayerHistoryPage _playerHistoryPage;
        private BetsMonitorPage _betsMonitorPage;
        private BetViewRequest _betViewRequest;

        [SetUp]
        public void BeforeTest()
        {
            _backOfficeLoginPage = new BackOfficeLoginPage();
            _settlementMonitorPage = new SettlementMonitorEventTreePage();
            _settlementMonitorEventPage = new SettlementMonitorEventPage();
            _playerHistoryPage = new PlayerHistoryPage();
            _betsMonitorPage = new BetsMonitorPage();
            _betViewRequest = new BetViewRequest();
        }

        [TestCaseSource(typeof(RegistrationTestData), nameof(RegistrationTestData.GetFullBackOfficeLoginData))]
        public void Case1SearchEventInEventTree(LoginProviderBackOffice loginData)
        {
            var @event = EventTestData.CommonBasketballEvent;

            _backOfficeLoginPage
                .GoToLoginPage();
            _backOfficeLoginPage
                .InputLogin(loginData.Login)
                .InputPassword(loginData.Password)
                .PressSighInButton();
            _backOfficeLoginPage
               .OpenBackOfficeMenu();

            _settlementMonitorPage
                .GoToSettlemenMonitor();
            _settlementMonitorPage
                .SetDateInCalendar(@event.EventDate, @event.EventDate)
                .SelectEventInEventTree(@event.Sport, @event.Category, @event.Tournament, @event.EventName)
                .SelectEventStage(@event.EventStage);

            var expectedEventName = @event.EventName;
            var actualEventname = _settlementMonitorPage.GetEventName();
            var expectedSettletStatus = @event.EventSettlementState;
            var actualSettledStatus = _settlementMonitorPage.GetSettledStatus();
            var expectedEventStage = @event.EventStage;
            var actualEventStage = _settlementMonitorPage.GetEventStage();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedEventName, actualEventname);
                Assert.AreEqual(expectedSettletStatus, actualSettledStatus);
                Assert.AreEqual(expectedEventStage, actualEventStage);
            });
        }

        [TestCaseSource(typeof(RegistrationTestData), nameof(RegistrationTestData.GetFullBackOfficeLoginData))]
        public void Case2VerifyBetLogsPopup(LoginProviderBackOffice loginData)
        {
            var @event = EventTestData.CommonTennisEvent;

            _backOfficeLoginPage
                .GoToLoginPage();
            _backOfficeLoginPage
                .InputLogin(loginData.Login)
                .InputPassword(loginData.Password)
                .PressSighInButton();
            _backOfficeLoginPage
                .OpenBackOfficeMenu();

            _settlementMonitorPage
                .GoToSettlemenMonitor();
            _settlementMonitorPage
                .SetDateInCalendar(@event.EventDate, @event.EventDate)
                .SelectEventInEventTree(@event.Sport, @event.Category, @event.Tournament, @event.EventName)
                .OpenMarketsForSelectedEvent();
            _settlementMonitorEventPage
                .OpenBetLogPopUp();

            var expectedEventNameInPopUp = @event.EventName;
            var actualEventNameInPopUp = _settlementMonitorEventPage.GetEventNameInBetLogPopUp();
            var expectedBetStatusInPopUp = @event.EventSettlementState;
            var actualBetStatusInBetLogPopUp = _settlementMonitorEventPage.GetBetStatusInBetLogPopUp();
            var expectedOutcomeResultInBetLogPopUp = @event.OutcomeResult;
            var actualOutcomeResultInBetLogPopUp = _settlementMonitorEventPage.GetOutcomeResultInBetLogPopUp();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedEventNameInPopUp, actualEventNameInPopUp);
                Assert.AreEqual(expectedBetStatusInPopUp, actualBetStatusInBetLogPopUp);
                Assert.AreEqual(expectedOutcomeResultInBetLogPopUp, actualOutcomeResultInBetLogPopUp);
            });

        }

        [TestCaseSource(typeof(RegistrationTestData), nameof(RegistrationTestData.GetFullBackOfficeLoginData))]
        public void Case3_1CheckFilterBetInSettlementMonitorRedirectToPlayerProfile(LoginProviderBackOffice loginData)
        {
            var @event = EventTestData.CommonFootballEvent;
            var filterData = BetsFilterInSettlementMonitor.CommonBetsFilter;

            _backOfficeLoginPage
                .GoToLoginPage();
            _backOfficeLoginPage
                .InputLogin(loginData.Login)
                .InputPassword(loginData.Password)
                .PressSighInButton();
            _backOfficeLoginPage
                .OpenBackOfficeMenu();

            _settlementMonitorPage
                .GoToSettlemenMonitor();
            _settlementMonitorPage
                .SetDateInCalendar(@event.EventDate, @event.EventDate)
                .SelectEventInEventTree(@event.Sport, @event.Category, @event.Tournament,
                    @event.EventName)
                .OpenMarketsForSelectedEvent();
            _settlementMonitorEventPage
                .ClickOnBetsFilterButton();
            _settlementMonitorEventPage
                .SetDateInBetsCalendar(filterData.AcceptTimeFrom)
                .SetBetAmountFrom(filterData.BetAmountFrom)
                .SelectSegment(filterData.Segment)
                .SelectChannel(filterData.Channel)
                .ClickApproveButton();
            _settlementMonitorEventPage
                .GoToPlayerBetHistory();

            _playerHistoryPage
                 .SwitchToPlayerHistoryPage();
                   
            var actualUrl = _playerHistoryPage._driver.Url;
            var expectedRegexUrl = new Regex(@"http:\/\/backoffice.kube.private\/players\/\d+\/bets");
            var isUrlMatch = expectedRegexUrl.IsMatch(actualUrl);

            Assert.IsTrue(isUrlMatch);
        }

        [TestCaseSource(typeof(RegistrationTestData), nameof(RegistrationTestData.GetFullBackOfficeLoginData))]
        public void Case3_2CheckFilterBetInSettlementMonitorByDate(LoginProviderBackOffice loginData)
        {
            var @event = EventTestData.CommonFootballEvent;
            var filterData = BetsFilterInSettlementMonitor.CommonBetsFilter;

            _backOfficeLoginPage
                .GoToLoginPage();
            _backOfficeLoginPage
                .InputLogin(loginData.Login)
                .InputPassword(loginData.Password)
                .PressSighInButton();
            _backOfficeLoginPage
                .OpenBackOfficeMenu();

            _settlementMonitorPage
                .GoToSettlemenMonitor();
            _settlementMonitorPage
                .SetDateInCalendar(@event.EventDate, @event.EventDate)
                .SelectEventInEventTree(@event.Sport, @event.Category, @event.Tournament,
                    @event.EventName)
                .OpenMarketsForSelectedEvent();
            _settlementMonitorEventPage
                .ClickOnBetsFilterButton();
            _settlementMonitorEventPage
                .SetDateInBetsCalendar(filterData.AcceptTimeFrom)
                .SetBetAmountFrom(filterData.BetAmountFrom)
                .SelectSegment(filterData.Segment)
                .SelectChannel(filterData.Channel)
                .ClickApproveButton();

            var actualBetsDate = _settlementMonitorEventPage.GetBetsDate();
            var areAllDatesGreaterThen = actualBetsDate.All(item => item >= filterData.AcceptTimeFrom);
            var expectedCountOfBets = 3;

            Assert.Multiple(()=>
            {
                Assert.IsTrue(areAllDatesGreaterThen);
                Assert.AreEqual(expectedCountOfBets, actualBetsDate.Length);
            });
        }

        [TestCaseSource(typeof(RegistrationTestData), nameof(RegistrationTestData.GetFullBackOfficeLoginData))]
        public void Case3_3CheckFilterBetInSettlementMonitorCheckBetChannel(LoginProviderBackOffice loginData)
        {
            var @event = EventTestData.CommonFootballEvent;
            var filterData = BetsFilterInSettlementMonitor.CommonBetsFilter;

            _backOfficeLoginPage
                .GoToLoginPage();
            _backOfficeLoginPage
                .InputLogin(loginData.Login)
                .InputPassword(loginData.Password)
                .PressSighInButton();
            _backOfficeLoginPage
                .OpenBackOfficeMenu();

            _settlementMonitorPage
                .GoToSettlemenMonitor();
            _settlementMonitorPage
                .SetDateInCalendar(@event.EventDate, @event.EventDate)
                .SelectEventInEventTree(@event.Sport, @event.Category, @event.Tournament,
                    @event.EventName)
                .OpenMarketsForSelectedEvent();
            _settlementMonitorEventPage
                .ClickOnBetsFilterButton();
            _settlementMonitorEventPage
                .SetDateInBetsCalendar(filterData.AcceptTimeFrom)
                .SetBetAmountFrom(filterData.BetAmountFrom)
                .SelectSegment(filterData.Segment)
                .SelectChannel(filterData.Channel)
                .ClickApproveButton();
            _settlementMonitorEventPage
                .GoToPlayerBetHistory();

            _playerHistoryPage
                 .SwitchToPlayerHistoryPage();

            var expectedChannel = filterData.Channel;
            var actualChannel = _playerHistoryPage.GetChannelFromPlayerHistory().Channel;

            Assert.AreEqual(expectedChannel, actualChannel);
        }

        [TestCaseSource(typeof(RegistrationTestData), nameof(RegistrationTestData.GetFullBackOfficeLoginData))]
        public void Case4_1CheckFilterInBetsMonitorAreAllPlayersAsFiltered(LoginProviderBackOffice loginData)
        {
            var filterData = BetsFilterInBetsMonitor.CommonBetsFilterInBetsMonitor;

            _backOfficeLoginPage
                .GoToLoginPage();
            _backOfficeLoginPage
                .InputLogin(loginData.Login)
                .InputPassword(loginData.Password)
                .PressSighInButton();
            _backOfficeLoginPage
                .OpenBackOfficeMenu();

            _betsMonitorPage
                .OpenBetsMonitor();
            _betsMonitorPage
                .SelectAcceptedTimeInterval(filterData.AcceptedTimeItems)
                .SetDateInBetsCalendar(filterData.AcceptTimeFrom, filterData.AcceptTimeTo)
                .SearchByPlayerId(filterData.PlayerId)
                .ClickOnFilterButton();

            var actualPlayerIds = _betsMonitorPage.GetPlayers();
            var AreAllPlayerAsFiltered = actualPlayerIds.All(item => item == filterData.PlayerId);
            var expectedCoundOfPlayerIds = 7;

            Assert.Multiple(() =>
            {
                Assert.IsTrue(AreAllPlayerAsFiltered);
                Assert.AreEqual(expectedCoundOfPlayerIds, actualPlayerIds.Length);
            });
        }

        [TestCaseSource(typeof(RegistrationTestData), nameof(RegistrationTestData.GetFullBackOfficeLoginData))]
        public void Case4_2CheckFilterInBetsMonitorCheckDateFilter(LoginProviderBackOffice loginData)
        {
            var filterData = BetsFilterInBetsMonitor.CommonBetsFilterInBetsMonitor;

            _backOfficeLoginPage
                .GoToLoginPage();
            _backOfficeLoginPage
                .InputLogin(loginData.Login)
                .InputPassword(loginData.Password)
                .PressSighInButton();
            _backOfficeLoginPage
                .OpenBackOfficeMenu();

            _betsMonitorPage
                .OpenBetsMonitor();
            _betsMonitorPage
                .SelectAcceptedTimeInterval(filterData.AcceptedTimeItems)
                .SetDateInBetsCalendar(filterData.AcceptTimeFrom, filterData.AcceptTimeTo)
                .SearchByPlayerId(filterData.PlayerId)
                .ClickOnFilterButton();

            var actualBetsDate = _betsMonitorPage.GetBetsDate();
            var areAllDatesGreaterThen = actualBetsDate.All(item => item >= filterData.AcceptTimeFrom);
            var expectedCountOfBets = 7;

            Assert.Multiple(() =>
            {
                Assert.IsTrue(areAllDatesGreaterThen);
                Assert.AreEqual(expectedCountOfBets, actualBetsDate.Length);
            });

        }

        [TestCaseSource(typeof(RegistrationTestData), nameof(RegistrationTestData.GetFullBackOfficeLoginData))]
        public void Case5VerifyBetTable(LoginProviderBackOffice loginData)
        {
            var filterData = BetsFilterInBetsMonitor.CommonBetsFilterInBetsMonitor2;
            var backOfficeLoginProvider = new LoginProviderBackOffice();

            _backOfficeLoginPage
                .GoToLoginPage();
            _backOfficeLoginPage
                .InputLogin(loginData.Login)
                .InputPassword(loginData.Password)
                .PressSighInButton();
            _backOfficeLoginPage
                .OpenBackOfficeMenu();

            _betsMonitorPage
                .OpenBetsMonitor();
            _betsMonitorPage
                .SelectAcceptedTimeInterval(filterData.AcceptedTimeItems)
                .SetDateInBetsCalendar(filterData.AcceptTimeFrom, filterData.AcceptTimeTo)
                .SearchByPlayerId(filterData.PlayerId)
                .SelectChannelName(filterData.Channel)
                .ClickOnFilterButton();

            var actualEventNamesFE = _betsMonitorPage.GetAllEventNames();
            _betViewRequest.AuthorizationInBackOffice(backOfficeLoginProvider);
            var expectedEventNamesBE = _betViewRequest.RequestToBetViewBetsMethod();

            CollectionAssert.AreEqual(actualEventNamesFE, expectedEventNamesBE);
        }


    }
}



