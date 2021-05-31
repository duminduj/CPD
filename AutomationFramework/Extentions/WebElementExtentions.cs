using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using RACGP_AutomationFramework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RACGP_AutomationFramework.Extentions
{
    public static class WebElementExtentions
    {
        public static IList<IWebElement> GetSelectedListOptons(this IWebElement element)
        {
            
            SelectElement listOptions = new SelectElement(element);
            return listOptions.AllSelectedOptions;
        }
        public static void SelectDropDownList(this IWebElement element,string value)
        {
            SelectElement ddl = new SelectElement(element);
            ddl.SelectByText(value);
        }

        public static string GetLinkText(this IWebElement  element)
        {
            return element.Text;
        }

        //public static void Hover(this IWebElement element)
        //{
        //    Actions actions = new Actions(DriverContext.CurrentDriver);
        //    actions.MoveToElement(element).Perform();
        //}

        public static void AssertElementPresent(this IWebElement element)
        {
            if (!IsElementPresent(element))
                throw new Exception(string.Format("Element not present exception"));
        }

        public static bool IsElementPresent(this IWebElement element)
        {
            
            try
            {
                bool ele = element.Displayed;
                return true;
                    
            }
            catch (Exception)
            {
                return false;
            }
        }

       public static bool CaseInsensitiveContains(this string text, string value)
        {
            return text.Contains(value, StringComparison.CurrentCultureIgnoreCase);
        }
               

        

    }
}
