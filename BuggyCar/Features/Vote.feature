Feature: Vote

the voting and commenting system on the BuggyCars website.allows users to vote and leave comments for different buggy cars listed on the website. 



Scenario: User cannot vote a buggy car without logging in
Given the user is on the BuggyCars website and is not logged in
When the user clicks on any buggy car
And tries to vote without logging in
Then the user should be prompted to log in or register for an account
And should not be able to submit a vote


Scenario: User can leave a comment and vote a buggy car
Given the user is on the BuggyCars website and is logged in
| username | password   |
| Tester@a6   | Tester@123 |
When the user clicks on any buggy car
And leaves a comment and votes for the buggy car
Then the system should save the comment for the selected buggy car
And the comment and vote should be displayed correctly on the buggy car details page


Scenario: User can only vote a buggy car once
Given the user is on the BuggyCars website and is logged in
| username | password   |
| Tester@a5   | Tester@123 |
When the user clicks on any buggy car
And leaves a comment and votes for the buggy car
And tries to vote the same buggy car again
Then the system should not allow the user to vote the same buggy car again
And a message should be displayed indicating that the user has already voted for the buggy car


Scenario: User can view their own rating for a buggy car
Given the user is on the BuggyCars website and is logged in
| username | password   |
| Tester@a4   | Tester@123 |
When the user clicks on any buggy car
And leaves a comment and votes for the buggy car
And reloads the page
Then the system should save the user's comment for the selected buggy car
And the comment should be displayed correctly on the buggy car detail page
