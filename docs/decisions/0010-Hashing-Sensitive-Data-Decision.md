---
id: {0010}
date: {15/11/2023}
---
# Decision to Hash Sensitive Data

## Context and Problem Statement
After thinking of our data within the system, we now need to think about the need of securely storing sensitive data such as user passwords. We must implement a hashing algorithm that our system will use to hash data before persistence. The choice of hashing algorithms will be cruital as it will impact the intergirity of user details.

## Decision Drivers

* hashing makes storage and management more secure
* Each password will have a diffrent salt, so it makes it much more difficult to crack every password

## Considered Options

* bcrypt
* Argon2
* SHA-256

## Decision Outcome

Chosen option: "sha-256", because

The algorithm offers a high level of security and is highly effective at hashing passwords with the use of a salt. It is widely supported across various platforms and will be effective with the technology stack i intend to use. It is alos know that "SHA-256 to be one of the most secure hashing algorithms today" (Griškėnas & Griškėnas, 2023) . From documentation i have seen the proccess seems easy to implement and will be vital in ensuring the intergrety of our users senesitive information. It is also worth noting that "A password hash is a representation of your password that can't be reversed, but the original password may still be determined if someone hashes it again and gets the same result." - (Hunt, 2020) 

## Status
* Approved

### Consequences


* Good because it offers a high level of security

* Good as the data can never be reversed

* Good because it is an widespead tech and is well established.

* bad because there is limited customizarion options for specfici use cases that may arise in the future

* bad because in the future we may have complications with security as technology advances and quantum computing becomes the norm, this may pose a thread to the security.

## Status
* Approved

## More Information
Hunt, T. (2020, September 4). We Didn't Encrypt Your Password, We Hashed It. Here's What That Means: Troy Hunt. https://www.troyhunt.com/we-didnt-encrypt-your-password-we-hashed-it-heres-what-that-means/

Griškėnas, S., & Griškėnas, S. (2023, September 1). What is the SHA-256 algorithm? NordVPN. https://nordvpn.com/blog/sha-256/#:~:text=Many%20consider%20SHA%2D256%20to,cannot%20produce%20an%20identical%20hash.