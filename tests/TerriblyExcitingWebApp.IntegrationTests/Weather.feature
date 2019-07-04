Feature: Weather
	In order to plan my holiday
	As a worrier
	I want to know the weather forecast for the next 7 days

@mytag
Scenario: View 7 day forecast
	Given the following forecast data
		| Date       | TemperatureC |
		| 2019-07-01 | 12           |
		| 2019-07-02 | 13           |
		| 2019-07-03 | 14           |
		| 2019-07-04 | 15           |
		| 2019-07-05 | 16           |
		| 2019-07-06 | 17           |
		| 2019-07-07 | 18           |
		| 2019-07-08 | 18           |
		| 2019-07-09 | 16           |
		| 2019-07-10 | 13           |
	When I get data from the weather api with the date "2019-07-03"
	Then I should get the following response
		| Date       | TemperatureC |
		| 2019-07-03 | 14           |
		| 2019-07-04 | 15           |
		| 2019-07-05 | 16           |
		| 2019-07-06 | 17           |
		| 2019-07-07 | 18           |
		| 2019-07-08 | 18           |
		| 2019-07-09 | 16           |