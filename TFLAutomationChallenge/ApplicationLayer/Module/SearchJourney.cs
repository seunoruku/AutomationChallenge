using ApplicationLayer.Generic;
using OpenQA.Selenium;
using Shouldly;

namespace ApplicationLayer.Module
{
    public class SearchJourney : BaseModule
	{
		private string InputFrom = "InputFrom";
		private string InputTo = "InputTo";
		private string PlanJourneyButton = "plan-journey-button";
		private string InputFromError = "#InputFrom-error";
		private string InputToError = "#InputTo-error";
		private string InfoErrorMessage = "#full-width-content > div > div:nth-child(8) > div > div > ul > li";
		private string AcceptCookiesButton = "CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll";
		private string EndCookiButton = "#cb-buttons [onclick='endCookieProcess(); return false;']";
		private string FastestJourney = "#full-width-content > div > div:nth-child(8) > div > div > div.journey-results.publictransport.no-map > h2";
		private string RecentPlannedJourneyButton = "//*[@id='full-width-content']/div/div[1]/div/ol/li[2]/a";
		private string JourneyResultLabel = ".jp-results-headline";
		private string RecentFromJourneyLabel = "# jp-recent-content-jp- > a:nth-child(1)";
		private string RecentToJourneyLabel = "# jp-recent-content-jp- > a:nth-child(2)";
		private string EditJourneyLink = "//*[@id='plan-a-journey']/div[1]/div[3]/a/span";
		private string ClearFromField = "//*[@id='search-filter-form-0']/div/div/a";
		private string ClearToField = "//*[@id='search-filter-form-1']/div/a";
		private string FromLabel = "//*[@id='plan-a-journey']/div[1]/div[1]/div[1]/span[2]/strong";
		private string ToLabel = "//*[@id='plan-a-journey']/div[1]/div[1]/div[2]/span[2]/strong";

		public void EnterText(string from, string to)
		{
			Controls?.FocusOnWindow();
			Controls?.ClickOnButton(Controls.FindElementById(AcceptCookiesButton));
			Controls?.FocusOnWindow();
			Controls?.ExplicitWaitForElement(By.CssSelector(EndCookiButton));
			Controls?.ClickOnButton(Controls.FindElementByCSSSelector(EndCookiButton));
			Controls?.ExplicitWaitForElement(By.Id(InputFrom));
			Controls?.ClearAndSendKeys(Controls.FindElementById(InputFrom), from);
			Controls?.ExplicitWaitForElement(By.Id(InputTo));
			Controls?.ClearAndSendKeys(Controls.FindElementById(InputTo), to);
		}

		public void ClickPlanJourneyButton()
        {
			Controls?.ClickOnButton(Controls.FindElementById(PlanJourneyButton));
        }

		public void ClickRecentPlannedJourneyButton()
		{
			Controls?.ClickOnButton(Controls.FindElementByXpath(RecentPlannedJourneyButton));
		}

		public void EditJourney(string from, string to)
		{
			Controls?.ClickOnButton(Controls.FindElementByXpath(EditJourneyLink));
			Controls?.ExplicitWaitForElement(By.Id(InputFrom));
			Controls?.ClickOnButton(Controls.FindElementByXpath(ClearFromField));
			Controls?.ClearAndSendKeys(Controls.FindElementById(InputFrom), from);
			Controls?.ExplicitWaitForElement(By.Id(InputTo));
			Controls?.ClickOnButton(Controls.FindElementByXpath(ClearToField));
			Controls?.ClearAndSendKeys(Controls.FindElementById(InputTo), to);
			ClickPlanJourneyButton();
		}

		public void VerifyReturnedJourney(string expectedHeader)
        {
			var data = Controls?.FindElementByCSSSelector(JourneyResultLabel);
			data.Text.Equals(expectedHeader).ShouldBeTrue();
		}

		public void VerifyFastestJourney(string expectedHeader)
		{
			var data = Controls?.FindElementByCSSSelector(FastestJourney);
			data.Text.Equals(expectedHeader).ShouldBeTrue();
		}

		public void VerifyInfoMessage(string expectedJourneyInformation)
        {
			var data = Controls?.FindElementByCSSSelector(InfoErrorMessage);
			data?.Text.Equals(expectedJourneyInformation).ShouldBeTrue();
		}

		public void VerifyFromErrorMessage(string expectedJourneyInformation)
		{
			Controls?.ExplicitWaitForElement(By.CssSelector(InputFromError));
			var data = Controls?.FindElementByCSSSelector(InputFromError);
			data?.Text.Equals(expectedJourneyInformation).ShouldBeTrue();
		}

		public void VerifyToErrorMessage(string expectedJourneyInformation)
		{
			Controls?.ExplicitWaitForElement(By.CssSelector(InputToError));
			var data = Controls?.FindElementByCSSSelector(InputToError);
			data?.Text.Equals(expectedJourneyInformation).ShouldBeTrue();
		}

		public void VerifyRecentJourneyData(string expectedRecentFrom, string expectedRecentTo)
		{
			var fromData = Controls?.FindElementByCSSSelector(RecentFromJourneyLabel);
			var toData = Controls?.FindElementByCSSSelector(RecentToJourneyLabel);
			fromData?.Text.Contains(expectedRecentFrom).ShouldBeTrue();
			toData?.Text.Contains(expectedRecentTo).ShouldBeTrue();
		}

		public void VerifyFromAndToData(string expectedFrom, string expectedTo)
		{
			var fromData = Controls?.FindElementByXpath(FromLabel);
			var toData = Controls?.FindElementByXpath(ToLabel);
			fromData?.Text.Contains(expectedFrom).ShouldBeTrue();
			toData?.Text.Contains(expectedTo).ShouldBeTrue();
		}
	}
}
