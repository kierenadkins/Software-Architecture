---
id: {0009}
date: {15/11/2023}
---
# Decision to archive data

## Context and Problem Statement
After thinking of our data within the system, we now need to think about the need of securely storing sensitive data such as user passwords. We must implement a hashing algorithm that our system will use to encrypt data before persistence. The choice of hashing algorithms will be cruital as it will impact the intergirity of user details.

## Decision Drivers

* securing user credentials agaisnt attacks such as brute-forces.

## Considered Options

* bcrypt
* Argon2
* SHA-256

## Decision Outcome

Chosen option: "sha-256", because

The algorithm offers a high level of security and is highly effective at hashing passwords with the use of a salt. It is widely supported across various platforms and will be effective with the technology stack i intend to use. From documentation i have seen the proccess seems easy to implement and will be vital in ensuring the intergrety of our users senesitive information.



### Consequences


* Good because it offers a high level of security

* Good because it is an widespead tech and is well established.

* bad because there is limited customizarion options for specfici use cases that may arise in the future

* bad because in the future we may have complications with security as technology advances and quantum computing becomes the norm, this may pose a thread to the security.

## More Information

Breytenbachs Immigration Consultants Limited. (2023, October 30). UK Visitor Visa - all your questions answered by our experts! Breytenbachs Immigration Consultants. https://www.bic-immigration.com/uk-immigration/visitor-visa/#:~:text=Length%20of%20Stay%20on%20the%20UK%20Visitor%20Visa&text=These%20visas%20are%20valid%20for,for%20up%20to%20eleven%20months.