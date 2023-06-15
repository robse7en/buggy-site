Feature: Navigation
	Ensure that users are able to reach the appropriate pages by interacting with the correct hyperlinks, and that the website accurately displays the buggy cars with known issues.

Scenario Outline: Ensure user navigation to homepage
	Given The user is on <page> of the BuggyCars website
	When The user clicks on the BuggyCars logo located on the top left corner of the page
	Then The user should be redirected to the BuggyCars homepage
	Examples: 
	| page        |
	| Register    |
	| PopularMake |
	| PopularCar  |
	| Overall     |


Scenario Outline: Ensure User Navigation to other Page
	Given The user is on the BuggyCars homepage
	When The user clicks on the <link> link
	Then The user should be redirected to the BuggyCars <page> page
	Examples: 
	| Link        | page        |
	| Register    | Register    |
	| PopularMake | PopularMake |
	| PopularCar  | PopularCar  |
	| Overall     | Overall     |


Scenario Outline: Ensure Display of Buggy Cars
	Given The user is on the BuggyCars overall ranking page or the BuggyCars popular make page
	When The user checks the list format of the displayed buggy cars
	Then The buggy cars should be displayed correctly, with each car represented by a thumbnail image, the car model, and the overall rating
	And Each buggy car model should be represented by a link to its detail page with the vote page.

Scenario Outline: Ensure user can navigate back to home page from popular make page
	Given The user navigate to https://buggy.justtestit.org/make/c0bm09bgagshpkqbsuag
	When The user click logo link
	Then The user should be navigated back to home page

Scenario Outline: Ensure user can navigate back to home page from popular model page
	Given The user navigate to https://buggy.justtestit.org/model/c0bm09bgagshpkqbsuag%7Cc0bm09bgagshpkqbsuh0
	When The user click logo link
	Then The user should be navigated back to home page

Scenario Outline: Ensure user can navigate back to home page from overall rating page
	Given The user navigate to https://buggy.justtestit.org/overall
	When The user click logo link
	Then The user should be navigated back to home page