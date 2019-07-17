using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestFramework.Pages
{

    public class FullRegistrationPage : BasePage
    {
        private readonly By _firstName;
        private readonly By _lastName;
        private readonly By _email;
        private readonly By _confirmEmail;
        private readonly By _verifiedEmail;
        private readonly By _countryId;
        private readonly By _city;
        private readonly By _cellId;
        private readonly By _currencyId;
        private readonly By _questionId;
        private readonly By _answerId;
        private readonly By _password;
        private readonly By _confirmPassword;
        private readonly By _confirmAge;
        private readonly By _submitButton;

        private readonly By _day;
        private readonly By _month;
        private readonly By _year;

        public FullRegistrationPage()
        {
            _driver.Url = "http://air-pm-skeleton-bl.hp.consul/en/registration";
            _firstName = By.Id("firstName");
            _lastName = By.Id("lastName");
            _email = By.Id("email");
            _confirmEmail = By.Id("confirmEmail");
            _countryId = By.Id("countryId");
            _city = By.Id("city");
            _cellId = By.Id("phone");
            _currencyId = By.Id("currencyId");
            _questionId = By.Id("securityQuestion");
            _answerId = By.Id("securityAnswer");
            _password = By.Id("password");
            _submitButton = By.CssSelector(".form-wrap__footer>button");
            _verifiedEmail = By.ClassName("header-user__link");
            _day = By.XPath("//select[@ref='day']");
            _month = By.XPath("//select[@ref='month']");
            _year = By.XPath("//select[@ref='year']");
            _confirmPassword = By.Id("confirmPassword");
            _confirmAge = By.Id("checkbox-text");
        }

        public FullRegistrationPage InsertFirstName(string firstName)
        {
            _driver.FindElement(_firstName).SendKeys(firstName);
            return this;
        }

        public FullRegistrationPage InsertLastName(string lastName)
        {
            _driver.FindElement(_lastName).SendKeys(lastName);
            return this;
        }

        public FullRegistrationPage SelectBirthDay(string year, string month, string day)
        {
            SelectBirthElement(_day, day);
            SelectBirthElement(_month, month);
            SelectBirthElement(_year, year);
            return this;
        }

        private void SelectBirthElement(By element, string value)
        {
            IWebElement selectBirtElement = _driver.FindElement(element);
            SelectElement selectByBelement = new SelectElement(selectBirtElement);
            selectByBelement.SelectByValue(value.ToString());
        }

        public FullRegistrationPage InsertEmail(string email)
        {
            _driver.FindElement(_email).SendKeys(email);
            return this;
        }

        public FullRegistrationPage ConfirmEmail(string confirmEmail)
        {
            _driver.FindElement(_confirmEmail).SendKeys(confirmEmail);
            return this;
        }

        public FullRegistrationPage ContryOfResidence (string contryOfResidence)
        {
            IWebElement selectCountry = _driver.FindElement(_countryId);
            SelectElement select = new SelectElement(selectCountry);
            select.SelectByValue(contryOfResidence);
            return this;
        }

        public FullRegistrationPage CityOfResidence(string cityOfResidence)
        {
            _driver.FindElement(_city).SendKeys(cityOfResidence);
            return this;
        }

        public FullRegistrationPage Cell(string cell)
        {
            _driver.FindElement(_cellId).SendKeys(cell);
            return this;
        }

        public FullRegistrationPage SelectCurrency(string currency)
        {
            IWebElement selectcurrency = _driver.FindElement(_currencyId);
            SelectElement select = new SelectElement(selectcurrency);
            select.SelectByValue(currency);
            return this;
        }

        public FullRegistrationPage SelectQuestion(string secretQuestion)
        {
            IWebElement selectQuestion = _driver.FindElement(_questionId);
            SelectElement select = new SelectElement(selectQuestion);
            select.SelectByValue(secretQuestion);
            return this;
        }

        public FullRegistrationPage SecretAnswer(string answer)
        {
            _driver.FindElement(_answerId).SendKeys(answer);
            return this;
        }

        public FullRegistrationPage InsertPassword(string password)
        {
            _driver.FindElement(_password).SendKeys(password);
            return this;
        }

        public FullRegistrationPage ConfirmPassword(string password)
        {
            _driver.FindElement(_confirmPassword).SendKeys(password);
            return this;
        }

        public FullRegistrationPage ConfirmAge()
        {
            _driver.FindElement(_confirmAge).Click();
            return this;
        }

        public void SubmitRegistration()
        {
            _driver.FindElement(_submitButton).Click();
        }

    }
}