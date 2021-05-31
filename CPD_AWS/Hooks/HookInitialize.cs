using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium.Remote;
using RACGP_AutomationFramework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
//[assembly:Parallelizable(ParallelScope.Fixtures)]

namespace CPD
{
    [Binding]
    public class HookInitialize:TestInitializeHooks
    {

        //public HookInitialize():base(BrowserType.Chrome)
        //{
        //    InitializeSettings();

        //}
       
        private readonly ParallelConfig _parallelConfig;
        private readonly ScenarioContext _scenarioContext;
        private readonly FeatureContext _featureContext;
        private static ExtentTest featureName;

            

        private ExtentTest _currentScenarioName;
        
        private static AventStack.ExtentReports.ExtentReports extentReports;
        private static ExtentHtmlReporter extentHtmlReporter;
        //private static ExtentKlovReporter klov;
        //private ExtentTest _currentScenarioName;

        public HookInitialize(ParallelConfig parallelConfig, FeatureContext featureContext, ScenarioContext scenarioContext) : base(parallelConfig)
        {
            _parallelConfig = parallelConfig;
            _scenarioContext = scenarioContext;
            _featureContext = featureContext;
        }


        [BeforeTestRun]
        public static void InitializeReport()
        {
            //extentHtmlReporter = new ExtentHtmlReporter(@"C:\Git\Git\Repo\RACGPCPDAWSTests\ui-tests\src\RACGP.CPD\CPD_AWS\TestResults\TestResults.html");
            extentHtmlReporter = new ExtentHtmlReporter(@"C:\Git\Git\Repo\RACGPCPDAWSTests\ui-tests\src\RACGP.CPD\CPD_AWS\TestResults\" + "Automation_Report" + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + @"\ExtentReport.html");
            extentReports = new AventStack.ExtentReports.ExtentReports();
            extentReports.AttachReporter(extentHtmlReporter);

            ////klove repoerting for history data
            //klov = new ExtentKlovReporter();

            //klov.InitMongoDbConnection("localhost", 27017);
            //klov.ProjectName = "CPDAWS";
            //klov.ReportName = "CPDAWS_Test" + DateTime.Now.ToString();
        }


        [AfterTestRun]
        public static void TearDownReport()
        {
            extentReports.Flush();
            // _currentDriver.Close();
        }


        //[BeforeFeature]
        //public static void Beforefeature()
        //{
        //    featureName = extentReports.CreateTest<Feature>(extentReports.FeatureInfo.Title);


        //}

        //[BeforeFeature]
        //public static void BeforeFeature(FeatureContext featureContext)
        //{
        //    //featureName = extentReports.CreateTest<Feature>(_featureContext.FeatureInfo.Title);

        //    if (null != featureContext)
        //    {

        //        featureName = extentReports.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        //    }
        //}


        [AfterStep]
        public void InsertReportingSteps()
        {
            ScenarioBlock scenarioBlock = _scenarioContext.CurrentScenarioBlock;

            switch (scenarioBlock)
            {
                case ScenarioBlock.Given:
                    if (_scenarioContext.TestError != null)
                    {
                        var mediaEntity = _parallelConfig.CaptureScreenshot(_scenarioContext.ScenarioInfo.Title.Trim());

                        _currentScenarioName.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text).Fail
                            (_scenarioContext.TestError.Message + "\n" +
                            _scenarioContext.TestError.StackTrace, mediaEntity);
                    }

                    else if (_scenarioContext.ScenarioExecutionStatus.ToString() == "StepDefinitionPending")
                    {
                        _currentScenarioName.CreateNode<Given>(ScenarioContext.StepContext.StepInfo.Text).Skip("Step Definition Pending");
                    }

                    else 
                    {
                        _currentScenarioName.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text);
                    }
                    
                    break;

                case ScenarioBlock.When:
                    if (_scenarioContext.TestError != null)
                    {
                        var mediaEntity = _parallelConfig.CaptureScreenshot(_scenarioContext.ScenarioInfo.Title.Trim());

                        _currentScenarioName.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message + "\n" +
                            _scenarioContext.TestError.StackTrace,mediaEntity);
                    }

                    else if (_scenarioContext.ScenarioExecutionStatus.ToString() == "StepDefinitionPending")
                    {
                        _currentScenarioName.CreateNode<When>(ScenarioContext.StepContext.StepInfo.Text).Skip("Step Definition Pending");
                    }

                    else
                    {
                        _currentScenarioName.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text);
                    }
                    
                    break;
                    
                case ScenarioBlock.Then:
                    if (_scenarioContext.TestError != null)
                    {
                        var mediaEntity = _parallelConfig.CaptureScreenshot(_scenarioContext.ScenarioInfo.Title.Trim());

                        _currentScenarioName.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message + "\n" +
                            _scenarioContext.TestError.StackTrace, mediaEntity);
                    }

                    else if (_scenarioContext.ScenarioExecutionStatus.ToString() == "StepDefinitionPending")
                    {
                        _currentScenarioName.CreateNode<Then>(ScenarioContext.StepContext.StepInfo.Text).Skip("Step Definition Pending");
                    }

                    else
                    {
                        _currentScenarioName.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text);
                    }
                    break;

                default:
                    if (_scenarioContext.TestError != null)
                    {
                        var mediaEntity = _parallelConfig.CaptureScreenshot(_scenarioContext.ScenarioInfo.Title.Trim());

                        _currentScenarioName.CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message + "\n" +
                            _scenarioContext.TestError.StackTrace, mediaEntity);
                    }
                    else if (_scenarioContext.ScenarioExecutionStatus.ToString() == "StepDefinitionPending")
                    {
                        _currentScenarioName.CreateNode<And>(ScenarioContext.StepContext.StepInfo.Text).Skip("Step Definition Pending");
                    }

                    else
                    {
                        _currentScenarioName.CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text);
                    }
                    break;

            }
        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            InitializeSettings();
            if (null != scenarioContext)
            {
                // _scenarioContext = scenarioContext;
                featureName = extentReports.CreateTest<Feature>(_featureContext.FeatureInfo.Title);
                
                _currentScenarioName = featureName.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
                //_currentScenarioName = featureName.CreateNode<ScenarioOutline>(scenarioContext.ScenarioInfo.Title);
                
            }

        }



        [AfterScenario]
        public void AfterScenario()
        {
            _parallelConfig.CurrentDriver.Quit();
            
            //Thread.Sleep(2000);
        }
    }
}
