using ApplicationLayer.Generic;
using System.Reflection;
using TechTalk.SpecFlow;
using TFLAutomationChallenge.Configuration.ConfigHelper;

namespace TFLAutomationChallenge.TestFixtures
{
	[Binding]
	public class SpecflowHooks
	{
		// For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

		[BeforeScenario]
		public static void BeforeScenarioWithTag()
		{
			var baseModule = new BaseModule();
			var config = AppSettingsHelper.GetConfigProperty(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ??
				throw new InvalidOperationException("Path :" + Assembly.GetExecutingAssembly().Location + " Not found"), @"Configuration\CofigFiles\AppSettings.json"));
			baseModule.LaunchApp(config.Browser, config.AppUrl);
		}

		[AfterScenario]
		public static void AfterScenario()
		{
			var baseModule = new BaseModule();
			baseModule.Quit();
		}
	}
}