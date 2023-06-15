using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;

namespace BuggyCar.Test.PageObjects
{
	public class HomePage : BasePage
	{
		[FindsBy(How = How.LinkText, Using = "Register")]
		private IWebElement register;

		[FindsBy(How = How.XPath, Using = "/html/body/my-app/div/main/my-home/div/div[1]/div/a")]
		private IWebElement popularMake;

		[FindsBy(How = How.XPath, Using = "/html/body/my-app/div/main/my-home/div/div[2]/div/a")]
		private IWebElement popularCar;

		[FindsBy(How = How.XPath, Using = "/html/body/my-app/div/main/my-home/div/div[3]/div/a")]
		private IWebElement overall;

		[FindsBy(How = How.XPath, Using = "//my-home")]
		private IWebElement homeSection;

		public void GoToRegister()
		{
			WebDriverWait wait = new WebDriverWait(Driver.WebDriver, TimeSpan.FromSeconds(5));
			wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Register")));
			register.Click();
		}

		public void GoToPopularMake()
		{
			WebDriverWait wait = new WebDriverWait(Driver.WebDriver, TimeSpan.FromSeconds(5));
			wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/my-app/div/main/my-home/div/div[1]/div/a")));
			popularMake.Click();
		}
		public void GoToPopularCar()
		{
			WebDriverWait wait = new WebDriverWait(Driver.WebDriver, TimeSpan.FromSeconds(5));
			wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/my-app/div/main/my-home/div/div[2]/div/a")));
			popularCar.Click();
		}

		public void GoToOverall()
		{
			WebDriverWait wait = new WebDriverWait(Driver.WebDriver, TimeSpan.FromSeconds(5));
			wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/my-app/div/main/my-home/div/div[3]/div/a")));
			overall.Click();
		}

		public bool IsHomeSectionDisplayed() => homeSection.Displayed;
	}
}
