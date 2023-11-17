---
id: {0011}
date: {13/11/2023}
---
# Decision to use RBAC for authorization

## Context and Problem Statement
Within the system we must allow certain users access to certain sensitive information. We need to ensure that users who have the right level of access can use certain functionallites of the system and access the correct api endpoints.

## Decision Drivers

* Security, ensuring only the correct users have access to senesitive data, to keep confidentiallity, intergrity and availability of data

* Compliance, meeting data access and privacy regulations

## Considered Options

* Role Based Access Control
* Discretionary Access Control
* Mandatory Access Control

## Decision Outcome

Chosen option: "Role Based Access Control", because

I have chosen this as it is a very flexible, well known and scalable approach for managing access rights. This can be implemented on both the frontend routes and the api controllers. This will be reflected within the RBAC access control model.

Id also like to note that the flexibility allows us to easiely intergrate with identity management systems like keycloak in the future if required.


### Consequences

* Good as it simplifies access management
* Good allows for flexibility as the system grows
* Bad, as it could become complex as my roles develop and the complexity of the roles.

## More Information
