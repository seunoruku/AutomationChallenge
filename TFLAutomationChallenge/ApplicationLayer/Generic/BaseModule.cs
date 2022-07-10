using System.Reflection;
using UtilityLayer.WebAppUtilities;

namespace ApplicationLayer.Generic
{
    public class BaseModule : TestDataContext
	{
		private string _signIn = "hdhehjej";

		public BaseModule()
		{
			Controls = new ControlExtension();
		}

		public void LaunchApp(string browser, string appUrl)
		{
	//		Controls.Quit();
			Controls?.InitializeDriver(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? 
				throw new InvalidOperationException("Path :" + Assembly.GetExecutingAssembly().Location + "Not found"), @"Drivers"), browser);
			Controls?.NavigateToURL(appUrl);
		}

		public void Quit()
		{
			Controls?.Quit();
		}


	}
}
