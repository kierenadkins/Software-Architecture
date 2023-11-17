---
# These are optional elements. Feel free to remove any of them.
date: {17/11/2023}
---
# {short title of solved problem and solution}

## Context and Problem Statement
The need for a secure provider to handle single sign-on access to the application to provide authentication and authorizairtion(RBAC)

<!-- This is an optional element. Feel free to remove. -->
## Decision Drivers

* Security improvements
* scalability 

## Considered Options

* Option 1: Implement Keycloak for Authentication and Authorization
* Option 2: build the authentication and authorization internal [This will be done for the prototype]

## Decision Outcome

Chosen option: "option 1", because

Keycloak securely hashes passwords with secure protocols, can be set up to use JWT tokens to match our systems orginal design and uses sql storage which would be more approriate for this data.



<!-- This is an optional element. Feel free to remove. -->
### Consequences

* Good, because {positive consequence, e.g., improvement of one or more desired qualities, …}
* Bad, because {negative consequence, e.g., compromising one or more desired qualities, …}
* … <!-- numbers of consequences can vary -->

<!-- This is an optional element. Feel free to remove. -->
## More Information

{You might want to provide additional evidence/confidence for the decision outcome here and/or
 document the team agreement on the decision and/or
 define when/how this decision the decision should be realized and if/when it should be re-visited.
Links to other decisions and resources might appear here as well.}
