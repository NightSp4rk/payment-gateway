# Payment Gateway

This application provides the basic functionality of a payment gateway through API calls that a merchant can utilise to process payments with banks.

Notable features include:
- .NET Core 2.2 Web API
- EF Core's InMemory Provider for storage
- Swagger to test APIs
- API client
- Bank simulator app
- Docker for containerization
- Continuous integration and testing using GitLab


## Assumptions/Comments

- For the purposes of this challenge, a simple inmemory storage solution is used with EF Core instead of a full Microsoft SQL Server database, but on a production solution the latter would be the appropriate choice
- The bank simulator only provides a meaningful response to the gateway and does not include any business logic within the app to validate the request data
- Ideally, the credit card information should be encrypted and there should be proper authentication
- Logging and metrics can be added through Kubernetes on GitLab
- Validations can be greatly improved
- Faced issues with Dockerized version when calling Bank Simulator and for mocking API with Wiremock for test cases


## Requirements

- .NET Core 2.2
- Docker Desktop for Windows


## Usage

**Start bank simulator**
- Go to "payment-gateway/PaymentGateway.BankSimulator/BankSimulator"
- Run command "docker-compose up"

**Start the Web API**
- Go to "payment-gateway/PaymentGateway"
- Run command "docker-compose up"

**Launch**
- Go to "https://localhost:44318/swagger/" to open the Swagger UI, or use Postman to test APIs
- Two API calls available:
    - Create a new payment
    - View a previous payment

**Create new payment**
```curl
POST /api/v1/ProcessPayment
```

json example
{
  "id": "f16bf40d-8bcb-4084-befd-aff2108806c1",
  "cardNumber": "5500 0000 0000 0004",
  "cardHolderName": "string",
  "expiryYear": 0,
  "expiryMonth": 0,
  "amount": 0,
  "currency": "string",
  "cvv": "string",
  "bankSuccess": false
}


**View previous payment**
```curl
GET /api/v1/GetPayment
```

e.g. https://localhost:44318/api/v1/Payment?id=8d652bac-a4fa-4410-a8a7-a8b3e3d6b80b