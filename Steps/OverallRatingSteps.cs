using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using TechTalk.SpecFlow;

namespace BuggyCar.Test.Steps
{
	[Binding]
	public class OverallRatingSteps
	{
		[Given(@"The user is viewing overall rating page")]
		public void GivenTheUserInOverallRatingPage()
		{
			Page.OverallRatingPage.GoTo();
		}

		[Then(@"The user see a list of all cars")]
		public void ThenTheUserSeeAListOfRegisteredModels()
		{
			Driver.Wait().Until(ExpectedConditions.ElementIsVisible(By.XPath("//table")));
			var rows = Page.OverallRatingPage.carsTable.FindElements(By.CssSelector("tbody tr"));
			Console.WriteLine($"There are {rows.Count} cars in the list.");
			Assert.GreaterOrEqual(rows.Count, 1);
		}

		[Given(@"The user manually enter page (.*)")]
		public void GivenTheUserManuallyEnterPage(int pageNumber)
		{
			Driver.Wait().Until(ExpectedConditions.ElementIsVisible(By.XPath("//table")));
			Page.OverallRatingPage.pageNumber.Clear();
			Page.OverallRatingPage.pageNumber.SendKeys(pageNumber.ToString());
		}

		[When(@"The user press enter key")]
		public void WhenTheUserPressEnterKey()
		{
			Page.OverallRatingPage.pageNumber.SendKeys(Keys.Enter);
		}


		[When(@"The user click (.*) page button")]
		public void WhenTheUserClickNextButton(string button)
		{
			if (button == "next")
			{
				Page.OverallRatingPage.nextBtn.Click();
			}
			else if (button == "previous")
			{
				Page.OverallRatingPage.previousBtn.Click();
			}
		}

		[Then(@"current page should be (.*)")]
		public void ThenCurrentPageShouldBe(int pageNumber)
		{
			Assert.AreEqual(pageNumber.ToString(), Page.OverallRatingPage.pageNumber.GetAttribute("value"),
				$"Expected is page {pageNumber} but displayed page {Page.OverallRatingPage.pageNumber.GetAttribute("value")} instead.");
		}

		[Then(@"all car image should display")]
		public void ThenAllCarImageShouldDisplay()
		{
			Driver.Wait().Until(ExpectedConditions.ElementIsVisible(By.XPath("//table")));

			var rows = Page.OverallRatingPage.carsTable.FindElements(By.CssSelector("tbody tr"));

			foreach (var row in rows)
			{
				var image = row.FindElement(By.ClassName("img-thumbnail"));
				int imageWidth = Convert.ToInt32(image.GetAttribute("naturalWidth"));
				Assert.Greater(imageWidth, 0, $"Image thumbnail for {image.GetAttribute("title")} is broken.");
			}
		}

		[When(@"The user click column header rank")]
		public void WhenTheUserClickColumnHeaderRank()
		{
			Driver.Wait().Until(ExpectedConditions.ElementIsVisible(By.XPath("//table")));

			Page.OverallRatingPage.rankSort.Click();
		}

		[Then(@"list will be sorted in descending order based on the total number of votes received")]
		public void ThenListSortedByDescendingOrder()
		{
			var ranks = Page.OverallRatingPage.GetRankings();

			for (int i = 0; i < ranks.Length - 1; i++)
			{
				Assert.GreaterOrEqual(ranks[i], ranks[i + 1]);
			}
		}

		[Then(@"cars with the highest number of votes should be ranked at the top")]
		public void ThenCarsWithTheHighestNumberOfVotesShouldBeRankedAtTheTop()
		{
			var ranks = Page.OverallRatingPage.GetRankings();

			Assert.GreaterOrEqual(ranks[0], ranks[1]);
		}
	}
}
