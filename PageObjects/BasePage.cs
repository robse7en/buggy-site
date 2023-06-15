using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace BuggyCar.Test.PageObjects
{
	public class BasePage
	{
		public static string baseUrl = "https://buggy.justtestit.org/";

		[FindsBy(How = How.XPath, Using = "/html/body/my-app/header/nav/div/my-login/div/form/button")]
		public IWebElement _login;
		
		[FindsBy(How = How.LinkText, Using = "Logout")]
		public IWebElement _logout;

		[FindsBy(How = How.LinkText, Using = "Register")]
		public IWebElement _register;

		[FindsBy(How = How.Name, Using = "login")]
		public IWebElement _loginInput;

		[FindsBy(How = How.Name, Using = "password")]
		public  IWebElement _passwordInput;

		[FindsBy(How = How.LinkText, Using = "Buggy Rating")]
		public IWebElement _logo;

		public void GoToHomePage() => Driver.Goto(baseUrl);
		public void ClickLogoLink() => _logo.Click();

	}
}
