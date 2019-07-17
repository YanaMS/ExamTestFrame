using OpenQA.Selenium;
using TestFramework.Session;

namespace TestFramework.Pages
{
    public class BasePage
    {
        public IWebDriver _driver = DriverManager.GetDriver();
    }
}