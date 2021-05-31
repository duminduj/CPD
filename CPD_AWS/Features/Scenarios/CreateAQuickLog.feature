Feature: Create A Quick Log
	

@ScenarioTesting
Scenario Outline: Create Quick Log
Given I go to Login page
When I enter <username> and <password>
And I enter sign in button
And navigate to MyCPD Portal
And Verify Successfully loged in
Then navigate to Log page
And Enter Quicklog details <logName>,<date>,<hours>, <typeOfCpd>, <notes>
And Submit
Then navigate to MyCPD page
Then Verify the points being update




Examples: 
| Scenario | username | password  | logName                     | date       | hours | typeOfCpd | notes      |
| QL1      | 511414   | Tr@ining5 | Test Log Name               | 13/05/2021 | 5     | A         | Test Notes |
| QL2      | 511414   | Tr@ining5 | Test Log Name with no notes | 10/05/2021 | 5     | A         |            |


Scenario Outline: Edit Quick Log
Given I go to Login page
When I enter <username> and <password>
And I enter sign in button
And navigate to MyCPD Portal
And Verify Successfully loged in
Then Select My Quick Log history
And Edit the first record
And Enter Quicklog details <logName>,<date>,<hours>, <typeOfCpd>, <notes>
And Update
Then navigate to MyCPD page


Examples: 
| Scenario | username | password  | logName                | date       | hours | typeOfCpd | notes      |
| QL3      | 511414   | Tr@ining5 | Test Log Name  Updated | 21/05/2021 | 10    | A         | Test Notes |