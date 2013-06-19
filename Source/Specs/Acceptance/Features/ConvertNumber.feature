﻿Feature: Convert a integer value into its text equivalent
	In order to be able to easily read numbers
	As a numbers man
	I want to see integers as english text

Scenario Outline: converting a valid number
	Given I am a numbers man
	When I attempt to Convert: the number '<integer>'
	Then I should see the answer '<result>' 

Examples: 
| integer | result                                                                            |
| 2887983 | two million eight hundred and eighty seven thousand nine hundred and eighty three |