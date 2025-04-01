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
    public class MainPageTests
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
            driverManager.SetUpDriver(new ChromeConfig(), "MatchingBrowser");
            
            driver = new ChromeDriver(options);
            mainPage = new MainPage(driver);
            string htmlPath = Path.GetFullPath("PetPage.html");
            driver.Navigate().GoToUrl($"file:///{htmlPath.Replace("\\", "/")}");
        }

        [Test]
        public void TestLoadButtonFunctionality()
        {
            // Get initial content
            string initialContent = mainPage.GetContent();

            // Verify load button is enabled
            Assert.That(mainPage.IsLoadButtonEnabled(), Is.True);

            // Click the load button
            mainPage.ClickLoadButton();

            // Wait for content to change
            mainPage.WaitForContentToChange(initialContent);

            // Verify content has changed
            string newContent = mainPage.GetContent();
            Assert.That(newContent, Is.Not.EqualTo(initialContent));
        }

        [TearDown]
        public void Cleanup()
        {
            driver?.Quit();
        }
    }
} 