using NUnit.Framework;

namespace SeleniumPetWikiTest.Tests
{
    [TestFixture]
    public class MainPageTests : BaseTestFixture
    {
        [Test]
        public void TestLoadButtonFunctionality_InitialContentIsDisplayed()
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
            Assert.AreEqual(newContent, "The Maltese is a breed of dog in the toy group.");
        }
    }
} 