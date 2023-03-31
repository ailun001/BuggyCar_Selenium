using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuggyCar.Pages
{
    public class Page
    {
        public static Home Home
        {
            get
            {
                var home = new Home();
                PageFactory.InitElements(Browser.SearchContext, home);
                return home;
            }
        }

        public static Register Register
        {
            get
            {
                var register = new Register();
                PageFactory.InitElements(Browser.SearchContext, register);
                return register;
            }
        }

        public static PopularCar PopularCar
        {
            get
            {
                var popularCar = new PopularCar();
                PageFactory.InitElements(Browser.SearchContext, popularCar);
                return popularCar;
            }
        }

        public static Overall Overall
        {
            get
            {
                var rank = new Overall();
                PageFactory.InitElements(Browser.SearchContext, rank);
                return rank;
            }
        }
    }
}
