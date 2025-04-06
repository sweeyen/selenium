# Selenium Pet Wiki Test Automation

This project contains automated tests for a Pet Wiki web application using Selenium WebDriver with C# and NUnit.

## Project Structure

The project follows the Page Object Model (POM) design pattern:

- **BasePage.cs**: Contains common functionality for all page objects
- **MainPage.cs**: Implements the main page item and functionalities
- **BaseTestFixture.cs**: Contains common setup and teardown for all test classes
- **MainPageTests.cs**: Tests for the main page functionality
- **PetWikiTests.cs**: Additional tests for the Pet Wiki application

## Test Cases

### MainPageTests

- **TestLoadButtonFunctionality**: Verifies that the load button changes the content on the page

### PetWikiTests

- **TestGetLoadedData**: Verifies that clicking the load button loads pet data containing "Maltese"
- **TestLoadButtonState**: Verifies the load button's enabled/disabled state during data loading

## Page Object Model

The project uses the Page Object Model pattern to separate test logic from page implementation details:

- **BasePage**: Provides common functionality like waiting for elements
- **MainPage**: Implements specific page interactions like clicking the load button and getting content

## WebDriver Management

The project uses WebDriverManager to automatically download and manage the appropriate ChromeDriver version for your Chrome browser.