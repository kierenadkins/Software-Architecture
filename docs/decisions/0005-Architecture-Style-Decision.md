---
id: {0005}
date: {27/10/2023}
---
# Decision to use an Clean/Onion Architecture

## Context and Problem Statement
I have been tasked with building a visa processing system that will advise, guide and process visa applications. It must be able to interact with visa issuing authority of different countries. The system should have access to the latest information

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

Chosen option: "Layered using clean architecture with Data Centric Princables Of CQRS and OpenAPI  Rest API", because

After some inital research i believe that the propsed architecture will excell in my non-functional requirements of Scalability, Security, Avalaibility and performance. Firstly it will offer scalability by allowing each layer to be independently scaled to meet high levels of traffic, allowing us to efficiently allocate resources where they are needed, eg bossting the presentation layer to handle a surge in use. In terms of security we can add security to each layer independantly, this can include Authentication, Authorization, Data encryption and Input validation to their respective layer boosting secruity of the whole system. While availability can not be gareenteed, clean architecture boosts testability to ensure that we are able to seiftly identify and address any issues. This alongside designing each layer to be designed to reduce redundancy and fault tolerance and using load balancers should help us minimize downtime and achieve the non-functional requirement. lastly in terms of performance by using cqrs we can enable efficient read/write seperation, simplifed intergration and thus enchance system performance

Usability And Accessibility will be implemente on the frontend.

### Consequences

* Good, because it meets non-functional requirements
* Good, because the software will be testable and maintanable and easier to read.
* Good as it will follow domain driven design principles making it well suited for the project
* Bad, because Clean architecture can be more complex and might introduce a steeper learning curve for developers
* Bad, because there is extra overhead and boiler plate code slowing down development

## More Information

