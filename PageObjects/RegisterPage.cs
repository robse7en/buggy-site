using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;

namespace BuggyCar.Test.PageObjects
{
	public class RegisterPage : BasePage
	{
		[FindsBy(How = How.Id, Using = "username")]
		private IWebElement username;

		[FindsBy(How = How.Id, Using = "firstName")]
		private IWebElement firstName;

		[FindsBy(How = How.Id, Using = "lastName")]
		private IWebElement lastName;

		[FindsBy(How = How.Id, Using = "password")]
		private IWebElement password;

		[FindsBy(How = How.Id, Using = "confirmPassword")]
		private IWebElement confirmPassword;

		[FindsBy(How = How.XPath, Using = "/html/body/my-app/div/main/my-register/div/div/form/button")]
		private IWebElement btn;

		[FindsBy(How = How.XPath, Using = "/html/body/my-app/div/main/my-register/div/div/form/div[6]")]
		private IWebElement message;

		public void RegisterInput(string username, string firstName, string lastName, string password, string confirm)
		{
			
			Driver.Wait().Until(ExpectedConditions.ElementIsVisible(By.Id("username")));
			Driver.Wait().Until(ExpectedConditions.ElementIsVisible(By.Id("firstName")));
			Driver.Wait().Until(ExpectedConditions.ElementIsVisible(By.Id("lastName")));
			Driver.Wait().Until(ExpectedConditions.ElementIsVisible(By.Id("password")));
			Driver.Wait().Until(ExpectedConditions.ElementIsVisible(By.Id("confirmPassword")));

			if(username == "random")
				username = Guid.NewGuid().ToString();

			this.username.Clear();
			this.firstName.Clear();
			this.lastName.Clear();
			this.password.Clear();
			this.confirmPassword.Clear();
			this.username.Click();
			this.username.SendKeys(username);
			this.firstName.Click();
			this.firstName.SendKeys(firstName);
			this.lastName.Click();
			this.lastName.SendKeys(lastName);
			this.password.Click();
			this.password.SendKeys(password);
			this.confirmPassword.Click();
			this.confirmPassword.SendKeys(confirm);
		}

		public void RegisterBtn()
		{
			btn.Click();
		}

		public bool MessageSuccess(string message)
		{
			Driver.Wait().Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/my-app/div/main/my-register/div/div/form/div[6]")));
			return this.message.Text.Contains(message);
		}

		public void GoTo() => Driver.Goto($"{baseUrl}register");

	}
}
