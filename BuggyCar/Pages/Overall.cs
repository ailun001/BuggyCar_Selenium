using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Constraints;

namespace BuggyCar.Pages
{
    public class Overall
    {
        public int[] GetRankings()
        {
            int[] ranking = new int[6];
            WebDriverWait wait = new WebDriverWait(Browser.WebDriver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/my-app/div/main/my-overall/div/div/table/tbody/tr[1]/td[3]/a")));
            for (int i = 1; i <= 5; i++)
            {
                IWebElement vote = Browser.WebDriver.FindElement(By.XPath("/html/body/my-app/div/main/my-overall/div/div/table/tbody/tr[" + i + "]/td[5]"));
                ranking[i-1] = int.Parse(vote.Text);
            }
            return ranking;
        }

        public int GetVote(int id)
        {
            WebDriverWait wait = new WebDriverWait(Browser.WebDriver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/my-app/div/main/my-overall/div/div/table/tbody/tr[" + id + "]/td[5]")));
            IWebElement vote = Browser.WebDriver.FindElement(By.XPath("/html/body/my-app/div/main/my-overall/div/div/table/tbody/tr[" + id + "]/td[5]"));
            return int.Parse(vote.Text);
        }

        public int GetBuggyCarRank(string carName)
        {
            WebDriverWait wait = new WebDriverWait(Browser.WebDriver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/my-app/div/main/my-overall/div/div/table/tbody/tr[1]/td[3]/a")));
            for (int i = 1; i <= 5; i++)
            {
                IWebElement model = Browser.WebDriver.FindElement(By.XPath("/html/body/my-app/div/main/my-overall/div/div/table/tbody/tr[" + i + "]/td[3]/a"));
                Console.WriteLine(model.Text);
                Console.WriteLine(carName);
                if ( carName ==  model.Text )return i-1;
            }
            return -1;
        }
    }
}
