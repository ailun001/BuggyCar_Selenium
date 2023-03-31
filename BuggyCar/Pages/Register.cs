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
    public class Register
    {
        [FindsBy(How = How.Id, Using = "username")]
        private IWebElement username;

        [FindsBy(How = How.Id, Using = "firstName")]
        private IWebElement firstName;

        [FindsBy(How = How.Id, Using = "lastName")]
        private IWebElement lastName;

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement password;

        [FindsBy(How = How.Id, Using = "confirmPassword")]
        private IWebElement confirmPassword;

        [FindsBy(How = How.XPath, Using = "/html/body/my-app/div/main/my-register/div/div/form/button")]
        private IWebElement btn;

        [FindsBy(How = How.XPath, Using = "/html/body/my-app/div/main/my-register/div/div/form/div[6]")]
        private IWebElement message;

        public void RegisterInput(string username,  string firstName, string lastName, string password, string confirm)
        {
            WebDriverWait wait = new WebDriverWait(Browser.WebDriver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("username")));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("firstName")));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("lastName")));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("password")));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("confirmPassword")));
            this.username.Clear();
            this.firstName.Clear();
            this.lastName.Clear();
            this.password.Clear();
            this.confirmPassword.Clear();
            this.username.Click();
            this.username.SendKeys(username);
            this.firstName.Click();
            this.firstName.SendKeys(firstName);
            this.lastName.Click();
            this.lastName.SendKeys(lastName);
            this.password.Click();
            this.password.SendKeys(password);
            this.confirmPassword.Click();
            this.confirmPassword.SendKeys(confirm);
        }

        public void RegisterBtn()
        {
            btn.Click();
        }

        public bool MessageSuccess(string message)
        {
            WebDriverWait wait = new WebDriverWait(Browser.WebDriver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/my-app/div/main/my-register/div/div/form/div[6]")));
            return this.message.Text.Contains(message);
        }
    }
}
