using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace FundDataMaintenanceSpecs.Definitions.Sign_In
{
    [Binding]
    public class SignInDefinitions
    {
        private static IWebDriver _webDriver;

        [BeforeFeature()]
        public static void BeforeFeature()
        {
            _webDriver = new ChromeDriver();
        }

        [AfterFeature()]
        public static void AfterFeature()
        {
            _webDriver.Quit();
        }

        [Given(@"I am on the sign-in page")]
        public void GivenIAmOnTheSignInPage()
        {
            _webDriver.Navigate().GoToUrl("http://localhost:1571/Session/SignIn");
        }

        [Then(@"the (.*) field is presented")]
        public void ThenTheFieldIsPresented(string fieldName)
        {
            var elems = _webDriver.FindElements(By.Name(fieldName));
            Assert.That(elems.Count(), Is.GreaterThanOrEqualTo(1));
        }

        [When(@"I click the sign-in button")]
        public void WhenIClickTheSignInButton()
        {
            var elem = _webDriver.FindElement(By.CssSelector("button[type=submit]"));
            elem.Click();
        }

        [Then(@"the sign-in page will be displayed with an error")]
        public void ThenTheSignInPageWillBeDisplayedWithAnError()
        {
            var elems = _webDriver.FindElements(By.CssSelector(".validation-summary-errors li"));
            Assert.That(elems.Count(), Is.GreaterThanOrEqualTo(1));
        }

        [Given(@"I incorrectly enter my (.*)")]
        public void GivenIIncorrectlyEnterMy(string fieldname)
        {
            var elems = _webDriver.FindElements(By.Name(fieldname));
            elems.First().SendKeys("Foo");
        }

        [Given(@"I correctly enter my Username"), Given(@"I enter my username")]
        public void GivenICorrectlyEnterMyUsername()
        {
            var elems = _webDriver.FindElements(By.Name("Username"));
            elems.First().SendKeys("CHMS");
        }

        [Given(@"I correctly enter my Password"), Given(@"I enter my password")]
        public void GivenICorrectlyEnterMy()
        {
            var elems = _webDriver.FindElements(By.Name("Password"));
            elems.First().SendKeys("oupork06");
        }

    }
}
