using OpenQA.Selenium;
using SeleniumPetWikiTest.Base;

namespace SeleniumPetWikiTest.Pages
{
    public class MainPage : BasePage
    {
        // Locators
        private readonly By contentLocator = By.Id("content");
        private readonly By loadButtonLocator = By.Id("load-button");

        // Properties
        private IWebElement ContentElement => WaitForElement(contentLocator);
        private IWebElement LoadButtonElement => WaitForElement(loadButtonLocator);

        public MainPage(IWebDriver driver) : base(driver)
        {
        }

        public string GetContent()
        {
            return ContentElement.Text;
        }

        public void ClickLoadButton()
        {
            LoadButtonElement.Click();
        }

        public bool IsLoadButtonEnabled()
        {
            return LoadButtonElement.Enabled;
        }

        public void WaitForContentToChange(string initialContent)
        {
            wait.Until(d => d.FindElement(contentLocator).Text != initialContent);
        }

        public void WaitForLoadButtonToBeClickable()
        {
            wait.Until(d => d.FindElement(loadButtonLocator).Enabled);
        }
    }
} 