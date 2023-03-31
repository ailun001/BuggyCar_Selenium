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
    public class RankStepDefinitions
    {
        private int[] ranks;
        private int initial;
        private int update;
        private int voteCar;

        [Given(@"the BuggyCars website has multiple buggy cars with votes")]
        public void GivenTheBuggyCarsWebsiteHasMultipleBuggyCarsWithVotes()
        {
            Page.Home.Goto();
            Assert.IsTrue(Browser.WebDriver.Url.Contains("https://buggy.justtestit.org/"));
            Page.Home.Logout();
            Page.Home.SelectOverall();
            Assert.IsTrue(Browser.WebDriver.Url.Contains("https://buggy.justtestit.org/overall"));
        }

        [When(@"I view the buggy cars ranking")]
        public void WhenIViewTheBuggyCarsRanking()
        {
            ranks = Page.Overall.GetRankings();
        }

        [Then(@"the buggy cars should be ranked in descending order based on the total number of votes received")]
        public void ThenTheBuggyCarsShouldBeRankedInDescendingOrderBasedOnTheTotalNumberOfVotesReceived()
        {
            for (int i = 0; i < ranks.Length-1; i++)
            {
                Assert.GreaterOrEqual(ranks[i], ranks[i+1]);
            }
        }

        [Then(@"the buggy cars with the highest number of votes should be ranked at the top")]
        public void ThenTheBuggyCarsWithTheHighestNumberOfVotesShouldBeRankedAtTheTop()
        {
            Assert.GreaterOrEqual(ranks[0], ranks[1]);
        }

        [When(@"I add a new vote to a buggy car")]
        public void WhenIAddANewVoteToABuggyCar(Table table)
        {
            ranks = Page.Overall.GetRankings();
            Page.Home.LoginEnter(table.Rows[0]["username"], table.Rows[0]["password"]);
            Page.Home.SelectLogin();
            voteCar = int.Parse(table.Rows[0]["carRanked"]);
            WebDriverWait wait = new WebDriverWait(Browser.WebDriver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//tbody/tr")));
            initial = int.Parse(Browser.WebDriver.FindElement(By.XPath("/html/body/my-app/div/main/my-overall/div/div/table/tbody/tr[" + voteCar + "]/td[5]")).Text);
            Browser.WebDriver.FindElement(By.XPath("/html/body/my-app/div/main/my-overall/div/div/table/tbody/tr[" + voteCar + "]/td[3]/a")).Click();
            Page.PopularCar.CommentInput("vote for change rank");
            Page.PopularCar.SelectVote();
        }

        [Then(@"the buggy car's total number of votes should increase by one")]
        public void ThenTheBuggyCarsTotalNumberOfVotesShouldIncreaseByOne()
        {
            WebDriverWait wait = new WebDriverWait(Browser.WebDriver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/my-app/div/main/my-model/div/div[1]/div[3]/div[2]/div[2]/p")));
            IWebElement message = Browser.WebDriver.FindElement(By.XPath("/html/body/my-app/div/main/my-model/div/div[1]/div[3]/div[2]/div[2]/p"));
            Assert.True(message.Text.Contains("Thank"));
            IWebElement vote = Browser.WebDriver.FindElement(By.XPath("/html/body/my-app/div/main/my-model/div/div[1]/div[3]/div[2]/div[1]/h4/strong"));
            Assert.AreEqual(initial+1, int.Parse(vote.Text));
        }

        [Then(@"the ranking order should be updated dynamically")]
        public void ThenTheRankingOrderShouldBeUpdatedDynamically()
        {
            Browser.WebDriver.Navigate().Back();
            update = Page.Overall.GetVote(voteCar);
            Assert.AreEqual(initial+1, update);
        }

        [Then(@"the buggy car's new position in the ranking should reflect the change in its total number of votes\.")]
        public void ThenTheBuggyCarsNewPositionInTheRankingShouldReflectTheChangeInItsTotalNumberOfVotes_()
        {
            int updateRank = Page.Overall.GetBuggyCarRank(Browser.WebDriver.FindElement(By.XPath("/html/body/my-app/div/main/my-overall/div/div/table/tbody/tr[" + voteCar + "]/td[3]")).Text);
            Assert.GreaterOrEqual(update, ranks[updateRank]);
        }
    }
}
