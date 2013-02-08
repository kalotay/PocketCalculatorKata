using System;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace PocketCalculator
{
    [Binding]
    public class PocketCalculatorSteps
    {
        private CasioCalculator _calculator;

        [Given(@"I have a pocket calculator")]
        public void GivenIHaveAPocketCalculator()
        {
            _calculator = new CasioCalculator();
        }
        
        [When(@"I press ""(.*)""")]
        public void WhenIPress(string button)
        {
            _calculator.TurnOn();
        }
        
        [Then(@"the display shows ""(.*)""")]
        public void ThenTheDisplayShows(Decimal display)
        {
            Assert.That(_calculator.Display, Is.EqualTo(display));
        }
    }

    public class CasioCalculator
    {
        public decimal Display { get; private set; }

        public void TurnOn()
        {
            Display = 0m;
        }
    }
}
