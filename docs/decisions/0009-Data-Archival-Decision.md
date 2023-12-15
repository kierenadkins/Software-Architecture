---
id: {0009}
date: {13/11/2023}
---
# Decision to archive data

## Context and Problem Statement
One of our non-functional requirements is performance, and this is applicable to our database. with this in mind with the increasing usage of the main database and the accumulation of old data we must consider removing old data. We need to figure out a suitable time period in which to remove old data.

## Decision Drivers

* Performance being impacted by unsustainable amounts of data
* Database becoming to big

## Considered Options

* Archiving data after 3 years
* Archiving data after 5 years
* Archiving data after 10 years
* No archiving of data

## Decision Outcome

Chosen option: "Archiving data after 10 years", because

The primary data to be stored within the database are visa applications. With this in mind we must consider that there may be some long term visas that can be valid for upto 10 years. BIQ has emphasized that the ability to extend visas can span "or 2, 5 or 10 years" however "that you are only allowed to stay a maximum of 6 months during any given year." (Breytenbachs Immigration Consultants Limited. 2023, October 30)

with this in mind, our goal is to balanace preserving visa information and perventing database from becoming unmaintainable and losing performance. therefore the decision to delete old data after 10 years will ensure that the systems performance is optimised.


### Consequences


* Good because the database will not become unmaintainable

* Good because the database will clear old data that we no longer need

* bad because there may be cases where people may want to view old data.

* bad because 10 years is along time for data to be sat around and not being used.

## Status
* Pending

## More Information

Breytenbachs Immigration Consultants Limited. (2023, October 30). UK Visitor Visa - all your questions answered by our experts! Breytenbachs Immigration Consultants. https://www.bic-immigration.com/uk-immigration/visitor-visa/#:~:text=Length%20of%20Stay%20on%20the%20UK%20Visitor%20Visa&text=These%20visas%20are%20valid%20for,for%20up%20to%20eleven%20months.