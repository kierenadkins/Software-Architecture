---
id: {0012}
date: {13/11/2023}
---
# Decision to use Azure Monitoring

## Context and Problem Statement
I want to use logging within the system and record the logs. We need a solution that provides logging capabilities that is scalable, secure and that we can monitor.

## Decision Drivers

* Scalability, ensuring that the solution can scale to handle the voulme of logs

* Secure, to ensure confidentiality, Integrity and prevention of unauthorized access of our logs.

## Considered Options

* Google Cloud Logging
* Azure Monitoring
* Custom Logging Implementation

## Decision Outcome

Chosen option: "Azure Monitoring", because
It is both scalable and alligns with our requirements. Its intergration with azure exosystem, where we already have Cosmos Db, allows us to access our resources in one location to make navigation simpler. Azures promise of avaialbility ensures 99.9% of run time and is comiited to security and compliance standards.

### Consequences

* Good as scalable

* Good because its secure

* bad because learning curve

* bad because cost

## More Information
