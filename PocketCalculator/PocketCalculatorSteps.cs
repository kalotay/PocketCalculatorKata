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

        [Given(@"it is turned on")]
        public void GivenItIsTurnedOn()
        {
            _calculator.TurnOn();
        }
        
        [When(@"I press ""(.*)""")]
        public void WhenIPress(string button)
        {
            switch (button)
            {
                case "AC":
                    _calculator.TurnOn();
                    break;
                case "1":
                    _calculator.PressOne();
                    break;
            }
        }
        
        [Then(@"the display shows ""(.*)""")]
        public void ThenTheDisplayShows(Decimal display)
        {
            Assert.That(_calculator.Display, Is.EqualTo(display));
        }
    }
}
