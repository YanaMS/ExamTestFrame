using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestFramework.Pages
{
    public class SuccessRegistrationPage : BasePage
    {
        private readonly By _verifiedEmail;

        public SuccessRegistrationPage()
        {
            _driver.Url = "http://air-pm-skeleton-bl.hp.consul/en/registration";
            _verifiedEmail = By.ClassName("header-user__link");
        }

        public string GetRegistredUserName()
        {
            var element = _driver.FindElement(_verifiedEmail);
            return element.Text; ;
        }
    }
}