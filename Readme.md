# Registration API

## Project Overview
This project is a Registration API built using **.NET 9.0**. It provides various endpoints to manage users, including registration,
OTP generation and verification, PIN setup and verification, biometric management, and bulk user creation.
The API follows best practices and standards, including proper logging and error handling.

### Features:
- User Registration and Bulk User Creation
- OTP Generation and Verification
- PIN Setup and Verification
- Biometric Enabling and Disabling
- User Status Update and Migration
- Error Handling and Logging
- Integrated with Entity Framework Core and SQL Server
- Swagger UI for API Documentation and Testing

## Prerequisites
- .NET 9.0 SDK
- SQL Server (local or remote)
- Visual Studio or VS Code
- Postman or any API testing tool

## Installation
1. download file
2. Update the configuration in `appsettings.json`:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=YOUR_SERVER;Database=RegistrationAPI;Trusted_Connection=True;"
     }
   }
   ```

3. Install dependencies:
   ```bash
   dotnet restore
   ```

## Database Migration
1. Add a new migration:
   ```bash
   dotnet ef migrations add InitialCreate
   ```

2. Update the database:
   ```bash
   dotnet ef database update
   ```

## Running the Application
Start the application using:
```bash
   dotnet run --project RegistrationAPI
```
The API will be available at `https://localhost:7242`.

## API Documentation
Swagger documentation is available at:
```
https://localhost:7242/swagger
```

## Testing the API
### Using Postman:
1. Open Postman and import the provided Postman collection (if available).
2. Test the following endpoints:
   - **User Registration:**
     ```
     POST /api/users
     {
       "firstName": "John",
       "lastName": "Doe",
       "email": "john.doe@example.com"
     }
     ```
   - **Bulk User Creation:**
     ```
     POST /api/users/bulk
     {
       "users": [
         {"firstName": "Alice", "lastName": "Brown", "email": "alice.brown@example.com"},
         {"firstName": "Bob", "lastName": "Jones", "email": "bob.jones@example.com"}
       ]
     }
     ```
   - **OTP Generation:**
     ```
     POST /api/users/otp/send
     {
       "userId": 1,
       "phoneNumber": "1234567890",
       "email": "user@example.com",
       "contactInfo": "1234567890"
     }
     ```
   - **OTP Verification:**
     ```
     POST /api/users/otp/verify
     {
       "contactInfo": "1234567890",
       "otpCode": "1234"
     }
     ```
   - **PIN Setup:**
     ```
     POST /api/users/pin/setup
     {
       "userId": 1,
       "pin": "123456"
     }
     ```
   - **Biometric Enabling:**
     ```
     POST /api/users/biometric/enable
     {
       "userId": 1,
       "isEnabled": true
     }
     ```

## Logging and Debugging
All log files are generated using Microsoft.Extensions.Logging and are displayed in the console during runtime.

## Troubleshooting
- **Database not found:** Make sure your connection string is correct and the database is created using EF migrations.
- **Endpoints not working:** Check if the application is running on the correct port.
- **OTP Expiry Issues:** OTPs are set to expire after 30 seconds. Make sure to verify them within that timeframe.


