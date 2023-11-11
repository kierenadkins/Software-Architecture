---
id: {0005}
date: {27/10/2023}
---
# Decision to NoSql for Data Store

## Context and Problem Statement
At this point in design we need to start thinking about how our system will access and store data. We need a data store that is secure and avaiable.

## Decision Drivers

* A database that is scalable to handle increased useage
* Easily to distribute globally
* Schema Flexibility to deal with applications that may need diffrent requirements

## Considered Options

* MySql
* NoSql Cosmos
* Sql & NoSql 

## Decision Outcome

Chosen option: "Cosmos DB", because

While Sql would be good for many aspects of the system, Azure Cosmos DB benefits from having global distribution, multi-model flexibility, backups and supports ACID properties. For our system we expect that we can operate world wide to and thus data can be accessed across the globe quickly and effectively.

The initial prototype will standardize all visa applications, we need to ensure that we have a database that offers us schema flexibility  to accommodate the evolving requirements of each visa type's application process, recognizing that no two visa applications will be bound to a specific schema. I would also like to note that Cosmos Db is designed to handle both structured, semi-structured and unstructured data meaning it can cover our whole systems data. For this reason i have decided to remove the complexity of using both SQL and NoSQL together for this project.

Cosmos db ability automatically scale to adapt to data increasing enabling efficient resource allocation and management of workloads.
Cosmos also offers backup and restore features to ensure the ability to recover data when needed. Finally the Cosmos offers us ACID properties ensuring that we still follow Atomicity, Consistency, Isolation and durability.


### Consequences


* Good because cosmos alligns with our functional requirements of scability and availability 

* Good because Cosmos surports global distribution, allowing data to follow accross the globe seamlessly

* Good because Cosmos surports ACID properties ensuring we maintain data consistency.

* Bad because some of our data might be classed as realtional and this sould be less efficient with query perfromance for that data

* Bad because if our system needs to transition to a diffrent database in the future, the migration could be very costly and complex.

## More Information

