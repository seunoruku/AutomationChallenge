using ApplicationLayer.Generic;
using System;
using TechTalk.SpecFlow;

namespace TFLAutomationChallenge.Steps
{
    [Binding]
    public class PlanJourneySteps
    {
        [Given(@"I am on tfl search journey page")]
        public void GivenIAmOnTflSearchJourneyPage()
        {
            App.TflWebApp.SearchJourney.EnterText("London Bridge", "North Greenwich");
        }

        [Given(@"I am on tfl search journey page with journey ""([^""]*)"" to ""([^""]*)""")]
        public void GivenIAmOnTflSearchJourneyPageWithJourneyTo(string from, string to)
        {
            App.TflWebApp.SearchJourney.EnterText(from, to);
        }

        [Given(@"I search for a journey")]
        [When(@"I search for a journey")]
        public void WhenISearchForAJourney()
        {
            App.TflWebApp.SearchJourney.ClickPlanJourneyButton();
        }

        [When(@"I choose to view my recent journeys")]
        public void WhenIChooseToViewMyRecentJourneys()
        {
            App.TflWebApp.SearchJourney.ClickRecentPlannedJourneyButton();
        }

        [When(@"I choose to edit my journey with ""([^""]*)"" to ""([^""]*)""")]
        public void WhenIChooseToEditMyJourneyWithTo(string from, string to)
        {
            App.TflWebApp.SearchJourney.EditJourney(from, to);
        }

        
        [Then(@"the system should display the (.*)")]
        public void ThenTheSystemShouldDisplayTheJourneyresults(string expectedData)
        {
            App.TflWebApp.SearchJourney.VerifyReturnedJourney(expectedData);
        }

        [Then(@"the system should return the ""([^""]*)""")]
        public void ThenTheSystemShouldReturnThe(string expectedData)
        {
            App.TflWebApp.SearchJourney.VerifyFastestJourney(expectedData);
        }


        [Then(@"the system should display error message ""([^""]*)""")]
        public void ThenTheSystemShouldDisplayErrorMessage(string expectedData)
        {
            App.TflWebApp.SearchJourney.VerifyInfoMessage(expectedData);
        }

        [Then(@"the from field should return error message ""([^""]*)""")]
        public void ThenTheFromFieldShouldReturnErrorMessage(string expectedErrorMessage)
        {
            App.TflWebApp.SearchJourney.VerifyFromErrorMessage(expectedErrorMessage);
        }

        [Then(@"the to field should return error message ""([^""]*)""")]
        public void ThenTheToFieldShouldReturnErrorMessage(string expectedErrorMessage)
        {
            App.TflWebApp.SearchJourney.VerifyToErrorMessage(expectedErrorMessage);
        }

        [Then(@"the recent journey should contain ""([^""]*)"" to ""([^""]*)""")]
        public void ThenTheRecentJourneyShouldContainTo(string recentFrom, string recentTo)
        {
            App.TflWebApp.SearchJourney.VerifyRecentJourneyData(recentFrom, recentTo);
        }

        [Then(@"the journey should contain ""([^""]*)"" to ""([^""]*)""")]

        [Then(@"the amended journey should contain ""([^""]*)"" to ""([^""]*)""")]
        public void ThenTheAmendedJourneyShouldContainTo(string from, string to)
        {
            App.TflWebApp.SearchJourney.VerifyFromAndToData(from, to);
        }

    }
}
