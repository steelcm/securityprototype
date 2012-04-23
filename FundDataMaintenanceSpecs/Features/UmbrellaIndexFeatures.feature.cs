﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.8.1.0
//      SpecFlow Generator Version:1.8.0.0
//      Runtime Version:4.0.30319.225
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace FundDataMaintenanceSpecs.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.8.1.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Umbrella Index Features")]
    public partial class UmbrellaIndexFeaturesFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "UmbrellaIndexFeatures.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Umbrella Index Features", "As an authenticated user of any role\r\nI want to be able to view a list of all umb" +
                    "rellas", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void UmbrellaValuesAreViewableOutline(string value, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Umbrella Values are Viewable Outline", exampleTags);
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
 testRunner.Given("I have navigated to the umbrella index page");
#line 8
 testRunner.Then(string.Format("umbrella {0} are listed on the index page", value));
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Umbrella Values are Viewable Outline")]
        public virtual void UmbrellaValuesAreViewableOutline_UmbrellaValuesAreViewableOutline_Name()
        {
            this.UmbrellaValuesAreViewableOutline("name", ((string[])(null)));
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Umbrella Values are Viewable Outline")]
        public virtual void UmbrellaValuesAreViewableOutline_UmbrellaValuesAreViewableOutline_Code()
        {
            this.UmbrellaValuesAreViewableOutline("code", ((string[])(null)));
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Umbrella Values are Viewable Outline")]
        public virtual void UmbrellaValuesAreViewableOutline_UmbrellaValuesAreViewableOutline_Custodian()
        {
            this.UmbrellaValuesAreViewableOutline("custodian", ((string[])(null)));
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Umbrella Values are Viewable Outline")]
        public virtual void UmbrellaValuesAreViewableOutline_UmbrellaValuesAreViewableOutline_Status()
        {
            this.UmbrellaValuesAreViewableOutline("status", ((string[])(null)));
        }
        
        public virtual void UmbrellaEditScreenIsDisplayedOnUmbrellaSelectionOutline(string name, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Umbrella Edit Screen is displayed on Umbrella Selection Outline", exampleTags);
#line 18
this.ScenarioSetup(scenarioInfo);
#line 19
 testRunner.Given("I have navigated to the umbrella index page");
#line 20
 testRunner.When(string.Format("I select umbrella with name {0}", name));
#line 21
 testRunner.Then(string.Format("the umbrella edit page for {0} is displayed", name));
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Umbrella Edit Screen is displayed on Umbrella Selection Outline")]
        public virtual void UmbrellaEditScreenIsDisplayedOnUmbrellaSelectionOutline_UmbrellaEditScreenIsDisplayedOnUmbrellaSelectionOutline_CapitalInternationalFund()
        {
            this.UmbrellaEditScreenIsDisplayedOnUmbrellaSelectionOutline("Capital International Fund", ((string[])(null)));
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Umbrella Edit Screen is displayed on Umbrella Selection Outline")]
        public virtual void UmbrellaEditScreenIsDisplayedOnUmbrellaSelectionOutline_UmbrellaEditScreenIsDisplayedOnUmbrellaSelectionOutline_CapitalInternationalInstitutionalTrust()
        {
            this.UmbrellaEditScreenIsDisplayedOnUmbrellaSelectionOutline("Capital International Institutional Trust", ((string[])(null)));
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Umbrella Edit Screen is displayed on Umbrella Selection Outline")]
        public virtual void UmbrellaEditScreenIsDisplayedOnUmbrellaSelectionOutline_UmbrellaEditScreenIsDisplayedOnUmbrellaSelectionOutline_CapitalInternationalUKFund()
        {
            this.UmbrellaEditScreenIsDisplayedOnUmbrellaSelectionOutline("Capital International UK Fund", ((string[])(null)));
        }
        
        public virtual void UmbrellaEditSCreenIsDisplayedWithEditableFieldsForAdmin(string name, string field, string editable, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Umbrella Edit SCreen is displayed with editable fields for admin", exampleTags);
#line 29
this.ScenarioSetup(scenarioInfo);
#line 30
 testRunner.Given("I have navigated to the umbrella index page");
#line 31
 testRunner.When(string.Format("I select umbrella with name {0}", name));
#line 32
 testRunner.Then(string.Format("the umbrella edit screen with {0} is displayed and {1}", field, editable));
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Umbrella Edit SCreen is displayed with editable fields for admin")]
        public virtual void UmbrellaEditSCreenIsDisplayedWithEditableFieldsForAdmin_UmbrellaEditSCreenIsDisplayedWithEditableFieldsForAdmin_Variant0()
        {
            this.UmbrellaEditSCreenIsDisplayedWithEditableFieldsForAdmin("Capital International Fund", "Code", "readonly", ((string[])(null)));
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Umbrella Edit SCreen is displayed with editable fields for admin")]
        public virtual void UmbrellaEditSCreenIsDisplayedWithEditableFieldsForAdmin_UmbrellaEditSCreenIsDisplayedWithEditableFieldsForAdmin_Variant1()
        {
            this.UmbrellaEditSCreenIsDisplayedWithEditableFieldsForAdmin("Capital International Fund", "Name", "editable", ((string[])(null)));
        }
        
        public virtual void UmbrellaCustodianIsDisplayedOnUmbrellaSelectionOutline(string name, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Umbrella Custodian is displayed on Umbrella Selection Outline", exampleTags);
#line 41
this.ScenarioSetup(scenarioInfo);
#line 42
 testRunner.Given("I have navigated to the umbrella index page");
#line 43
 testRunner.When(string.Format("I select umbrella with name {0}", name));
#line 44
 testRunner.Then("the umbrella edit page custodian dropown is displayed");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Umbrella Custodian is displayed on Umbrella Selection Outline")]
        public virtual void UmbrellaCustodianIsDisplayedOnUmbrellaSelectionOutline_UmbrellaCustodianIsDisplayedOnUmbrellaSelectionOutline_CapitalInternationalFund()
        {
            this.UmbrellaCustodianIsDisplayedOnUmbrellaSelectionOutline("Capital International Fund", ((string[])(null)));
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Umbrella Custodian is displayed on Umbrella Selection Outline")]
        public virtual void UmbrellaCustodianIsDisplayedOnUmbrellaSelectionOutline_UmbrellaCustodianIsDisplayedOnUmbrellaSelectionOutline_CapitalInternationalInstitutionalTrust()
        {
            this.UmbrellaCustodianIsDisplayedOnUmbrellaSelectionOutline("Capital International Institutional Trust", ((string[])(null)));
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Umbrella Custodian is displayed on Umbrella Selection Outline")]
        public virtual void UmbrellaCustodianIsDisplayedOnUmbrellaSelectionOutline_UmbrellaCustodianIsDisplayedOnUmbrellaSelectionOutline_CapitalInternationalUKFund()
        {
            this.UmbrellaCustodianIsDisplayedOnUmbrellaSelectionOutline("Capital International UK Fund", ((string[])(null)));
        }
    }
}
#pragma warning restore
#endregion