using BuggyCar.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using TechTalk.SpecFlow;

namespace BuggyCar
{
    [Binding]
    public class LoginStepDefinitions
    {
        [Given(@"the user is on the BuggyCar home page")]
        public void GivenTheUserIsOnTheBuggyCarHomePage()
        {
            Page.Home.Goto();
            Assert.IsTrue(Browser.WebDriver.Url.Contains("https://buggy.justtestit.org/"));
            Page.Home.Logout();
        }


        [Given(@"the user can see the login form")]
        public void GivenTheUserCanSeeTheLoginForm()
        {
            IWebElement username = Browser.WebDriver.FindElement(By.Name("login"));
            Assert.True(username.Displayed);
            IWebElement password = Browser.WebDriver.FindElement(By.Name("password"));
            Assert.True(password.Displayed);
        }

        [When(@"the user enters valid login credentials with (.*) (.*)")]
        public void WhenTheUserEntersValidLoginCredentials(string username, string password)
        {
           Page.Home.LoginEnter(username, password);
        }

        [When(@"clicks on the Login button")]
        public void WhenClicksOnTheLoginButton()
        {
            Page.Home.SelectLogin();
        }
        
        [Then(@"the profile link should be visible")]
        public void ThenTheProfileLinkShouldBeVisible()
        {
            WebDriverWait wait = new WebDriverWait(Browser.WebDriver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Profile")));
            IWebElement profile = Browser.WebDriver.FindElement(By.LinkText("Profile"));
            Assert.True(profile.Displayed);
        }

        [Then(@"the Logout link should be visible")]
        public void ThenTheLogoutLinkShouldBeVisible()
        {
            IWebElement logout = Browser.WebDriver.FindElement(By.LinkText("Logout"));
            Assert.True(logout.Displayed);
        }

        [Then(@"the user should see a welcome message with their username\.")]
        public void ThenTheUserShouldSeeAWelcomeMessageWithTheirUsername_()
        {
            IWebElement welecome = Browser.WebDriver.FindElement(By.XPath("/html/body/my-app/header/nav/div/my-login/div/ul/li[1]/span"));
            Assert.True(welecome.Displayed);
        }

        [When(@"the user enters invalid login credentials with (.*) (.*)")]
        public void WhenTheUserEntersInvalidLoginCredentials(string username, string passsword)
        {
            Page.Home.LoginEnter(username,passsword);
            Page.Home.SelectLogin();
        }

        [Then(@"an error message indicating that the login credentials are incorrect should be displayed\.")]
        public void ThenAnErrorMessageIndicatingThatTheLoginCredentialsAreIncorrectShouldBeDisplayed_()
        {
            WebDriverWait wait = new WebDriverWait(Browser.WebDriver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/my-app/header/nav/div/my-login/div/form/div/span")));
            IWebElement message = Browser.WebDriver.FindElement(By.XPath("/html/body/my-app/header/nav/div/my-login/div/form/div/span"));
            Assert.True(message.Displayed);
        }
    }
}
