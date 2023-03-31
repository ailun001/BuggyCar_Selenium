using BuggyCar.Modles;
using BuggyCar.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace BuggyCar
{
    [Binding]
    public class VoteStepDefinitions
    {
        [Given(@"the user is on the BuggyCars website and is not logged in")]
        public void GivenTheUserIsOnTheBuggyCarsWebsiteAndIsNotLoggedIn()
        {
            Page.Home.Goto();
            Assert.IsTrue(Browser.WebDriver.Url.Contains("https://buggy.justtestit.org/"));
            Page.Home.Logout();
        }

        [When(@"the user clicks on any buggy car")]
        public void WhenTheUserClicksOnAnyBuggyCar()
        {
            Page.Home.SelectPopularCar();
        }

        [When(@"tries to vote without logging in")]
        public void WhenTriesToVoteWithoutLoggingIn()
        {
            Page.Home.Logout();
            IWebElement login = Browser.WebDriver.FindElement(By.XPath("/html/body/my-app/header/nav/div/my-login/div/form/button"));
            Assert.IsTrue(login.Displayed);
            try
            {
                IWebElement vote = Browser.WebDriver.FindElement(By.XPath("/html/body/my-app/div/main/my-model/div/div[1]/div[3]/div[2]/div[2]/div/button"));
                Assert.IsFalse(vote.Displayed);
            }catch(NoSuchElementException ex)
            {
                Console.WriteLine("The Vote button element could not be found: " + ex.Message);
            }
        }

        [Then(@"the user should be prompted to log in or register for an account")]
        public void ThenTheUserShouldBePromptedToLogInOrRegisterForAnAccount()
        {
            WebDriverWait wait = new WebDriverWait(Browser.WebDriver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/my-app/div/main/my-model/div/div[1]/div[3]/div[2]/div[2]/p")));
            IWebElement message = Browser.WebDriver.FindElement(By.XPath("/html/body/my-app/div/main/my-model/div/div[1]/div[3]/div[2]/div[2]/p"));
            Assert.IsTrue(message.Text.Contains("You need to be logged in to vote"));
        }

        [Then(@"should not be able to submit a vote")]
        public void ThenShouldNotBeAbleToSubmitAVote()
        {
            IWebElement comment = Browser.WebDriver.FindElement(By.XPath("/html/body/my-app/div/main/my-model/div/div[3]/table/tbody/tr[1]/td[1]"));
            Assert.IsFalse(comment.Text.Contains(DateTime.Now.ToString("MMM dd, yyyy,h")));
        }

        [Given(@"the user is on the BuggyCars website and is logged in")]
        public void GivenTheUserIsOnTheBuggyCarsWebsiteAndIsLoggedIn(Table table)
        {
            Page.Home.Goto();
            Assert.IsTrue(Browser.WebDriver.Url.Contains("https://buggy.justtestit.org/"));
            Page.Home.Logout();
            var login = table.CreateInstance<User>();
            Page.Home.LoginEnter(login.username, login.password);
            Page.Home.SelectLogin();
            WebDriverWait wait = new WebDriverWait(Browser.WebDriver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/my-app/header/nav/div/my-login/div/ul/li[1]/span")));
            IWebElement message = Browser.WebDriver.FindElement(By.XPath("/html/body/my-app/header/nav/div/my-login/div/ul/li[1]/span"));
            Assert.True(message.Displayed);
        }

        [When(@"leaves a comment and votes for the buggy car")]
        public void WhenLeavesACommentAndVotesForTheBuggyCar()
        {
            Page.PopularCar.CommentInput("vote testing");
            Page.PopularCar.SelectVote();
        }

        [Then(@"the system should save the comment for the selected buggy car")]
        public void ThenTheSystemShouldSaveTheCommentForTheSelectedBuggyCar()
        {
            WebDriverWait wait = new WebDriverWait(Browser.WebDriver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/my-app/div/main/my-model/div/div[3]/table/tbody/tr[1]/td[3]")));
            IWebElement comment = Browser.WebDriver.FindElement(By.XPath("/html/body/my-app/div/main/my-model/div/div[3]/table/tbody/tr[1]/td[3]"));
            Assert.True(comment.Text.Contains("vote testing"));
        }

        [Then(@"the comment and vote should be displayed correctly on the buggy car details page")]
        public void ThenTheCommentAndVoteShouldBeDisplayedCorrectlyOnTheBuggyCarDetailsPage()
        {
            WebDriverWait wait = new WebDriverWait(Browser.WebDriver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/my-app/div/main/my-model/div/div[3]/table/tbody/tr[1]/td[3]")));
            IWebElement comment = Browser.WebDriver.FindElement(By.XPath("/html/body/my-app/div/main/my-model/div/div[3]/table/tbody/tr[1]/td[3]"));
            Assert.True(comment.Text.Contains("vote testing"));
        }

        [When(@"tries to vote the same buggy car again")]
        public void WhenTriesToVoteTheSameBuggyCarAgain()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(Browser.WebDriver, TimeSpan.FromSeconds(5));
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/my-app/div/main/my-model/div/div[1]/div[3]/div[2]/div[2]/p")));
                IWebElement vote = Browser.WebDriver.FindElement(By.XPath("/html/body/my-app/div/main/my-model/div/div[1]/div[3]/div[2]/div[2]/div/button"));
                Assert.IsFalse(vote.Displayed);
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine("The Vote button element could not be found: " + ex.Message);
            }
        }

        [Then(@"the system should not allow the user to vote the same buggy car again")]
        public void ThenTheSystemShouldNotAllowTheUserToVoteTheSameBuggyCarAgain()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(Browser.WebDriver, TimeSpan.FromSeconds(5));
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/my-app/div/main/my-model/div/div[1]/div[3]/div[2]/div[2]/p")));
                IWebElement vote = Browser.WebDriver.FindElement(By.XPath("/html/body/my-app/div/main/my-model/div/div[1]/div[3]/div[2]/div[2]/div/button"));
                Assert.IsFalse(vote.Displayed);
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine("The Vote button element could not be found: " + ex.Message);
            }
        }

        [Then(@"a message should be displayed indicating that the user has already voted for the buggy car")]
        public void ThenAMessageShouldBeDisplayedIndicatingThatTheUserHasAlreadyVotedForTheBuggyCar()
        {
            WebDriverWait wait = new WebDriverWait(Browser.WebDriver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/my-app/div/main/my-model/div/div[1]/div[3]/div[2]/div[2]/p")));
            IWebElement message = Browser.WebDriver.FindElement(By.XPath("/html/body/my-app/div/main/my-model/div/div[1]/div[3]/div[2]/div[2]/p"));
            Assert.True(message.Text.Contains("Thank"));
        }

        [When(@"reloads the page")]
        public void WhenReloadsThePage()
        {
            Browser.WebDriver.Navigate().Refresh();
        }

        [Then(@"the system should save the user's comment for the selected buggy car")]
        public void ThenTheSystemShouldSaveTheUsersCommentForTheSelectedBuggyCar()
        {
            WebDriverWait wait = new WebDriverWait(Browser.WebDriver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/my-app/div/main/my-model/div/div[3]/table/tbody/tr[1]/td[3]")));
            IWebElement comment = Browser.WebDriver.FindElement(By.XPath("/html/body/my-app/div/main/my-model/div/div[3]/table/tbody/tr[1]/td[3]"));
            Assert.True(comment.Text.Contains("vote testing"));
        }

        [Then(@"the comment should be displayed correctly on the buggy car detail page")]
        public void ThenTheCommentShouldBeDisplayedCorrectlyOnTheBuggyCarDetailPage()
        {
            WebDriverWait wait = new WebDriverWait(Browser.WebDriver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/my-app/div/main/my-model/div/div[3]/table/tbody/tr[1]/td[3]")));
            IWebElement comment = Browser.WebDriver.FindElement(By.XPath("/html/body/my-app/div/main/my-model/div/div[3]/table/tbody/tr[1]/td[3]"));
            Assert.True(comment.Text.Contains("vote testing"));
        }
    }
}
