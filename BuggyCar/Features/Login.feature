Feature: Login

user authentication on the BuggyCars website

Scenario Outline: User Login with Valid Credentials
	Given the user is on the BuggyCar home page
	And the user can see the login form
	When the user enters valid login credentials with <username> <password>
	And clicks on the Login button
	Then the profile link should be visible
	And the Logout link should be visible
	And the user should see a welcome message with their username.
Examples: 
| username | password   |
| Tester@a | Tester@123 |

Scenario Outline: User Login with Invalid Credentials
	Given the user is on the BuggyCar home page
	And the user can see the login form
	When the user enters invalid login credentials with <username> <password>
	And clicks on the Login button
	Then an error message indicating that the login credentials are incorrect should be displayed.
Examples: 
| username | password   |
| Tester | Tester@123 |