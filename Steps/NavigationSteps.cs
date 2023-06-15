using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using TechTalk.SpecFlow;

namespace BuggyCar.Test.Steps
{
	[Binding]
	public class NavigationSteps
	{
		[Given(@"The user is on (.*) of the BuggyCars website")]
		public void GivenTheUserIsOnRegisterOfTheBuggyCarsWebsite(string page)
		{
			switch (page)
			{
				case "Register":
					Page.HomePage.GoToHomePage();
					Page.LoginPage.ClickLogout();
					Page.HomePage.GoToRegister();
					Assert.IsTrue(Driver.WebDriver.Url.Contains("https://buggy.justtestit.org/register"));
					break;
				case "PopularMake":
					Page.HomePage.GoToHomePage();
					Page.LoginPage.ClickLogout();
					Page.HomePage.GoToPopularMake();
					Assert.IsTrue(Driver.WebDriver.Url.Contains("https://buggy.justtestit.org/make"));
					break;
				case "PopularCar":
					Page.HomePage.GoToHomePage();
					Page.LoginPage.ClickLogout();
					Page.HomePage.GoToPopularCar();
					Assert.IsTrue(Driver.WebDriver.Url.Contains("https://buggy.justtestit.org/model"));
					break;
				case "Overall":
					Page.HomePage.GoToHomePage();
					Page.LoginPage.ClickLogout();
					Page.HomePage.GoToOverall();
					Assert.IsTrue(Driver.WebDriver.Url.Contains("https://buggy.justtestit.org/overall"));
					break;
			}
		}

		[When(@"The user clicks on the BuggyCars logo located on the top left corner of the page")]
		public void WhenTheUserClicksOnTheBuggyCarsLogoLocatedOnTheTopLeftCornerOfThePage()
		{
			Driver.WebDriver.FindElement(By.XPath("/html/body/my-app/header/nav/div/a")).Click();
		}

		[Then(@"The user should be redirected to the BuggyCars homepage")]
		public void ThenTheUserShouldBeRedirectedToTheBuggyCarsHomepage()
		{
			Assert.IsTrue(Driver.WebDriver.Url.Contains("https://buggy.justtestit.org/"));
		}

		[Given(@"The user is on the BuggyCars homepage")]
		public void GivenTheUserIsOnTheBuggyCarsHomepage()
		{
			Page.HomePage.GoToHomePage();
			Assert.IsTrue(Driver.WebDriver.Url.Contains("https://buggy.justtestit.org/"));
		}


		[When(@"The user clicks on the (.*) link")]
		public void WhenTheUserClicksOnTheLinkLink(string link)
		{
			switch (link)
			{
				case "Register":
					Page.HomePage.GoToRegister();
					break;
				case "PopularMake":
					Page.HomePage.GoToPopularMake();
					break;
				case "PopularCar":
					Page.HomePage.GoToPopularCar();
					break;
				case "Overall":
					Page.HomePage.GoToOverall();
					break;
			}
		}

		[Then(@"The user should be redirected to the (.*) page")]
		public void ThenTheUserShouldBeRedirectedToTheBuggyCarsRegisterPage(string page)
		{
			switch (page)
			{
				case "Register":
					Assert.IsTrue(Driver.WebDriver.Url.Contains("https://buggy.justtestit.org/register"));
					break;
				case "PopularMake":
					Assert.IsTrue(Driver.WebDriver.Url.Contains("https://buggy.justtestit.org/make"));
					break;
				case "PopularCar":
					Assert.IsTrue(Driver.WebDriver.Url.Contains("https://buggy.justtestit.org/model"));
					break;
				case "Overall":
					Assert.IsTrue(Driver.WebDriver.Url.Contains("https://buggy.justtestit.org/overall"));
					break;
			}
		}

		[Given(@"The user is on the BuggyCars overall ranking page or the BuggyCars popular make page")]
		public void GivenTheUserIsOnTheBuggyCarsOverallRankingPageOrTheBuggyCarsPopularMakePage()
		{
			Page.HomePage.GoToHomePage();
			Page.LoginPage.ClickLogout();
			Page.HomePage.GoToOverall();
			Assert.IsTrue(Driver.WebDriver.Url.Contains("https://buggy.justtestit.org/overall"));
		}

		[When(@"The user checks the list format of the displayed buggy cars")]
		public void WhenTheUserChecksTheListFormatOfTheDisplayedBuggyCars()
		{
			Driver.Wait().Until(ExpectedConditions.ElementIsVisible(By.XPath("//tbody")));
			IWebElement table = Driver.WebDriver.FindElement(By.XPath("/html/body/my-app/div/main/my-overall/div/div/table"));
			Assert.True(table.Displayed);
		}

		[Then(@"The buggy cars should be displayed correctly, with each car represented by a thumbnail image, the car model, and the overall rating")]
		public void ThenTheBuggyCarsShouldBeDisplayedCorrectlyWithEachCarRepresentedByAThumbnailImageTheCarModelAndTheOverallRating()
		{
			IWebElement image = Driver.WebDriver.FindElement(By.XPath("/html/body/my-app/div/main/my-overall/div/div/table/tbody/tr[1]/td[1]/a/img"));
			IWebElement model = Driver.WebDriver.FindElement(By.XPath("/html/body/my-app/div/main/my-overall/div/div/table/tbody/tr[1]/td[3]/a"));
			IWebElement comment = Driver.WebDriver.FindElement(By.XPath("/html/body/my-app/div/main/my-overall/div/div/table/tbody/tr[1]/td[7]"));
			Assert.True(model.Displayed && image.Displayed && comment.Displayed);
		}

		[Then(@"Each buggy car model should be represented by a link to its detail page with the vote page\.")]
		public void ThenEachBuggyCarModelShouldBeRepresentedByALinkToItsDetailPageWithTheVotePage_()
		{
			IWebElement model = Driver.WebDriver.FindElement(By.XPath("/html/body/my-app/div/main/my-overall/div/div/table/tbody/tr[1]/td[3]/a"));
			string href = model.GetAttribute("href");
			Console.WriteLine(href);
			Assert.True(href.Contains("/model/"));
		}

		[Given(@"The user navigate to (.*)")]
		public void GivenIAmIn(string url)
		{
			Driver.WebDriver.Navigate().GoToUrl(url);
		}

		[When(@"The user click logo link")]
		public void WhenIClickLogoLink()
		{
			Page.HomePage.ClickLogoLink();
		}

		[Then(@"The user should be navigated back to home page")]
		public void ThenIShouldBeSentBackToHomePage()
		{
			Assert.That(Page.HomePage.IsHomeSectionDisplayed(), Is.True);
		}
	}
}
