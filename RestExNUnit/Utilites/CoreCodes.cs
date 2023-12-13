using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using RestSharp;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestExNUnit.Utilites
{
    
    public class CoreCodes
    {
        protected RestClient client;
        protected ExtentReports extent;
        ExtentSparkReporter sparkReporter;
        protected ExtentTest test;



        [OneTimeSetUp]

        public void OneTimeSetup()
        {


            string currentDirectory = Directory.GetParent(@"../../../").FullName;
            extent = new ExtentReports();
            sparkReporter = new ExtentSparkReporter(currentDirectory + "/ExtentReports/extent-report"
                + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".html");

            extent.AttachReporter(sparkReporter);
            string filePath = currentDirectory + "/Logs/log_" + DateTime.Now.ToString("yyyy-mm-dd_HH.mm.ss") + ".txt";

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(filePath, rollingInterval: RollingInterval.Day).CreateLogger();
        }

        [SetUp]
        public void Setup()
        {
            client = new RestClient("https://reqres.in/api");


        }
        [OneTimeTearDown]
        public void TearDown()
        {
            extent.Flush();
        }
    }
}
