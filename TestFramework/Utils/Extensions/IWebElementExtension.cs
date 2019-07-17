using OpenQA.Selenium;

namespace TestFramework.Utils.Extensions
{
    public static class IWebElementExtension
    {
       public static void ClickToSuccess(this IWebElement element, int retry = 10)
        {
            try
            {
                element.Click();
            }
            catch
            {
                if (retry != 0)
                    ClickToSuccess(element, --retry);
            }
        }
    }
}

