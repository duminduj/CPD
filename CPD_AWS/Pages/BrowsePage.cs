using NUnit.Framework;
using OpenQA.Selenium;
using RACGP_AutomationFramework.Base;
using RACGP_AutomationFramework.Extentions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CPD_AWS.Pages
{
    class BrowsePage: BasePage
    {
        //string keyword;
        string _specificReq;
        public BrowsePage(ParallelConfig parallelConfig) : base(parallelConfig)
        {
        }

        IWebElement SearchKeyword => _parallelConfig.CurrentDriver.FindById("search-term-autocomplete");
        IWebElement SpecificReq => _parallelConfig.CurrentDriver.FindByXpath("//*[@id='panel-pecific-requirement-header']/div/span[contains(text(),'Specific requirement')]");
        IWebElement SpecificReqDropDown => _parallelConfig.CurrentDriver.FindById("specific-requirement-select");
        IWebElement SelectSpecificReq => _parallelConfig.CurrentDriver.FindByXpath("//*[@id='menu-']/div/ul/li[text()='"+ _specificReq + "']");
        IWebElement ActivityIDLabel => _parallelConfig.CurrentDriver.FindByXpath("//*[@id='root']//div/h5");
        IWebElement UpdateButton => _parallelConfig.CurrentDriver.FindByXpath("//button/span[contains(text(),'Update')]");
        IWebElement ActivityCriteriaDropDown => _parallelConfig.CurrentDriver.FindById("panel-ctivity-criteria-header");
        IWebElement CpdAccreditedYes => _parallelConfig.CurrentDriver.FindByXpath("//input[@name='cpdaccredited' and @value='yes']");
        IWebElement BlsCourseYes => _parallelConfig.CurrentDriver.FindByXpath("//input[@name='blscourse' and @value='yes']");
        IWebElement EligibleGrantsYes => _parallelConfig.CurrentDriver.FindByXpath("//input[@name='eligibleforgrants' and @value='yes']");

        public string EnterKeyword(string keyword)
        {
            SearchKeyword.SendKeys(keyword);
            UpdateButton.Click();
            return keyword;
        }

        public void VerifyKeywordResults(string _keyword)
        {
            
            double num;
            if(double.TryParse(_keyword, out num))
            {
                string keyword = _keyword.Replace(" ", string.Empty);
                var _activityID = ActivityIDLabel.Text;
                Assert.AreEqual(keyword, _activityID);
            }

            else
            {
                Thread.Sleep(2000);
                IList<IWebElement> activityTitle = _parallelConfig.CurrentDriver.FindElements(By.XPath("//div[@class='MuiGrid-root MuiGrid-container MuiGrid-direction-xs-column MuiGrid-wrap-xs-nowrap MuiGrid-justify-xs-flex-end']//div/h3"));
                IList<IWebElement> providerName = _parallelConfig.CurrentDriver.FindElements(By.XPath("//div[@class='MuiGrid-root MuiGrid-container MuiGrid-wrap-xs-nowrap']//div/p[@class='MuiTypography-root MuiTypography-body1']"));
                
                for(int i = 0; i < activityTitle.Count; i++)
                {
                    var searchTest = activityTitle[i].Text;
                    var foundElement = searchTest.ToUpper().Contains(_keyword.ToUpper());
                    if (!foundElement)
                    {
                        searchTest = providerName[i].Text;
                        foundElement = searchTest.ToUpper().Contains(_keyword.ToUpper());

                        if (!foundElement)
                        {
                            Assert.IsTrue(foundElement);
                            break;
                        }
                    }
                }


            }            

            //{
            //    IList<IWebElement> results = _parallelConfig.CurrentDriver.FindElements(By.XPath("//div[@class='MuiGrid-root MuiGrid-container MuiGrid-direction-xs-column MuiGrid-wrap-xs-nowrap MuiGrid-justify-xs-flex-end']//div/h3"));
            //    //List<string> validations = new List<string>();

            //    foreach (IWebElement newelement in results)
            //    {
            //        //validations.Add(newelement.Text);
            //        String result = newelement.Text;
            //        result.ToUpper().Contains(keyword.ToUpper());
            //        //Assert.IsTrue(result.Contains(keyword));

            //        Assert.IsTrue(result.CaseInsensitiveContains(keyword));

            //    }
        }

        public string SelectSpecificRequirements(string specificRequirement)
        {
            SpecificReq.Click();
            SpecificReqDropDown.Click();
            _specificReq = specificRequirement;
            SelectSpecificReq.Click();
            UpdateButton.Click();
            return _specificReq;
        }

        public void VerifySpecificRequirements(string _specificReq)
        {
            Thread.Sleep(2000);
            IList<IWebElement> resultcount = _parallelConfig.CurrentDriver.FindElements(By.XPath("//div[@class='MuiGrid-root MuiGrid-container MuiGrid-wrap-xs-nowrap']/parent::div"));

            if (resultcount.Count != 0)
            {
                for (int i = 0; i < resultcount.Count; i++)
                {

                    var activitID = resultcount[i].GetAttribute("id");
                    IList<IWebElement> specificrequirements = _parallelConfig.CurrentDriver.FindElements(By.XPath("//*[@id='" + activitID + "']//div[contains(text(),'Specific requirement')]/following-sibling::div"));

                    for (int j = 0; j < specificrequirements.Count; j++)
                    {
                        var specificReq = specificrequirements[j].Text;
                        var foundElement = specificReq.ToUpper().Contains(_specificReq.ToUpper());
                        if (foundElement == true)
                        {
                            break;
                        }
                        //if (!foundElement)
                        //{
                        //    j++;
                        //}

                        if (j == specificrequirements.Count)
                        {
                            Assert.IsTrue(foundElement);
                            break;
                        }

                    }

                }
            }

            else
            {
                return;
            }

           

            //foreach (IWebElement results in specificrequirements)
            //{
            //    //validations.Add(newelement.Text);
            //    String result = results.Text;
            //    result.ToUpper().Contains(_specificReq.ToUpper());
            //    //Assert.IsTrue(result.Contains(keyword));

            //    Assert.IsTrue(result.CaseInsensitiveContains(_specificReq));

            //}
        }

        public string SelectActivityCriteria(string activityCriteria)
        {
            ActivityCriteriaDropDown.Click();
            Thread.Sleep(1500);

            if (activityCriteria == "CPD Accredited activity")
            {
                CpdAccreditedYes.Click();
            }

            else if (activityCriteria == "BLS")
            {
                BlsCourseYes.Click();
            }

            else if (activityCriteria == "Grant eligible")
            {
                EligibleGrantsYes.Click();
            }

            UpdateButton.Click();
            return activityCriteria;
        }

        public void VerifyActivityCriteria(string _activityCriteria)
        {
            IList<IWebElement> resultcount = _parallelConfig.CurrentDriver.FindElements(By.XPath("//div[@class='MuiGrid-root MuiGrid-container MuiGrid-wrap-xs-nowrap']/parent::div"));

            if (resultcount.Count != 0)
            {
                for (int i = 0; i < resultcount.Count; i++)
                {
                    var activitID = resultcount[i].GetAttribute("id");
                    IList<IWebElement> tagscount = _parallelConfig.CurrentDriver.FindElements(By.XPath("//*[@id='" + activitID + "']//div[@class='MuiGrid-root MuiGrid-item']/div"));

                    for (int j = 0; j < tagscount.Count; j++)
                    {
                        var tagtext = tagscount[j].Text;
                        var foundElement = tagtext.ToUpper().Contains(_activityCriteria.ToUpper());

                        if (foundElement)
                        {
                            Assert.IsTrue(foundElement);
                            break;
                        }

                        //else if (!foundElement)
                        //{
                        //    j++;                       
                        //}

                        if (j == tagscount.Count)
                        {
                            Assert.IsTrue(foundElement);
                            break;
                        }


                    }

                }
            }

            else
            {
                return;
            }

            

        }


    }
}
