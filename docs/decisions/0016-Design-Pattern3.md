---
Id: {0017}
date: {12/13/2023}
---
# {brief description of the solved problem and solution}

## Context and Problem Statement
We faced a challenge in constructing complex objects and managing their flexible representations.

We want to ensure that the architecture can construct complex objects quickly and effectively. An example of this could be the application, diffrent visas in the future may need diffrent versions of the application class and may need subclasses that will build a superclass during run-time

## Decision Drivers

* Construction of complex objects
* flexibile creation

## Considered Options

* Builder pattern
* prototype 
* abstract factory pattern

## Decision Outcome

Selected option: "Builder Pattern"

I have chosen this as it is the most suitable, This pattern "is a creational design pattern that lets you construct complex objects step by step"(Refactoring.Guru, 2023a). In terms of an application we may require addition sections such as biometric identification. This means that by having a builder we are able to simply call the .AddBiometricIdentification to the object during runtime.

### Consequences

* Good, because it helps surport the creation of complex problems at run time
* Bad, because currently i can only think of one use of the builder pattern and this may be over kill for the simpler objects, this means adding whole functionality just for one object.

## Status
* Pending

## Additional Resources
Refactoring.Guru. (2023a, January 1). Builder. https://refactoring.guru/design-patterns/builder