using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumPetWikiTest.Model
{
    public class BasePage
    {
        protected readonly IWebDriver driver;
        protected readonly WebDriverWait wait;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
        }

        protected IWebElement WaitForElement(By locator)
        {
            return wait.Until(d => d.FindElement(locator));
        }

        protected bool IsElementPresent(By locator)
        {
            try
            {
                driver.FindElement(locator);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}