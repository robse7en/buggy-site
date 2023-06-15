using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace BuggyCar.Test
{
	public static class Driver
	{
		static IWebDriver webDriver = new ChromeDriver();
		public static IWebDriver WebDriver { get { return webDriver; } }
		public static ISearchContext SearchContext { get { return webDriver; } }
		public static void Goto(string url) => webDriver.Url = url;
		public static void Quit() => webDriver.Quit();
		public static WebDriverWait Wait() { return new WebDriverWait(webDriver, TimeSpan.FromSeconds(5)); }

	}
}
