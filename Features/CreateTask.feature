Feature: CreateTask

@web
Scenario Template: Sucessfull_Login
Given I am on the ToDO App Sign In page
When I login to ToDo App
Then I see the Message Welcome username
And the Message Welcome <username>
Examples: 
| username                      |
| antonio geilson parente lopes |

@web
Scenario: Message_Login_Required 
Given I am on the ToDO App Sign In page
When i click on My Tasks on The Navbar
Then the Message You need to sign in or sign up before continuing is displayed

@web
Scenario Template: Message_Invalid_Email_or_Password
Given I am on the ToDO App Sign In page 
When I login to ToDo App with wrong <password>
Then the Message Invalid email or password is displayed

Examples:
| password |
| abc      |

@web
Scenario Template: Message_Todo_List
Given I am on the ToDO App Home page on Logged Session
When i click on My Tasks on The Navbar
Then i see the message <username>'s ToDo List
Examples:
|username|
|antonio geilson parente lopes|

@web
Scenario Template: Tasks added - add Button
Given I am on the Taks Page on Logged Session
And I fill new tasks field <taskValue>
When I click add button
Then I see the task register added <taskValue>

Examples: 
|taskValue|
|abc	  |

@web
Scenario: Tasks added - 250 characters
Given I am on the Taks Page on Logged Session
And I fill new tasks field_ with DDC characters
When I click add button 
Then I see the task register added

@web
Scenario Template: Validate Tasks Value Updated
Given I am on the ToDO App Home page on Logged Session
And i click on My Tasks on The Navbar
And I fill new tasks field <taskValue>
And I click add button
And I click on task added 
And I update field value <newValue>
When I click Submit Button
Then I see the task updated <newValue>

Examples:
| taskValue | newValue |
| abcdef    | 123456   |


