using BuggyCar.Test.PageObjects;
using SeleniumExtras.PageObjects;

namespace BuggyCar.Test
{
	public class Page
	{
		public static LoginPage LoginPage
		{
			get
			{
				var page = new LoginPage();
				PageFactory.InitElements(Driver.SearchContext, page);
				return page;
			}
		}

		public static HomePage HomePage
		{
			get
			{
				var page = new HomePage();
				PageFactory.InitElements(Driver.SearchContext, page);
				return page;
			}
		}

		public static OverallRatingPage OverallRatingPage
		{
			get
			{
				var page = new OverallRatingPage();
				PageFactory.InitElements(Driver.SearchContext, page);
				return page;
			}
		}

		public static RegisterPage RegisterPage
		{
			get
			{
				var page = new RegisterPage();
				PageFactory.InitElements(Driver.SearchContext, page);
				return page;
			}
		}

		public static PopularPage PopularPage
		{
			get
			{
				var page = new PopularPage();
				PageFactory.InitElements(Driver.SearchContext, page);
				return page;
			}
		}
	}
}
