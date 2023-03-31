using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace BuggyCar.Pages
{
    public class Home
    {
        static string url = "https://buggy.justtestit.org/";

        [FindsBy(How = How.XPath, Using = "/html/body/my-app/header/nav/div/my-login/div/form/button")]
        private IWebElement login;

        [FindsBy(How = How.LinkText, Using = "Register")]
        private IWebElement register;

        [FindsBy(How = How.LinkText, Using = "Logout")]
        private IWebElement logout;

        [FindsBy(How = How.XPath, Using = "/html/body/my-app/div/main/my-home/div/div[1]/div/a")]
        private IWebElement popularMake;

        [FindsBy(How = How.XPath, Using = "/html/body/my-app/div/main/my-home/div/div[2]/div/a")]
        private IWebElement popularCar;

        [FindsBy(How = How.XPath, Using = "/html/body/my-app/div/main/my-home/div/div[3]/div/a")]
        private IWebElement overall;

        [FindsBy(How = How.Name, Using = "login")]
        private IWebElement loginInput;

        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement passwordInput;


        public void SelectLogin()
        {
            WebDriverWait wait = new WebDriverWait(Browser.WebDriver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/my-app/header/nav/div/my-login/div/form/button")));
            login.Click();
        }

        public void SelectRegister()
        {
            WebDriverWait wait = new WebDriverWait(Browser.WebDriver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Register")));
            register.Click();
        }

        public void SelectLogout()
        {
            WebDriverWait wait = new WebDriverWait(Browser.WebDriver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Logout")));
            logout.Click();
        }

        public void SelectPopularMake()
        {
            WebDriverWait wait = new WebDriverWait(Browser.WebDriver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/my-app/div/main/my-home/div/div[1]/div/a")));
            popularMake.Click();
        }

        public void SelectPopularCar()
        {
            WebDriverWait wait = new WebDriverWait(Browser.WebDriver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/my-app/div/main/my-home/div/div[2]/div/a")));
            popularCar.Click();
        }

        public void SelectOverall()
        {
            WebDriverWait wait = new WebDriverWait(Browser.WebDriver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/my-app/div/main/my-home/div/div[3]/div/a")));
            overall.Click();
        }

        public void Goto() { Browser.Goto(url); }

        public void Logout()
        {
            try
            {
                logout.Click();
            }catch (NoSuchElementException) 
            {
                Console.WriteLine("Logout link not found");
            }
        }

        public void LoginEnter(string username, string password) 
        {
            WebDriverWait wait = new WebDriverWait(Browser.WebDriver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Name("login")));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Name("password")));
            this.loginInput.Clear();
            this.passwordInput.Clear();
            this.loginInput.Click();
            this.loginInput.SendKeys(username);
            this.passwordInput.Click();
            this.passwordInput.SendKeys(password);
        }

    }
}
