---
id: {0006}
date: {11/05/2023}
---

# Decision to Use NoSQL for Data Store

## Context and Problem Statement
As part of my system design, I wanted to model and understand how different components/layers within the system interact with each other. This decision will explore a few considered options for behavior diagrams

## Decision Drivers

* Requirement to see the flow of interactions
* Need to visualize the behavior of the system
* To help create the level 3 C4 diagram

## Considered Options

* Use Case Diagrams
* Sequence Diagrams
* Communication Diagrams

## Decision Outcome

Chosen option: "Sequence Diagrams" because

They are well suited for modeling the interaction between different components over a time period making them ideal to capture the behavior of the system. Alongside this, they show how data is stored and retrieved

### Consequences

* Good because it shows a clear visualization of system behavior helping other developers/stakeholders understand system behavior better
* Good because the diagram will aid in the development of the level 3 C4 diagram
* Bad because they focus more on technical details, so may not be suited for people with less technical skills

## More Information

This decision is aligned with our goal to capture and communicate system behavior
