using OpenQA.Selenium;
using TestFramework.Utils.Extensions;

namespace TestFramework.Pages.BackOfficePages
{
    public class BackOfficeLoginPage: BasePage
    {
        private IWebElement Login =>
            _driver.FindElement(By.XPath("//input[@placeholder='Username']"));
        private IWebElement Password => 
            _driver.FindElement(By.XPath("//input[@placeholder='Password']"));
        private IWebElement SignInButton =>
            _driver.FindElement(By.XPath("//button[@class='primary']"));
        private IWebElement ExpandBackOfficeMenu =>
            _driver.FindElement(By.XPath("//i[contains(text(),'expand_more')]"));

        public BackOfficeLoginPage GoToLoginPage()
        {
            _driver.Url = "http://backoffice.kube.private/login";
            return this;
        }

        public BackOfficeLoginPage InputLogin(string login)
        {
            Login.SendKeys(login);
            return this;
        }

        public BackOfficeLoginPage InputPassword( string password)
        {
            Password.SendKeys(password);
            return this;
        }

        public void PressSighInButton()
        {
            SignInButton.Click();
        }

        public void OpenBackOfficeMenu()
        {
            ExpandBackOfficeMenu.ClickToSuccess();
        }
    }

    
}
