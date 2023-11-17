---
id: {0010}
date: {13/11/2023}
---
# Decision to use JWT for authentication

## Context and Problem Statement
in the context of having a system that has authentication, it is now time to think of a secure and efficient methord for user authentication. We need this so that we can authenticate users into the system and develop authorisation. 

## Decision Drivers

* We want users to be able to access the system using an email and password
* We want to be able to scale, to meet the growth of user base and evolving requirements

## Considered Options

* JWT
* OAUTH 2.0


## Decision Outcome

Chosen option: "JWT, because

quite simply it is the most suitable option for our needs. JWT is stateless authentication and alligns with our scalability requirements. It is widely accepted and is good at representing claims between systems. It is simple and will be easily intergrated into the system. Is it also suitable for the architecture we have chosen


### Consequences

* Good because JWT is stateless and does not require server side storage

* bad because if not implemented correctly then there could be securiry concerns

## More Information