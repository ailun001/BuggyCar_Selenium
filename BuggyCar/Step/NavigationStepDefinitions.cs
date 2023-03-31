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
    public class NavigationStepDefinitions
    {
        [Given(@"The user is on (.*) of the BuggyCars website")]
        public void GivenTheUserIsOnRegisterOfTheBuggyCarsWebsite(string page)
        {
            switch (page)
            {
                case "Register":
                    Page.Home.Goto();
                    Page.Home.Logout();
                    Page.Home.SelectRegister();
                    Assert.IsTrue(Browser.WebDriver.Url.Contains("https://buggy.justtestit.org/register"));
                    break;
                case "PopularMake":
                    Page.Home.Goto();
                    Page.Home.Logout();
                    Page.Home.SelectPopularMake();
                    Assert.IsTrue(Browser.WebDriver.Url.Contains("https://buggy.justtestit.org/make"));
                    break;
                case "PopularCar":
                    Page.Home.Goto();
                    Page.Home.Logout();
                    Page.Home.SelectPopularCar();
                    Assert.IsTrue(Browser.WebDriver.Url.Contains("https://buggy.justtestit.org/model"));
                    break;
                case "Overall":
                    Page.Home.Goto();
                    Page.Home.Logout();
                    Page.Home.SelectOverall();
                    Assert.IsTrue(Browser.WebDriver.Url.Contains("https://buggy.justtestit.org/overall"));
                    break;
            }
        }

        [When(@"The user clicks on the BuggyCars logo located on the top left corner of the page")]
        public void WhenTheUserClicksOnTheBuggyCarsLogoLocatedOnTheTopLeftCornerOfThePage()
        {
            Browser.WebDriver.FindElement(By.XPath("/html/body/my-app/header/nav/div/a")).Click();
        }

        [Then(@"The user should be redirected to the BuggyCars homepage")]
        public void ThenTheUserShouldBeRedirectedToTheBuggyCarsHomepage()
        {
            Assert.IsTrue(Browser.WebDriver.Url.Contains("https://buggy.justtestit.org/"));
        }

        [Given(@"The user is on the BuggyCars homepage")]
        public void GivenTheUserIsOnTheBuggyCarsHomepage()
        {
            Page.Home.Goto();
            Assert.IsTrue(Browser.WebDriver.Url.Contains("https://buggy.justtestit.org/"));
        }


        [When(@"The user clicks on the (.*) link")]
        public void WhenTheUserClicksOnTheLinkLink(string link)
        {
            switch (link)
            {
                case "Register":
                    Page.Home.SelectRegister();
                    break;
                case "PopularMake":
                    Page.Home.SelectPopularMake();
                    break;
                case "PopularCar":
                    Page.Home.SelectPopularCar();
                    break;
                case "Overall":
                    Page.Home.SelectOverall();
                    break;
            }
        }

        [Then(@"The user should be redirected to the (.*) page")]
        public void ThenTheUserShouldBeRedirectedToTheBuggyCarsRegisterPage(string page)
        {
            switch (page)
            {
                case "Register":
                    Assert.IsTrue(Browser.WebDriver.Url.Contains("https://buggy.justtestit.org/register"));
                    break;
                case "PopularMake":
                    Assert.IsTrue(Browser.WebDriver.Url.Contains("https://buggy.justtestit.org/make"));
                    break;
                case "PopularCar":
                    Assert.IsTrue(Browser.WebDriver.Url.Contains("https://buggy.justtestit.org/model"));
                    break;
                case "Overall":
                    Assert.IsTrue(Browser.WebDriver.Url.Contains("https://buggy.justtestit.org/overall"));
                    break;
            }
        }

        [Given(@"The user is on the BuggyCars overall ranking page or the BuggyCars popular make page")]
        public void GivenTheUserIsOnTheBuggyCarsOverallRankingPageOrTheBuggyCarsPopularMakePage()
        {
            Page.Home.Goto();
            Page.Home.Logout();
            Page.Home.SelectOverall();
            Assert.IsTrue(Browser.WebDriver.Url.Contains("https://buggy.justtestit.org/overall"));
        }

        [When(@"The user checks the list format of the displayed buggy cars")]
        public void WhenTheUserChecksTheListFormatOfTheDisplayedBuggyCars()
        {
            WebDriverWait wait = new WebDriverWait(Browser.WebDriver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//tbody")));
            IWebElement table = Browser.WebDriver.FindElement(By.XPath("/html/body/my-app/div/main/my-overall/div/div/table"));
            Assert.True(table.Displayed);
        }

        [Then(@"The buggy cars should be displayed correctly, with each car represented by a thumbnail image, the car model, and the overall rating")]
        public void ThenTheBuggyCarsShouldBeDisplayedCorrectlyWithEachCarRepresentedByAThumbnailImageTheCarModelAndTheOverallRating()
        {
            IWebElement image = Browser.WebDriver.FindElement(By.XPath("/html/body/my-app/div/main/my-overall/div/div/table/tbody/tr[1]/td[1]/a/img"));
            IWebElement model = Browser.WebDriver.FindElement(By.XPath("/html/body/my-app/div/main/my-overall/div/div/table/tbody/tr[1]/td[3]/a"));
            IWebElement comment = Browser.WebDriver.FindElement(By.XPath("/html/body/my-app/div/main/my-overall/div/div/table/tbody/tr[1]/td[7]"));
            Assert.True(model.Displayed && image.Displayed && comment.Displayed);
        }

        [Then(@"Each buggy car model should be represented by a link to its detail page with the vote page\.")]
        public void ThenEachBuggyCarModelShouldBeRepresentedByALinkToItsDetailPageWithTheVotePage_()
        {
            IWebElement model = Browser.WebDriver.FindElement(By.XPath("/html/body/my-app/div/main/my-overall/div/div/table/tbody/tr[1]/td[3]/a"));
            string href = model.GetAttribute("href");
            Console.WriteLine(href);
            Assert.True(href.Contains("/model/"));
        }


    }
}
