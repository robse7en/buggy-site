using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;

namespace BuggyCar.Test.PageObjects
{
	public class PopularPage : BasePage
	{
		[FindsBy(How = How.Id, Using = "comment")]
		public IWebElement comment;

		[FindsBy(How = How.XPath, Using = "/html/body/my-app/div/main/my-model/div/div[1]/div[3]/div[2]/div[2]/div/button")]
		public IWebElement vote;

		[FindsBy(How = How.XPath, Using = "/html/body/my-app/div/main/my-model/div/div[1]/div[3]/div[2]/div[2]/p")]
		public IWebElement message;

		[FindsBy(How = How.XPath, Using = "/html/body/my-app/div/main/my-model/div/div[3]/table/tbody/tr[1]/td[1]")]
		public IWebElement latestComment;

		public string SampleComment = "1I1n0x0x1z 0l0f1e 1t0r0i1h0D1k0r";

		public void GoTo() => Driver.Goto($"{baseUrl}register");

		public void CommentInput(string text)
		{
			try
			{
				Driver.Wait().Until(ExpectedConditions.ElementIsVisible(By.Id("comment")));
				comment.Clear();
				comment.Click();
				comment.SendKeys(text);
			}
			catch (NoSuchElementException ex)
			{
				Console.WriteLine("The comment input element could not be found: " + ex.Message);
			}

		}

		public void SelectVote()
		{
			vote.Click();
		}
	}
}