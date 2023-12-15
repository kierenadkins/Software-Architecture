---
id: {0015}
date: {06/12/2023}
---
# Using Soild principles

## Context and Problem Statement
In the application we want to ensure that our architecture is easly understood, maintainable and extendable to avoid future problems.

<!-- This is an optional element. Feel free to remove. -->
## Decision Drivers

* Aim to improve maintability
* ensure that code is extendable
* Using dependency injection

## Considered Options

* SOILD PRINCIPLES
* GRASP

## Decision Outcome

Chosen option: "Soild", because
we are able to loosly follow 5 rules 
 Single-Responsibility Principle - each class should have its own responsbility 
 Open-Closed Principle - ensuring that we only add additonal logic rather than changing exisiting as this may cause problems within the system
 Liskov substitution principle - We can ensure the open-closed principles by being able to swap out child classes with the same logic from parent class
  Interface segregation principle - Using lots of interfaces instread of enforcing every class to inherit additional logic it may not need
  Dependency inversion principle - we are able to inject our interfaces into the part of the code we require the logic, this means we dont depend on a concrete class but rather an abstraction which can be changed 

  By following these we aim to create a system that decreases coupling, improves maintanability, secruity and makes our code more easy to read. Saying all of this "the SOLID principles encourage developers to write code that is modular, easy to understand, and easy to modify"(Roel, 2023)

### Consequences

* Good, because it we can reuse code and reduces of bugs due to modification.
* Bad, because inital refactoring may take some time

## Status
* Approved

## More Information
Information about SOILD AND GRASP CAN BE FOUND HERE https://dzone.com/articles/solid-grasp-and-other-basic-principles-of-object-o

Roel. (2023, March 8). Following the SOLID Design Principles will lead to cleaner code. DEV Community. https://dev.to/iamrule/solid-principles-explained-28da#:~:text=Overall%2C%20the%20SOLID%20principles%20encourage,every%20principle%20in%20more%20detail.
