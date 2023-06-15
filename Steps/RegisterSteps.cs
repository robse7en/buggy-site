using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BuggyCar.Test.Steps
{
	[Binding]
	public class RegisterSteps
	{
		[Given(@"the user is on the BuggyCars registration page")]
		public void GivenTheUserIsOnTheBuggyCarsRegistrationPage()
		{
			Page.RegisterPage.GoTo();
		}

		[When(@"the user enters valid (.*), (.*), (.*), (.*), and (.*) in the registration form")]
		public void WhenTheUserEntersValidTesterATestErTesterAndTesterInTheRegistrationForm(string username, string firstName, string lastName, string password, string confirm)
		{
			Page.RegisterPage.RegisterInput(username, firstName, lastName, password, confirm);
		}

		[When(@"clicks on the register button")]
		public void WhenClicksOnTheButton()
		{
			Page.RegisterPage.RegisterBtn();
		}

		[Then(@"a message should be displayed on the page saying (.*).")]
		public void ThenAMessageShouldBeDisplayedOnThePageSaying(string message)
		{
			Assert.True(Page.RegisterPage.MessageSuccess(message));
		}

		[When(@"the user enters invalid (.*), (.*), (.*), (.*), and (.*) in the registration form")]
		public void WhenTheUserEntersInvalidTesterATestErTesterAndTesterInTheRegistrationForm(string username, string firstName, string lastName, string password, string confirm)
		{
			Page.RegisterPage.RegisterInput(username, firstName, lastName, password, confirm);
		}


		[Then(@"an error message should be displayed indicating that the password did not conform with policy\.")]
		public void ThenAnErrorMessageShouldBeDisplayedIndicatingThatThePasswordDidNotConformWithPolicy_()
		{
			Assert.True(Page.RegisterPage.MessageSuccess("Password did not conform with policy"));
		}
	}
}
