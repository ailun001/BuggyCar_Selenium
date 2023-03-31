using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuggyCar.Pages
{
    public class PopularCar
    {
        [FindsBy(How = How.Id, Using = "comment")]
        private IWebElement comment;

        [FindsBy(How = How.XPath, Using = "/html/body/my-app/div/main/my-model/div/div[1]/div[3]/div[2]/div[2]/div/button")]
        private IWebElement vote;

        public void CommentInput(string text)
        {
            try {
                WebDriverWait wait = new WebDriverWait(Browser.WebDriver, TimeSpan.FromSeconds(5));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("comment")));
                comment.Clear();
                comment.Click();
                comment.SendKeys(text);
            }
            catch(NoSuchElementException ex) {
                Console.WriteLine("The comment input element could not be found: " + ex.Message);
            }
            
        }

        public void SelectVote()
        {
            vote.Click();
        }
    }
}
