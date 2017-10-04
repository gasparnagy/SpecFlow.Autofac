Feature: Parallel Addition
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Add two numbers parallel
	Given I have entered 50 into the calculator
	And I have entered 70 into the calculator
	When I press add
	Then the result should be 120 on the screen

Scenario Outline: More addition parallel
	Given I have entered 50 into the calculator
	And I have entered 70 into the calculator
	When I press add
	Then the result should be 120 on the screen
Examples: 
	| a  | b  | result |
	| 50 | 70 | 120    |
	| 51 | 70 | 121    |
	| 52 | 70 | 122    |
	| 53 | 70 | 123    |
	| 54 | 70 | 124    |
	| 55 | 70 | 125    |
	| 56 | 70 | 126    |
	| 57 | 70 | 127    |
	| 58 | 70 | 128    |
	| 59 | 70 | 129    |
