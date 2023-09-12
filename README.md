# Architecture Model
![ArchitectureModel](https://github.com/Jorsg/TechnicalTest/assets/48104851/f37d9de6-4b1a-4e2d-a97f-77bb9f8bfc7b)

- How would you compose the data needed for the notifications?
- The order data would be stored in a centralized database, allowing the system to easily access the information required for notifications.
  When the time is right, the Notification Service would retrieve this data from the database and use it to generate customized notifications that would be sent through appropriate channels, such as push notifications or emails.
  #
  
- How would you make sure you don't create duplicate orders in a concurrent scenario or how you handle race conditions?
- Use the broker/queus, When the services received an order from restaurant, not proccesing immediately, it could be put into a message queue. This ensures that orders are processed in an orderly fashion and avoids duplicates at the time of ingestion.
- Also, we could make validation before processing an order, the system can check whether a similar order already exists in the database. Unique identifiers or order-specific information.
- The last option is to implement a transaction over the records in the database. It can be used to ensure that only one concurrent transaction can modify a specific order at a time.
  
 #
- How would you coordinate a distributed transaction?
- Distributed database system
- Implementation of a transaction log: A distributed transaction log can be maintained to track the status and progress of transactions across all involved nodes, allowing for more accurate coordination and recovery in case of failures.
