# payment-gateway

This application provides the basic functionality of a payment gateway through API calls that a merchant can utilise to process payments with banks.

Notable features include:
- .NET Core 2.1 Web API
- EF Core's InMemory Provider for storage
- Swagger to test APIs
- API client
- Bank simulator
- Docker for containerization
- CI using GitLab
- logging/metrics??


Assumptions:
- For the purposes of this challenge, a simple inmemory storage solution is used with EF Core instead of a full Microsoft SQL Server database, but on a production solution the latter would be the appropriate choice
- The bank simulator only needs to provide a meaningful response to the gateway and does not need to include any business logic within the app to validate the request data
- Ideally, the credit card information should be encrypted and the card number should be masked and validated
