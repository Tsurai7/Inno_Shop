Inno_shop consists of 2 micoservices:
  User management service:
    - RESTful api for creating, reading, updating and deleting users;
    - Providing registration and login actions using JWT tokens;
    - Implementation of verification users using emails.;
    - Tests using xUnit.

  Products management service:
    - RESTful api for creating, reading, updating and deleting products;
    - Providing searching and filtering products using CQRS and MediatR;
    - Error handling using Custom exceptions middleware abd Fluent Validation;
    - Only authorized users can manipulate products;
    - Tests using xUnit.

Project was implemented using Clean Architecture and it also has docker support.
