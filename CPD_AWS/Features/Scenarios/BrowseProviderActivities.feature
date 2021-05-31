Feature: Browse Provider Activities
	

@mytag
Scenario: Browse Page Provider Activity Keyword Search
Given I go to Login page
When I enter <username> and <password>
And I enter sign in button
And navigate to MyCPD Portal
And Verify Successfully loged in
Then navigate to Browse page
And Enter search <keyword>
Then Verify Keyword results


Examples: 
| Scenario   | username | password  | keyword|
| SearchByID | 511414   | Tr@ining5 | Test   | 



Scenario: Browse Page Provider Activity Search by specific requirement
Given I go to Login page
When I enter <username> and <password>
And I enter sign in button
And navigate to MyCPD Portal
And Verify Successfully loged in
Then navigate to Browse page
And Select specific requirement <specificRequirement>
Then Verify SpecificRequirement results

Examples: 
| Scenario   | username | password  | specificRequirement      |
| SearchByID | 511414   | Tr@ining5 | Cultural safety training |

# specificRequirement -
# Medical acupuncture
# Cultural safety training
# Cultural safety training
# Mental health CPD
# Diagnostic radiology




Scenario: Browse Page Provider Activity Search by Activity Criteria
Given I go to Login page
When I enter <username> and <password>
And I enter sign in button
And navigate to MyCPD Portal
And Verify Successfully loged in
Then navigate to Browse page
And Select ActivityCriteria <activityCriteria>
Then Verify ActivityCriteria results

Examples: 
| Scenario                    | username | password  | activityCriteria        |
| SearchByAccredited_activity | 511414   | Tr@ining5 | CPD Accredited activity |
| SearchByBLS                 | 511414   | Tr@ining5 | BLS                     |
| SearchByGrant_eligible      | 511414   | Tr@ining5 | Grant eligible          |                     

# activityCriteria - 
# CPD Accredited activity 
# BLS 
# Grant eligible
