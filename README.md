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


## Assumptions

- For the purposes of this challenge, a simple inmemory storage solution is used with EF Core instead of a full Microsoft SQL Server database, but on a production solution the latter would be the appropriate choice
- The bank simulator only provides a meaningful response to the gateway and does not include any business logic within the app to validate the request data
- Ideally, the credit card information should be encrypted and there should be proper authentication
- Logging and metrics can be added through Kubernetes on GitLab
- Credit card validation can be improved


## Requirements

- .NET Core 2.2
- Docker for Windows


## Usage

# Start bank simulator
