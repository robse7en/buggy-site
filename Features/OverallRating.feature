Feature: OverallRating
	Page with a list of all cars - with sorting and pagination

Background:
	Given The user is viewing overall rating page

Scenario Outline: Ensure the user can view a list of all cars
	Then The user see a list of all cars

Scenario Outline: Ensure the user can sort list by rank in page 1
	When The user click column header rank
	Then list will be sorted in descending order based on the total number of votes received
	And cars with the highest number of votes should be ranked at the top

Scenario Outline: Ensure the user can manually navigate to page 3
	Given The user manually enter page 3
	When The user press enter key
	Then current page should be 3

Scenario Outline: Ensure the user can manually enter page 2 and navigate to next page
	Given The user manually enter page 2
	When The user press enter key
	And The user click next page button
	Then current page should be 3

Scenario Outline: Ensure the user can manually enter page 2 and display image for each car
	Given The user manually enter page 2
	When The user press enter key
	Then all car image should display