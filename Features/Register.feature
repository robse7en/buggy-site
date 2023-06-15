Feature: Register
	User registration on the BuggyCars website

Scenario Outline: User Registration with Valid Information
	Given the user is on the BuggyCars registration page
	When the user enters valid <login>, <first name>, <last name>, <password>, and <confirm password> in the registration form
	And clicks on the register button
	Then a message should be displayed on the page saying Registration is successful.
	Examples: 
	| login    | first name | last name | password   | confirm password |
	| random   | John       | Doe        | Tester@123 | Tester@123       |



Scenario Outline: User Registration with Invalid Information
	Given the user is on the BuggyCars registration page
	When the user enters invalid <login>, <first name>, <last name>, <password>, and <confirm password> in the registration form
	And clicks on the register button
	Then an error message should be displayed indicating that the password did not conform with policy.
	Examples: 
	| login     | first name | last name | password | confirm password |
	| Tester@a1 | John       | Doe       | Tester   | Tester           |