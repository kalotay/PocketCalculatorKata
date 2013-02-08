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
            _calculator.PressAC();
        }
        
        [When(@"I press ""(.*)""")]
        public void WhenIPress(string buttons)
        {
            foreach (var button in buttons.Split(' '))
            {
                switch (button)
                {
                    case "AC":
                        _calculator.PressAC();
                        break;
                    case "=":
                        _calculator.PressEqual();
                        break;
                    case "+":
                        _calculator.PressPlus();
                        break;
                    case "-":
                        _calculator.PressMinus();
                        break;
                    case "*":
                        _calculator.PressStar();
                        break;
                    case "/":
                        _calculator.PressSlash();
                        break;
                    case "+/-":
                        _calculator.PressPlusMinus();
                        break;
                    default:
                        _calculator.PressDigit((Digits)byte.Parse(button));
                        break;
                }
                
            }
        }
        
        [Then(@"the display shows ""(.*)""")]
        public void ThenTheDisplayShows(decimal display)
        {
            Assert.That(_calculator.Display, Is.EqualTo(display));
        }
    }
}
