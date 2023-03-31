using BuggyCar.Pages;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace BuggyCar
{
    [Binding]
    public class RegisterStepDefinitions
    {
        [Given(@"the user is on the BuggyCars registration page")]
        public void GivenTheUserIsOnTheBuggyCarsRegistrationPage()
        {
            Page.Home.Goto();
            Page.Home.Logout();
            Page.Home.SelectRegister();
            Assert.IsTrue(Browser.WebDriver.Url.Contains("https://buggy.justtestit.org/register"));
        }

        [When(@"the user enters valid (.*), (.*), (.*), (.*), and (.*) in the registration form")]
        public void WhenTheUserEntersValidTesterATestErTesterAndTesterInTheRegistrationForm(string username, string firstName, string lastName, string password, string confirm)
        {
            Page.Register.RegisterInput(username, firstName, lastName, password, confirm);
        }

        [When(@"clicks on the register button")]
        public void WhenClicksOnTheButton()
        {
            Page.Register.RegisterBtn();
        }

        [Then(@"a message should be displayed on the page saying (.*).")]
        public void ThenAMessageShouldBeDisplayedOnThePageSaying(string message)
        {
            Assert.True( Page.Register.MessageSuccess(message));
        }

        [When(@"the user enters invalid (.*), (.*), (.*), (.*), and (.*) in the registration form")]
        public void WhenTheUserEntersInvalidTesterATestErTesterAndTesterInTheRegistrationForm(string username, string firstName, string lastName, string password, string confirm)
        {
            Page.Register.RegisterInput(username, firstName, lastName, password, confirm);
        }


        [Then(@"an error message should be displayed indicating that the password did not conform with policy\.")]
        public void ThenAnErrorMessageShouldBeDisplayedIndicatingThatThePasswordDidNotConformWithPolicy_()
        {
            Assert.True(Page.Register.MessageSuccess("Password did not conform with policy"));
        }
    }
}
