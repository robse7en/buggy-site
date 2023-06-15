using BuggyCar.Test.Models;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace BuggyCar.Test.Steps
{
	[Binding]
	public class VoteAndCommentStep
	{
		[Given(@"the user is on the BuggyCars website and is not logged in")]
		public void GivenTheUserIsOnTheBuggyCarsWebsiteAndIsNotLoggedIn()
		{
			Page.HomePage.GoToHomePage();
			Assert.IsTrue(Driver.WebDriver.Url.Contains("https://buggy.justtestit.org/"));
			Page.LoginPage.ClickLogout();
		}

		[When(@"the user clicks on any buggy car")]
		public void WhenTheUserClicksOnAnyBuggyCar()
		{
			Page.HomePage.GoToPopularCar();
		}

		[When(@"tries to vote without logging in")]
		public void WhenTriesToVoteWithoutLoggingIn()
		{
			Driver.Wait().Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/my-app/header/nav/div/my-login/div/form/button")));
			Assert.IsTrue(Page.LoginPage._login.Displayed);
			try
			{
				Assert.IsFalse(Page.PopularPage.vote.Displayed);
			}
			catch (NoSuchElementException ex)
			{
				Console.WriteLine("The Vote button element could not be found: " + ex.Message);
			}
		}

		[Then(@"the user should be prompted to log in or register for an account")]
		public void ThenTheUserShouldBePromptedToLogInOrRegisterForAnAccount()
		{
			Driver.Wait().Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/my-app/div/main/my-model/div/div[1]/div[3]/div[2]/div[2]/p")));
			Assert.IsTrue(Page.PopularPage.message.Text.Contains("You need to be logged in to vote"));
		}

		[Then(@"should not be able to submit a vote")]
		public void ThenShouldNotBeAbleToSubmitAVote()
		{
			Assert.IsFalse(Page.PopularPage.latestComment.Text.Contains(DateTime.Now.ToString("MMM dd, yyyy,h")));
		}

		[Given(@"the user is on the BuggyCars website and is logged in")]
		public void GivenTheUserIsOnTheBuggyCarsWebsiteAndIsLoggedIn(Table table)
		{
			Page.HomePage.GoToHomePage();
			Assert.IsTrue(Driver.WebDriver.Url.Contains("https://buggy.justtestit.org/"));
			Page.LoginPage.ClickLogout();

			var login = table.CreateInstance<LoginModel>();
			Page.LoginPage.LoginEnter(login.Username, login.Password);
			Page.LoginPage.ClickLogin();

			Driver.Wait().Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/my-app/header/nav/div/my-login/div/ul/li[1]/span")));
			IWebElement message = Driver.WebDriver.FindElement(By.XPath("/html/body/my-app/header/nav/div/my-login/div/ul/li[1]/span"));
			Assert.True(message.Displayed);
		}

		[When(@"leaves a comment and votes for the buggy car")]
		public void WhenLeavesACommentAndVotesForTheBuggyCar()
		{
			Page.PopularPage.CommentInput(Page.PopularPage.SampleComment);
			Page.PopularPage.SelectVote();
		}

		[Then(@"the system should save the comment for the selected buggy car")]
		public void ThenTheSystemShouldSaveTheCommentForTheSelectedBuggyCar()
		{
			Driver.Wait().Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/my-app/div/main/my-model/div/div[3]/table/tbody/tr[1]/td[3]")));
			IWebElement comment = Driver.WebDriver.FindElement(By.XPath("/html/body/my-app/div/main/my-model/div/div[3]/table/tbody/tr[1]/td[3]"));
			Assert.True(comment.Text.Contains(Page.PopularPage.SampleComment));
		}

		[Then(@"the comment and vote should be displayed correctly on the buggy car details page")]
		public void ThenTheCommentAndVoteShouldBeDisplayedCorrectlyOnTheBuggyCarDetailsPage()
		{
			Driver.Wait().Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/my-app/div/main/my-model/div/div[3]/table/tbody/tr[1]/td[3]")));
			IWebElement comment = Driver.WebDriver.FindElement(By.XPath("/html/body/my-app/div/main/my-model/div/div[3]/table/tbody/tr[1]/td[3]"));
			Assert.True(comment.Text.Contains(Page.PopularPage.SampleComment));
		}

		[When(@"tries to vote the same buggy car again")]
		public void WhenTriesToVoteTheSameBuggyCarAgain()
		{
			try
			{
				Driver.Wait().Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/my-app/div/main/my-model/div/div[1]/div[3]/div[2]/div[2]/p")));
				IWebElement vote = Driver.WebDriver.FindElement(By.XPath("/html/body/my-app/div/main/my-model/div/div[1]/div[3]/div[2]/div[2]/div/button"));
				Assert.IsFalse(vote.Displayed);
			}
			catch (NoSuchElementException ex)
			{
				Console.WriteLine("The Vote button element could not be found: " + ex.Message);
			}
		}

		[Then(@"the system should not allow the user to vote the same buggy car again")]
		public void ThenTheSystemShouldNotAllowTheUserToVoteTheSameBuggyCarAgain()
		{
			try
			{
				Driver.Wait().Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/my-app/div/main/my-model/div/div[1]/div[3]/div[2]/div[2]/p")));
				IWebElement vote = Driver.WebDriver.FindElement(By.XPath("/html/body/my-app/div/main/my-model/div/div[1]/div[3]/div[2]/div[2]/div/button"));
				Assert.IsFalse(vote.Displayed);
			}
			catch (NoSuchElementException ex)
			{
				Console.WriteLine("The Vote button element could not be found: " + ex.Message);
			}
		}

		[Then(@"a message should be displayed indicating that the user has already voted for the buggy car")]
		public void ThenAMessageShouldBeDisplayedIndicatingThatTheUserHasAlreadyVotedForTheBuggyCar()
		{
			Driver.Wait().Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/my-app/div/main/my-model/div/div[1]/div[3]/div[2]/div[2]/p")));
			IWebElement message = Driver.WebDriver.FindElement(By.XPath("/html/body/my-app/div/main/my-model/div/div[1]/div[3]/div[2]/div[2]/p"));
			Assert.True(message.Text.Contains("Thank"));
		}

		[When(@"reloads the page")]
		public void WhenReloadsThePage()
		{
			Driver.WebDriver.Navigate().Refresh();
		}

		[Then(@"the system should save the user's comment for the selected buggy car")]
		public void ThenTheSystemShouldSaveTheUsersCommentForTheSelectedBuggyCar()
		{
			Driver.Wait().Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/my-app/div/main/my-model/div/div[3]/table/tbody/tr[1]/td[3]")));
			IWebElement comment = Driver.WebDriver.FindElement(By.XPath("/html/body/my-app/div/main/my-model/div/div[3]/table/tbody/tr[1]/td[3]"));
			Assert.True(comment.Text.Contains(Page.PopularPage.SampleComment));
		}

		[Then(@"the comment should be displayed correctly on the buggy car detail page")]
		public void ThenTheCommentShouldBeDisplayedCorrectlyOnTheBuggyCarDetailPage()
		{
			Driver.Wait().Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/my-app/div/main/my-model/div/div[3]/table/tbody/tr[1]/td[3]")));
			IWebElement comment = Driver.WebDriver.FindElement(By.XPath("/html/body/my-app/div/main/my-model/div/div[3]/table/tbody/tr[1]/td[3]"));
			Assert.True(comment.Text.Contains(Page.PopularPage.SampleComment));
		}
	}
}
