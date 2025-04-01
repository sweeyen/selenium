using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumPetWikiTest.Pages;
using System.IO;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace SeleniumPetWikiTest.Tests
{
    [TestFixture]
    public class PetWikiTests
    {
        private IWebDriver driver;
        private MainPage mainPage;

        [SetUp]
        public void Setup()
        {
            var options = new ChromeOptions();
            options.AddArguments("--no-sandbox");
            options.AddArguments("--disable-dev-shm-usage");
            
            // Configure WebDriverManager to use Chrome version 134
            var driverManager = new DriverManager();
            driverManager.SetUpDriver(new ChromeConfig(), "134.0.6998.177");
            
            driver = new ChromeDriver(options);
            mainPage = new MainPage(driver);
            string htmlPath = Path.GetFullPath("PetPage.html");
            driver.Navigate().GoToUrl($"file:///{htmlPath.Replace("\\", "/")}");
        }

        [Test]
        public void TestGetLoadedData()
        {
            // Click the load button
            mainPage.ClickLoadButton();

            // Wait for the button to be clickable again (indicating data has loaded)
            mainPage.WaitForLoadButtonToBeClickable();

            // Get the loaded content
            string loadedContent = mainPage.GetContent();

            // Verify the content is not empty and contains expected text
            Assert.That(loadedContent, Is.Not.Null.Or.Empty);
            Assert.That(loadedContent, Does.Contain("Maltese"));
        }

        [Test]
        public void TestLoadButtonState()
        {
            // Verify button is initially enabled
            Assert.That(mainPage.IsLoadButtonEnabled(), Is.True);

            // Click the button
            mainPage.ClickLoadButton();

            // Verify button is disabled during loading
            Assert.That(mainPage.IsLoadButtonEnabled(), Is.False);

            // Wait for button to be enabled again
            mainPage.WaitForLoadButtonToBeClickable();

            // Verify button is enabled again after loading
            Assert.That(mainPage.IsLoadButtonEnabled(), Is.True);
        }

        [TearDown]
        public void Cleanup()
        {
            driver?.Quit();
        }
    }
} 