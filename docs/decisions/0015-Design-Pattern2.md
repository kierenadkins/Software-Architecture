---
Id: {0015}
date: {12/13/2023}
---
# Using command Pattern

## Context and Problem Statement
We encountered a challenge in effectively sending commands/queries to support CQRS (Command Query Responsibility Segregation).

## Decision Drivers

* Efficient encapsulation of information for handlers
* Adherence to SOLID principles

## Considered Options

* Command Pattern

## Decision Outcome

Selected option: "Command Pattern"

I opted for the Command Pattern as it allows us to create an interface for both "Commands" and "Queries," facilitating seamless utilization by our service handlers. This choice aligns with the Single Responsibility Principle (SRP) of SOLID. The command pattern encapsulates all the information required to execute an action.

I have selected to use the command pattern as it allows me to create a interface for both command and quries for CQRS service handlers to use. This choice alighs with the decision to follow more SOILD principles, and in term follows SRP. The command pattern will also encapsulate all the inforrmation required for our command or query resulting in a smaller object, which could help performance over sending a massive amount of data into the api that may not be used

### Consequences
* the use of command pattern will help produce cleaner code, follow the soild principles and help the maintainability of our system which in the long term should help improve performance of the systen

## Status
* Approved

## Additional Resources