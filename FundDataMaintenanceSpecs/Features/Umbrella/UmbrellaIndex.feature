Feature: Umbrella Index
	In order to know what umbrella's are available for edit
	I want to be shown a list of all umbrella's

Scenario: umbrella index page is inaccessible when not logged in
	Given I am not logged in
	And I have navigated to the umbrella index url
	Then the application sign-in page will be displayed

Scenario: umbrella index page is accessible when logged in
	Given I have logged in as an <role>
	And I have navigated to the umbrella index url
	Then the umbrella index page will be displayed