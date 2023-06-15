using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;

namespace BuggyCar.Test.PageObjects
{
	public class LoginPage : BasePage
	{
		public void ClickLogin()
		{
			Driver.Wait().Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/my-app/header/nav/div/my-login/div/form/button")));
			_login.Click();
		}

		public void SelectLogout()
		{
			Driver.Wait().Until(ExpectedConditions.ElementIsVisible(By.LinkText("Logout")));
			_logout.Click();
		}

		public void ClickLogout()
		{
			try
			{
				_logout.Click();
			}
			catch (NoSuchElementException)
			{
				Console.WriteLine("Logout link not found");
			}
		}

		public void LoginEnter(string username, string password)
		{
			Driver.Wait().Until(ExpectedConditions.ElementIsVisible(By.Name("login")));
			Driver.Wait().Until(ExpectedConditions.ElementIsVisible(By.Name("password")));
			_loginInput.Clear();
			_passwordInput.Clear();
			_loginInput.Click();
			_loginInput.SendKeys(username);
			_passwordInput.Click();
			_passwordInput.SendKeys(password);
		}
	}
}
