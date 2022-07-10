using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace UtilityLayer.WebAppUtilities
{
    public class Driver
	{
		public static WebDriver DriverInstance { get; set; }
		public static Actions Action { get; set; }
		public static WebDriverWait Wait { get; set; }

		public void InitializeDriver(string driverpath, string browser)
		{
			if (DriverInstance == null)
			{
				if (browser.ToLower().Equals("chrome"))
				{
					var chromeOptions = new ChromeOptions();
					DriverInstance = new ChromeDriver(driverpath, chromeOptions);
				}
			}
			Wait = new WebDriverWait(DriverInstance, new TimeSpan(0, 1, 0));
			DriverInstance?.Manage().Window.Maximize();
		}

		public void NavigateToURL(string url)
		{
			DriverInstance.Navigate().GoToUrl (url);
		}

		public Actions GetActionObj()
		{
			if (Action == null) Action = new Actions(DriverInstance);
			return Action;
		}

		public void Quit()
		{
			DriverInstance.Quit();
		}

		public IJavaScriptExecutor GetJavaScriptExecutor(IWebDriver jsDriver)
		{
			return (IJavaScriptExecutor)jsDriver;
		}

		public void Refresh()
		{
			DriverInstance.Navigate().Refresh();
		}
	}
}
