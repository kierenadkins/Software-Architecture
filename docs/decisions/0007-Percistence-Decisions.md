---
id: {0007}
date: {11/11/2023}
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

Cosmos db ability automatically scale to adapt to data increasing enabling efficient resource allocation and management of workloads. "Azure Cosmos DB offers automatic scaling, which means that you can easily scale up or down your database without any downtime" (Bhatt, 2023)
Cosmos also offers backup and restore features to ensure the ability to recover data when needed. Finally the Cosmos offers us ACID properties ensuring that we still follow Atomicity, Consistency, Isolation and durability. "Each transaction provides ACID (Atomicity, Consistency, Isolation, Durability) property guarantees."(StefArroyo, 2023)


### Consequences


* Good because cosmos alligns with our functional requirements of scability and availability 

* Good because Cosmos surports global distribution, allowing data to follow accross the globe seamlessly

* Good because Cosmos surports ACID properties ensuring we maintain data consistency.

* Bad because some of our data might be classed as realtional and this sould be less efficient with query perfromance for that data

* Bad because if our system needs to transition to a diffrent database in the future, the migration could be very costly and complex.

## Status
* Approved

## More Information
Bhatt, V. a. P. B. S. (2023, April 23). Azure Cosmos DB vs. Azure SQL Database: Which One is Right for Your Data Needs? The Tech Guy. https://the-tech-guy.in/2023/04/14/azure-cosmos-db-vs-azure-sql-database/#:~:text=Query%20Language%3A%20Azure%20Cosmos%20DB,is%20the%20way%20to%20go.

StefArroyo. (2023, September 22). Transactional batch operations in Azure Cosmos DB using the .NET or Java SDK. Microsoft Learn. https://learn.microsoft.com/en-us/azure/cosmos-db/nosql/transactional-batch?tabs=dotnet

