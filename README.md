# Inno_shop

Inno_shop consists of 2 microservices:

## User Management Service:

- RESTful API for creating, reading, updating, and deleting users;
- Providing registration and login actions using JWT tokens;
- Implementation of user verification using emails;
- Tests using xUnit.

## Products Management Service:

- RESTful API for creating, reading, updating, and deleting products;
- Providing searching and filtering products using CQRS and MediatR;
- Error handling using Custom Exceptions Middleware and Fluent Validation;
- Only authorized users can manipulate products;
- Tests using xUnit.

The project was implemented using Clean Architecture and also has Docker support.

