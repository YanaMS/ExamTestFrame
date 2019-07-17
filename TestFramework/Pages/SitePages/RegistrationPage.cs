using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TestFramework.Session;

namespace TestFramework.Pages
{
    public class RegistrationPage : BasePage
    {
        private readonly By _email;
        private readonly By _currencyId;
        private readonly By _password;
        private readonly By _submitButton;
        private readonly By _verifiedEmail;
        private readonly By _day;
        private readonly By _month;
        private readonly By _year;

        public RegistrationPage()
        {
            _driver.Url = "http://air-pm-skeleton-bl.hp.consul/en/regmail";
            _email = By.Id("email");
            _currencyId = By.Id("currencyId");
            _password = By.Id("password");
            _submitButton = By.CssSelector(".form-wrap__footer>button");
            _verifiedEmail = By.ClassName("short-registration-success__email");
            _day = By.XPath("//select[@ref='day']");
            _month = By.XPath("//select[@ref='month']");
            _year = By.XPath("//select[@ref='year']");
        }
        public RegistrationPage InsertEmail(string email)
        {
            _driver.FindElement(_email).SendKeys(email);
            return this;
        }
        public RegistrationPage SelectBirthDay(string year, string month, string day)
        {
            SelectBirthElement(_day, day);
            SelectBirthElement(_month, month);
            SelectBirthElement(_year, year);
            return this;
        }
        public RegistrationPage SelectCurrency(string currency)
        {
            IWebElement selectcurrency = _driver.FindElement(_currencyId);
            SelectElement select = new SelectElement(selectcurrency);
            select.SelectByValue(currency);
            return this;
        }
        public RegistrationPage InsertPassword(string password)
        {
            _driver.FindElement(_password).SendKeys(password);
            return this;
        }
        public void SubmitRegistration()
        {
            _driver.FindElement(_submitButton).Click();
        }

        private void SelectBirthElement(By element, string value)
        {
            IWebElement selectBirtElement = _driver.FindElement(element);
            SelectElement selectByBelement = new SelectElement(selectBirtElement);
            selectByBelement.SelectByValue(value.ToString());
        }

        public string GetRegistredEmail()
        {
            var element = _driver.FindElement(_verifiedEmail);
            return element.Text; ;
        }

        public void ShowAlert()
        {
            DriverManager.GetJsExecutor().ExecuteScript("alert('Hello!I am an alert box!!');");
        }
    }
}