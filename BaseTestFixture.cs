using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumPetWikiTest.Model;
using System.IO;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumPetWikiTest.Tests
{
    public class BaseTestFixture
    {
        protected IWebDriver driver;
        protected MainPage mainPage;

        [SetUp]
        public virtual void Setup()
        {
            var options = new ChromeOptions();
            options.AddArguments("--no-sandbox");
            options.AddArguments("--disable-dev-shm-usage");

            // Configure WebDriverManager
            var driverManager = new DriverManager();
            string chromeDriverPath = driverManager.SetUpDriver(new ChromeConfig());

            driver = new ChromeDriver(chromeDriverPath, options);
            mainPage = new MainPage(driver);
            string htmlPath = Path.GetFullPath("PetPage.html");
            driver.Navigate().GoToUrl($"file:///{htmlPath.Replace("\\", "/")}");
        }

        [TearDown]
        public virtual void Cleanup()
        {
            driver?.Quit();
        }
    }
} 