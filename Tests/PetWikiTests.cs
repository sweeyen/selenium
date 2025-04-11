using NUnit.Framework;

namespace SeleniumPetWikiTest.Tests
{
    [TestFixture]
    public class PetWikiTests : BaseTestFixture
    {
        [Test]
        public void TestGetLoadedData_ContentIsDisplayed()
        {
            // Click the load button
            mainPage.ClickLoadButton();

            // Wait for the button to be clickable again (indicating data has loaded)
            mainPage.WaitForLoadButtonToBeClickable();

            // Get the loaded content
            string loadedContent = mainPage.GetContent();

            // Verify the content is not empty and contains expected text
            Assert.That(loadedContent, Is.Not.Null.Or.Empty);
            Assert.AreEqual(loadedContent, "The Maltese is a breed of dog in the toy group.");
        }

        [Test]
        public void TestLoadButtonState_ButtonisEnabledAfterLoading()
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
    }
} 