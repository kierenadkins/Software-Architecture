---
id: {0013}
date: {18/11/2023}
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

Azure also has "Azure Monitor Alerts" which "notify you of critical conditions and can take corrective action. Alert rules can be based on metric or log data." (Rboucher, 2023) This will also us to quickly flag errors in the system which can be fix promptly to ensure avaliability of the system.

## Status
* Pending

### Consequences

* Good as scalable

* Good because its secure

* bad because learning curve

* bad because cost

## More Information
Rboucher. (2023, December 12). Azure Monitor overview - Azure Monitor. Microsoft Learn. https://learn.microsoft.com/en-us/azure/azure-monitor/overview