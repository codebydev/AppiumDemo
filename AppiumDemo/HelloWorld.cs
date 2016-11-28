using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppiumDemo
{
    [TestClass]
    public class HelloWorld
    {
        public AndroidDriver<IWebElement> driver;
        [TestMethod]
        public void TestMobile()
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
            TouchActions ta = new TouchActions(driver);
            
            Assert.AreEqual("6", results.Text);
        }

        
        [TestMethod]
        public void TestBrowser()
        {
            driver.FindElement(By.Id("lst-ib")).SendKeys(".Net bangalore meetup");
        }
        [TestInitialize]
        public void BeforeAll()
        {
            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability("device", "Android");
            capabilities.SetCapability(CapabilityType.Platform, "Windows");
            //capabilities.SetCapability("deviceName", "emulator-5554");
            capabilities.SetCapability("deviceName", "Y5Z5KVIFIFQG5S6H");
            capabilities.SetCapability("platformName", "Android");
            capabilities.SetCapability("platformVersion", "5.0.2");
           // capabilities.SetCapability("appPackage", "com.android.calculator2");
           // capabilities.SetCapability("appActivity", "com.android.calculator2.Calculator");
            capabilities.SetCapability(CapabilityType.BrowserName, "Chrome");

            driver = new AndroidDriver<IWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), capabilities, TimeSpan.FromSeconds(180));
            driver.Url = "http://google.com";
        }

        [TestCleanup]
        public void AfterAll()
        {
            driver.Quit();
        }
    }
}
