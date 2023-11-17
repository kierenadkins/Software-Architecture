---
id: {0003}
date: {19/10/2023}
---
# Decision to use Github for collaborative software

## Context and Problem Statement
When working as a team we oftern reqire collaborative software to allow mutiple memembers of the same team work on the same codebase. We need to ensure that we can track changes, prevent conflicts and maintain the code. Version control is crucial to address these issues and will be required for this project.

## Decision Drivers

* Change Tracking
* Ability to roll back development incase of accidental breakages
* Collaborative efforts.


## Considered Options

* GitLab
* Github
* Beanstalk

## Decision Outcome

Chosen option: Github, because
Github is the most recognizable and is highly regarded by the software community for version control, providing seamless collaboration. Github being user-freindly, having intergrared issue tracking and pull requests with code review functionality makes it a vital choice. This being said we can also have repository rules, assuring that new code changes can not be pushed directly to the master branch, but rather undergo a code review from other developers, safegauding the Mainn branch.

### Consequences

* Good, because Github offers collabration to allow multiple team memembers to work on the product at the same time
* Good, because Github offers issue tracking to pin point if the program is broken at any point and we can roll back
* Good, because Github offers us the ability to have rules on a repo to ensure noone can directly push to master, but code reviews from branches are made instead
* Good, because our team can pull the latest code, to ensure that there is no overlapping
* Bad, because although it is the most widely used version control, someone who has not used git before may have a learning curve
* Bad, because there may be some privacy concerns involved with hosting the code and data on github even if it may be secure.

## More Information

