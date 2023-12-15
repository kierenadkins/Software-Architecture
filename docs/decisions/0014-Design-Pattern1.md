---
Id: {0014}
date: {06/12/2023}
---
# {short title of solved problem and solution}

## Context and Problem Statement
We want to ensure that our application is able to accomodate for changes to the system, without modifying exisiting code, for example in terms of the visa suggestions we may need diffrent type of information for diffrent visas.

## Decision Drivers

* Flexibility to allow for easy intergration of new functuonality or features
* Avoiding frequent modifications to the existing codebase to minimize the risk of introducing errors.
* Avoiding modifications to code, to minimize erorrs and performance issues alongside ensuring availability. 

## Considered Options

* Factory Methord
* abstract factory
* Modify code when required

## Decision Outcome

Chosen option: "Implementing the Factory Method Pattern," 

The "Factory Method Pattern allows the sub-classes to choose the type of objects to create." (Refactoring.Guru, 2023) this means that we are able to create classes that inherit from a interface, this means that we can create classes on the fly, when and if we need them without impacting existing code. The pattern also helps enforce soild principles.

the "Factory design pattern provides approach to code for interface rather than implementation."(Pankaj, 2022) which meanns that we can make our code less coupled and more easy to extend down the line.


### Consequences

* Good, because we minimise code modification, as we can simply create a new classes that will inherit from the interface and tell the factory when we want this object to be created.
* Good because we can create new classes in run time, meaning the application is able to accommodate to chnages.
* Good because it reduces performance issues, due to not making modifications we reduce the risk of errors, this means that it reduces our chances of getting performance issues
* Bad, because it gives increased complexity to the system
* Bad, because their could be a learning curve

## Status
* Approved

## More Information

Pankaj. (2022, August 3). Factory design pattern in Java. DigitalOcean. https://www.digitalocean.com/community/tutorials/factory-design-pattern-in-java

Refactoring.Guru. (2023, January 1). Factory method. https://refactoring.guru/design-patterns/factory-method