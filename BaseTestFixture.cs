using NUnit.Framework;
using NUnit.Framework.Interfaces;
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
            options.AddArguments("--headless");
            options.AddArguments("--disable-dev-shm-usage");

            // Configure WebDriverManager
            var driverManager = new DriverManager();
            string chromeDriverPath = driverManager.SetUpDriver(new ChromeConfig());

            driver = new ChromeDriver(chromeDriverPath, options);

            // Set implicit wait
            // Not recommended as it will wait for all components and it will be combined total waiting time with explicitWait
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            mainPage = new MainPage(driver);
            string htmlPath = Path.GetFullPath("PetPage.html");
            driver.Navigate().GoToUrl($"file:///{htmlPath.Replace("\\", "/")}");
        }

        [TearDown]
        public virtual void Cleanup()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                CaptureScreenshot();
            }
            driver?.Quit();
        }

        private void CaptureScreenshot()
        {
            try
            {
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                string screenshotDirectory = Path.Combine(TestContext.CurrentContext.WorkDirectory, "Screenshots");
                Directory.CreateDirectory(screenshotDirectory);
                string testName = TestContext.CurrentContext.Test.Name.Replace(' ', '_');
                string screenshotFilePath = Path.Combine(screenshotDirectory, $"{testName}.jpg");
                screenshot.SaveAsFile(screenshotFilePath);
                TestContext.AddTestAttachment(screenshotFilePath, "Screenshot on Failure");
            }
            catch (Exception ex)
            {
                TestContext.WriteLine($"Failed to capture screenshot: {ex.Message}");
            }
        }
    }
} 