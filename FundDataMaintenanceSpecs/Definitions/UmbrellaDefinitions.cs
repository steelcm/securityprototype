using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using TechTalk.SpecFlow;

namespace FundDataMaintenanceSpecs.Definitions
{
    [Binding]
    class UmbrellaDefinitions
    {
        private static IWebDriver _webDriver;

        [BeforeFeature()]
        public static void BeforeFeature()
        {
            _webDriver = new ChromeDriver();
        }

        [BeforeScenario()]
        public void BeforeScenario()
        {
            _webDriver.Navigate().GoToUrl("http://localhost:1571/");
        }

        [AfterFeature()]
        public static void AfterFeature()
        {
            _webDriver.Quit();
        }

        [Given(@"I have navigated to the umbrella index page")]
        public void GivenIHaveNavigatedToTheUmbrellaIndexPage()
        {
            _webDriver.Navigate().GoToUrl("http://localhost:1571/");
        }

        [Then(@"umbrella (.*) are listed on the index page")]
        public void ThenUmbrellaNamesAreListedOnTheIndexPage(string value)
        {
            var elem = _webDriver.FindElements(By.ClassName("elem-"+value.ToLower())).Where(o => o.Text.Length > 0);
            Assert.That(elem.Count(), Is.GreaterThan(0));
        }

        [When(@"I select umbrella with name (.*)")]
        public void WhenISelectUmbrellaWithName(string name)
        {
            var elem = _webDriver.FindElements(By.ClassName("elem-name")).Where(o => o.Text.Equals(name)).First();
            elem.Click();
        }

        [Then(@"the umbrella edit page for (.*) is displayed")]
        public void ThenTheUmbrellaEditPageIsDisplayed(string name)
        {
            var elem = _webDriver.FindElement(By.Name("Name"));
            Assert.That(elem.GetAttribute("Value"), Is.StringMatching(name));
        }

        [Then(@"the umbrella edit page custodian dropown is displayed")]
        public void ThenTheUmbrellaEditPageCustodianDropownIsDisplayed()
        {
            var elem = _webDriver.FindElement(By.Name("CustodianId"));
            Assert.That(elem.TagName.ToLower(), Is.StringMatching("select"));
        }

        [Then(@"the umbrella edit screen with (.*) is displayed and readonly")]
        public void ThenTheUmbrellaEditScreenWithCodeIsDisplayedAndReadonly(string fieldName)
        {
            var elem = _webDriver.FindElement(By.Name("CustodianId"));
            var startingValue = elem.GetAttribute("Value");
            var proposedEndValue = "FooBa";
            elem.SendKeys(proposedEndValue);
            var endingValue = elem.GetAttribute("Value");
            Assert.That(startingValue, Is.EqualTo(endingValue));
        }


    }
}
