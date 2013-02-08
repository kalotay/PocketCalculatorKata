using System;
using TechTalk.SpecFlow;

namespace PocketCalculator
{
    [Binding]
    public class PocketCalculatorSteps
    {
        [Given(@"I have a pocket calculator")]
        public void GivenIHaveAPocketCalculator()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I press ""(.*)""")]
        public void WhenIPress(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the display shows ""(.*)""")]
        public void ThenTheDisplayShows(Decimal p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
