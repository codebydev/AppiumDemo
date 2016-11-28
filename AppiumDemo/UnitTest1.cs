using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium.MultiTouch;

namespace AppiumDemo
{
    [TestClass]
    public class CalculatorAppTest
    {       
        public IWebDriver driver;
        [TestMethod]
        public void TestCalculator()
        {
            var two = driver.FindElement(By.Name("2"));
            two.Click();
            var plus = driver.FindElement(By.Name("+"));
            plus.Click();
            var four = driver.FindElement(By.Name("4"));
            four.Click();
            var equalTo = driver.FindElement(By.Name("="));
            equalTo.Click();            
            var results = driver.FindElement(By.ClassName("android.widget.EditText"));

            Assert.AreEqual("6", results.Text);            
        }

        [TestInitialize]
        public void BeforeAll()
        {

            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability("device", "Android");
            capabilities.SetCapability(CapabilityType.Platform, "Windows");
            capabilities.SetCapability("deviceName", "50a72b3dcb51");
            capabilities.SetCapability("platformName", "Android");
            capabilities.SetCapability("platformVersion", "4.4.2");
            capabilities.SetCapability("appPackage", "com.android.calculator2");
            capabilities.SetCapability("appActivity", "com.android.calculator2.Calculator");
            
            driver = new RemoteWebDriver(new Uri("http://127.0.0.1:4723/wd/hub"), capabilities, TimeSpan.FromSeconds(180));
        }

        [TestCleanup]
        public void AfterAll()
        {
            driver.Quit();
        }

    }
}
