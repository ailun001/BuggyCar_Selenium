Feature: Rank

ranks the buggy cars on the BuggyCars website based on the total number of votes received

Scenario: Verify that the buggy cars are ranked based on the total number of votes received
Given the BuggyCars website has multiple buggy cars with votes
When I view the buggy cars ranking
Then the buggy cars should be ranked in descending order based on the total number of votes received
And the buggy cars with the highest number of votes should be ranked at the top

Scenario: Verify that the rank order is updated dynamically as new votes are received
Given the BuggyCars website has multiple buggy cars with votes
When I add a new vote to a buggy car
| username  | password   | carRanked |
| Tester@a3 | Tester@123 | 3         |
Then the buggy car's total number of votes should increase by one
And the ranking order should be updated dynamically
And the buggy car's new position in the ranking should reflect the change in its total number of votes.