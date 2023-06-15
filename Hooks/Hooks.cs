using System;
using TechTalk.SpecFlow;

namespace BuggyCar.Test.Hooks
{
	[Binding]
	public sealed class Hooks
	{


		[BeforeScenario]
		public void BeforeScenario()
		{
			
		}

		[AfterScenario]
		public void AfterScenario()
		{
			Console.WriteLine("Running after scenario...");

			
		}

		[AfterTestRun]
		public static void AfterTestRun() 
		{
			Console.WriteLine("Running after test...");

			Driver.WebDriver.Quit();
		}
	}
}
