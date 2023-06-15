using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;

namespace BuggyCar.Test.PageObjects
{
	public class OverallRatingPage : BasePage
	{
		[FindsBy(How = How.ClassName, Using = "cars")]
		public IWebElement carsTable;

		[FindsBy(How = How.LinkText, Using = "Rank")]
		public IWebElement rankSort;

		[FindsBy(How = How.XPath, Using = "//my-pager//input[@type='text']")]
		public IWebElement pageNumber;

		[FindsBy(How = How.LinkText, Using = "»")]
		public IWebElement previousBtn;

		[FindsBy(How = How.LinkText, Using = "«")]
		public IWebElement nextBtn;
		public void GoTo() => Driver.Goto($"{baseUrl}overall");

		public int[] GetRankings()
		{
			int[] ranking = new int[6];
			WebDriverWait wait = new WebDriverWait(Driver.WebDriver, TimeSpan.FromSeconds(5));
			wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/my-app/div/main/my-overall/div/div/table/tbody/tr[1]/td[3]/a")));
			for (int i = 1; i <= 5; i++)
			{
				IWebElement vote = Driver.WebDriver.FindElement(By.XPath("/html/body/my-app/div/main/my-overall/div/div/table/tbody/tr[" + i + "]/td[5]"));
				ranking[i - 1] = int.Parse(vote.Text);
			}
			return ranking;
		}
	}
}
