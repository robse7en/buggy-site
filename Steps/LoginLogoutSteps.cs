using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using TechTalk.SpecFlow;

namespace BuggyCar.Test.Steps
{
	[Binding]
	public sealed class LoginLogoutSteps
	{

		[Given(@"the user is on the BuggyCar home page")]
		public void GivenTheUserIsOnTheBuggyCarHomePage()
		{
			Page.LoginPage.GoToHomePage();
			Assert.That(Driver.WebDriver.Url.Contains("https://buggy.justtestit.org/"), Is.True);
			Page.LoginPage.ClickLogout();
		}


		[Given(@"the user can see the login form")]
		public void GivenTheUserCanSeeTheLoginForm()
		{
			IWebElement username = Driver.WebDriver.FindElement(By.Name("login"));
			Assert.That(username.Displayed, Is.True);
			IWebElement password = Driver.WebDriver.FindElement(By.Name("password"));
			Assert.That(password.Displayed, Is.True);
		}

		[When(@"the user enters valid login credentials with (.*) (.*)")]
		public void WhenTheUserEntersValidLoginCredentials(string username, string password)
		{
			Page.LoginPage.LoginEnter(username, password);
		}

		[When(@"clicks on the Login button")]
		public void WhenClicksOnTheLoginButton()
		{
			Page.LoginPage.ClickLogin();
		}

		[Then(@"the profile link should be visible")]
		public void ThenTheProfileLinkShouldBeVisible()
		{
			Driver.Wait().Until(ExpectedConditions.ElementIsVisible(By.LinkText("Profile")));
			IWebElement profile = Driver.WebDriver.FindElement(By.LinkText("Profile"));
			Assert.That(profile.Displayed, Is.True);
		}

		[Then(@"the Logout link should be visible")]
		public void ThenTheLogoutLinkShouldBeVisible()
		{
			IWebElement logout = Driver.WebDriver.FindElement(By.LinkText("Logout"));
			Assert.That(logout.Displayed, Is.True);
		}

		[Then(@"the user should see a welcome message with their username\.")]
		public void ThenTheUserShouldSeeAWelcomeMessageWithTheirUsername_()
		{
			IWebElement welecome = Driver.WebDriver.FindElement(By.XPath("/html/body/my-app/header/nav/div/my-login/div/ul/li[1]/span"));
			Assert.That(welecome.Displayed, Is.True);
		}

		[When(@"the user enters invalid login credentials with (.*) (.*)")]
		public void WhenTheUserEntersInvalidLoginCredentials(string username, string passsword)
		{
			Page.LoginPage.LoginEnter(username, passsword);
			Page.LoginPage.ClickLogin();
		}

		[Then(@"an error message indicating that the login credentials are incorrect should be displayed\.")]
		public void ThenAnErrorMessageIndicatingThatTheLoginCredentialsAreIncorrectShouldBeDisplayed_()
		{
			Driver.Wait().Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/my-app/header/nav/div/my-login/div/form/div/span")));
			IWebElement message = Driver.WebDriver.FindElement(By.XPath("/html/body/my-app/header/nav/div/my-login/div/form/div/span"));
			Assert.That(message.Displayed, Is.True);
		}

		[Given(@"The user am logged in with (.*) (.*)")]
		public void GivenIAmLoggedIn(string username, string password)
		{
			Page.LoginPage.GoToHomePage();
			Page.LoginPage.LoginEnter(username, password);
			Page.LoginPage.ClickLogin();
		}

		[When(@"The user click logout button")]
		public void WhenIClickLogoutButton()
		{
			Driver.Wait().Until(ExpectedConditions.ElementIsVisible(By.LinkText("Logout")));
			Page.LoginPage.ClickLogout();
		}

		[Then(@"The user should be logged out")]
		public void ThenIShouldBeLoggedOut()
		{
			IWebElement loginform = Driver.WebDriver.FindElement(By.ClassName("form-inline"));
			Assert.That(loginform.Displayed, Is.True);
		}
	}
}
