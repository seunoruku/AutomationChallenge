using OpenQA.Selenium;

namespace UtilityLayer.WebAppUtilities
{
    public class ControlExtension : Driver
	{

		public void SendKeys(IWebElement element, string value)
		{
			element.SendKeys(value);
			element.SendKeys(Keys.Tab);
		}

		public void ClearAndSendKeys(IWebElement element, string value)
		{
			Clear(element);
			element.SendKeys(value);
			element.SendKeys(Keys.Tab);
		}

		public void Clear(IWebElement element)
		{
			element.Clear();
			element.SendKeys(Keys.Backspace);
		}

		public void ClickOnButton(IWebElement webElement)
		{
			GetActionObj().MoveToElement(webElement).Click().Build().Perform();
		}

		public IWebElement FindElementById(string id)
		{
			return FindElement(By.Id(id));
		}

		public IWebElement FindElementByXpath(string xpath)
		{
			return FindElement(By.XPath(xpath));
		}

		public IEnumerable<IWebElement> FindElementsByXpath(string xpath)
		{
			return FindElements(By.XPath(xpath));
		}

		public IWebElement FindElementByCSSSelector(string cssSelector)
		{
			return FindElement(By.CssSelector(cssSelector));
		}

		public IWebElement FindElement(By locator)
		{
			return DriverInstance.FindElement(locator);
		}

		public IEnumerable <IWebElement> FindElements(By locator)
		{
			return DriverInstance.FindElements(locator);
		}

		public void ExplicitWaitForElement(By locator)
		{
			Func<IWebDriver, bool> waitForElements = new Func<IWebDriver, bool>((IWebDriver Web) =>
			{
				Console.WriteLine(Web.FindElement(locator).GetAttribute("innerHTML"));
				return true;
			});
			Wait.Until(waitForElements);
		}

		public void FocusOnWindow()
        {
			GetJavaScriptExecutor(DriverInstance).ExecuteScript("window.focus();");
        }
	}
}
