---
# These are optional elements. Feel free to remove any of them.
id: {0006}
date: {31/10/2023}
---
# Clean Architecture with CQRS Decision for architecture patterns

## Context and Problem Statement

By using layered architecture we have protential issues with performance due to data having to go through multiple layers, and while we can scale each layerer independently it currently is not as effective. 

We want to explore some architecture patterns that could help us solve this.

## Decision Drivers

* Increase performance
* increased separation of concerns

## Considered Options

* Clean/Onion
* Micorkernel
* MicroServices
* Cqrs
* Model View Presenter

## Decision Outcome

Chosen option: "Clean architecture with the use of CQRS" because

By using a clean architecture which is a implementation of layered style, we are allowing our system to become free of "Independent of Frameworks", more "Testable", "Independent of UI" and "Independent of Database.", with that being said this only occurs due to the fact that by using clean architecture we icrease the separation of concerns across the layers, into Domain, Application, Infrastructre and API layers increasing the strucutre of our program so we can easily find what we are looking for easily, improving the ability to add additional logic to the system.

However clean architecture share similarties with layered by having simular strucutures. Both may encounter performance issues due to the sharing of data. To address this we want to intergrate CQRS. This will separte the read and write operations. Users will interact with the system by sending either commands or queries which in turn will use the repository pattern to independly scale read or write opperations. This will result in a more responsive user experience and thus improve performance as it "helps to maximize both display and query performance"(Martinekuan, n.d.) . We also improve security by "ensure that only the right domain entities are performing writes on the data."(Martinekuan, n.d.)

### Consequences

* Good, becausecqrs will increase performance of the system
* Good because clean architecture will help us with separation of concerns across the layers
* Bad, because Clean architecture can be more complex and might introduce a steeper learning curve for developers
* Bad, because there is extra overhead and boiler plate code slowing down development


## More Information

Guide on clean architecture "https://positiwise.com/blog/clean-architecture-net-core"


Khan, S. M. A. (2023, June 14). Layered architecture used in software development. DEV Community. https://dev.to/sardarmudassaralikhan/layered-architecture-used-in-software-development-8jd