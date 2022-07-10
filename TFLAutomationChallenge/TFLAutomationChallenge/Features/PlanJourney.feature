Feature: PlanJourney
In order to plan my TFL journey
As a passenger I want to be able to search for my journey


Scenario: Verify a valid journey can be planned
	Given I am on tfl search journey page with journey "London Bridge" to "North Greenwich"
	When I search for a journey
	Then the system should display the Journey results
	Then the journey should contain "London Bridge" to "North Greenwich"

Scenario: Verify result is not provided when invalid journey is planned
	Given I am on tfl search journey page with journey "&&&" to "$$$"
	When I search for a journey
	Then the system should display the Journey results
	And the system should display error message "Sorry, we can't find a journey matching your criteria"

Scenario: Verify system is unable to plan journey when locations are not entered
	Given I am on tfl search journey page with journey "" to ""
	When I search for a journey
	Then the from field should return error message "The From field is required."
	And the to field should return error message "The To field is required."

Scenario: Verify journey can be amended
	Given I am on tfl search journey page with journey "London Bridge" to "North Greenwich"
	And I search for a journey
	When I choose to edit my journey with "Paddington" to "Stratford"
	Then the amended journey should contain "Paddington" to "Stratford"

Scenario: Verify recently planned journeys are displayed
	Given I am on tfl search journey page with journey "London Bridge" to "North Greenwich"
	And I search for a journey
	When I choose to view my recent journeys
	Then the recent journey should contain "London Bridge" to "North Greenwich"
