---
id: {0005}
date: {27/10/2023}
---
# Layered Architecture Style Decision

## Context and Problem Statement

I have been tasked with building a visa processing system that will advise, guide and process visa applications. It must be able to interact with visa issuing authority of different countries. The system should have access to the latest information. With this we need to choice an architecture style that will meet our non-functional requirements

## Decision Drivers

* To ensure architecture aligns with project requirements
* To ensure non-functional requirements are addressed.
* Non-Functional requirements go in the following order. Scalability, Security, Availability, Performance, Usability, Accessibility.

## Considered Options

* Service-Oriented
* Layered
* Event-Driven
* Data Centric

## Decision Outcome

Chosen option: "client-server architecture using a Layered style", because
For the visa processing system we need to ensure that our non-functional requirements are met. In terms of our backend we want to know that we can scale, have security messures and have good performance. Layered architecture can offer us two out of the three along with many other benefits such as Modularity, flexibility, testability and reusability which is crucial for a complex system that is global.

By splitting our application into layers we are able to follow separation of concerns and divide our functionality accross layers which will help our system be more readable. In terms of our non-functional requirements we are able to quickly add additional logic to the system easily(scalable) but we are also able to actually scale each layer independtly while running for example "The infrastructure layer may be easily scaled horizontally by adding additional instances." (Khan, 2023b)

Additionally we are able to secure our layers independently by using "multi-layered security" which "is the best way to protect your organization from cyber attacks"(What Is Multi-Layered Security?, n.d.)  this can include Authentication, Authorization, Data encryption and Input validation to their respective layer boosting secruity of the whole system

This alongside designing each layer to be designed to reduce redundancy and fault tolerance and using load balancers should help us minimize downtime and achieve the non-functional requirement

We will use Rest Apis in the api layer to connect our backend to whatever frontend(client) we want.

### Consequences

* Good, because it meets our scability and secruity non-functional requirements
* Good, because it offers additional benefits such as testability which will ensure our system is bug free
* Bad, because performance can be hinded due to data being passed around layers
* Bad, because it can have additional complexity if there are to many layers

## More Information

Khan, S. M. A. (2023b, June 14). Layered architecture used in software development. DEV Community. https://dev.to/sardarmudassaralikhan/layered-architecture-used-in-software-development-8jd

What is Multi-Layered Security? (n.d.). Druva. https://www.druva.com/glossary/multi-layered-security#:~:text=In%20ideal%20circumstances%2C%20a%20multi,a%20layered%20approach%20is%20complexity.