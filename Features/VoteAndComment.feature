Feature: VoteAndComment
	BuggyCars website's voting and commenting system enables users to cast their votes and post comments for the various faulty cars featured on the site.

Scenario: User cannot vote a buggy car without logging in
	Given the user is on the BuggyCars website and is not logged in
	When the user clicks on any buggy car
	And tries to vote without logging in
	Then the user should be prompted to log in or register for an account
	And should not be able to submit a vote


Scenario: User can leave a comment and vote a buggy car
	Given the user is on the BuggyCars website and is logged in
	| username    | password   |
	| testr       | Qwerty123! |
	When the user clicks on any buggy car
	And leaves a comment and votes for the buggy car
	Then the system should save the comment for the selected buggy car
	And the comment and vote should be displayed correctly on the buggy car details page


Scenario: User can only vote a buggy car once
	Given the user is on the BuggyCars website and is logged in
	| username | password   |
	| testr    | Qwerty123! |
	When the user clicks on any buggy car
	Then a message should be displayed indicating that the user has already voted for the buggy car


Scenario: User can view their own rating for a buggy car
	Given the user is on the BuggyCars website and is logged in
	| username | password   |
	| testr    | Qwerty123! |
	When the user clicks on any buggy car
	And leaves a comment and votes for the buggy car
	And reloads the page
	Then the system should save the user's comment for the selected buggy car
	And the comment should be displayed correctly on the buggy car detail page