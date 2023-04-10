# Probability Calculator
An artificially small probability calculator attempting to demostrate good code practices.

This project consists of a .NET 6 API and a Vue.js 2 frontend.

The main calculator logic resides in `Domain/Services/CalculatorService.cs` and was developed using a TDD approch. Refer to the commit history to see how the tests and production code evolved to the current state.

## Project setup

### Pre-requisites
- [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
- [Node.js](https://nodejs.org/en)

### Building and launching the project
In a terminal, `cd` into the root of the repository, and type the following commands:
```
dotnet build
dotnet run --project WebApi\WebApi.csproj
```
This will launch the API and you can browse the [Swagger docs](http://localhost:5000/swagger/index.html).

In another terminal, again from the repo root, type the following:
```
cd web-ui
npm install
npm run serve
```
This will launch the Vue.js frontend which can be viewed at http://localhost:8080/

### Run unit tests
From repo root:
```
dotnet test
```

### Run your end-to-end tests
From the `web-ui` folder:
```
npm run test:e2e
```
