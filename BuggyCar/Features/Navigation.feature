Feature: Navigation

verify that users can navigate to the correct pages by clicking on the correct links, and that the buggy cars are displayed correctly on the website

Scenario Outline: Verify User Navigation to BuggyCars Homepage
Given The user is on <page> of the BuggyCars website
When The user clicks on the BuggyCars logo located on the top left corner of the page
Then The user should be redirected to the BuggyCars homepage
Examples: 
| page        |
| Register    |
| PopularMake |
| PopularCar  |
| Overall     |


Scenario Outline: Verify User Navigation to otherg Page
Given The user is on the BuggyCars homepage
When The user clicks on the <link> link
Then The user should be redirected to the BuggyCars <page> page
Examples: 
| Link        | page        |
| Register    | Register    |
| PopularMake | PopularMake |
| PopularCar  | PopularCar  |
| Overall     | Overall     |


Scenario: Verify Display of Buggy Cars
Given The user is on the BuggyCars overall ranking page or the BuggyCars popular make page
When The user checks the list format of the displayed buggy cars
Then The buggy cars should be displayed correctly, with each car represented by a thumbnail image, the car model, and the overall rating
And Each buggy car model should be represented by a link to its detail page with the vote page.
