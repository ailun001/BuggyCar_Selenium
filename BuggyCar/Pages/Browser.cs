using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuggyCar.Pages
{
    public static class Browser
    {
        static IWebDriver webDriver = new ChromeDriver(@"E:\work\chromeDriver\chromedriver.exe");

        public static IWebDriver WebDriver { get { return webDriver; } }

        public static ISearchContext SearchContext { get { return webDriver; } }

        public static string Title { get { return webDriver.Title; } }

        public static void Goto(string url) { webDriver.Url = url; }

        public static void Quit() { webDriver.Quit(); }

    }
}
