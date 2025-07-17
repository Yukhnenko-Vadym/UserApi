# User API - Test task

This project is a simple .NET Web API to manage users. It supports basic CRD operations and input validation.

---

## 🚀 How to Run the Project

To run project you should have `.Net 8.0` or `higher`.

If you downloaded the project as a `.zip` file, unzip it and navigate to the project directory in your terminal. If you cloned the repository from Git, open a command prompt inside the root directory.

```bash
# Navigate to project directory
cd UserApi

# Run in HTTP mode without Swagger
dotnet run --urls=http://localhost:5258
# OR 
dotnet run

# To launch with Swagger
dotnet run --urls=http://localhost:5258/swagger
```
> **Note:** HTTPS is not used. All testing and API calls are performed over HTTP.

---

## 📌 API Endpoints

| Method | Endpoint             | Description       |
|--------|----------------------|-------------------|
| GET    | /api/v1/users        | Get list of users |
| POST   | /api/v1/users        | Create a new user |
| DELETE | /api/v1/users/{id}   | Delete user by ID |

---

## ✅ Validation Rules

- FullName: Required, 2–60 characters, Latin letters only
- Email: Required, valid format
- DateOfBirth: Required, must not be future date

---

## 🧪 Testing

All test materials are located in the `Tests/` directory.

### 📁 Postman Tests
- Directory: `Tests/Postman-Tests`
- File: `UserApi_PostmanCollection.json`
- How to run:
   1. Open Postman
   2. Import the collection file
   3. Run the requests manually or with the Collection Runner, when `UserApi` is running



**Postman Test Scenarios:**
- ✅ Create valid user
- ✅ Get list of users
- ✅ Invalid email returns 400
- ✅ Future date of birth returns 400

---

### 📁 Rest Assured (Java)
- Directory: `Tests/Rest-assured-Tests/UserApi.Tests`
- Requirements:
    - `Java 24+`
    - `Maven 3.9.11`

How to run:

```bash
cd Tests/Rest-assured-Tests/UserApi.Tests
mvn test
```

**Rest Assured Test Scenarios:**
- ✅ Valid user creation returns 201
- ✅ Invalid user input returns 400 with error details

---

## 📂 Project Structure Overview

```
UserApi/
├── Controllers/
│   └── UsersController.cs
├── Data/
│   └── UsersRepository.cs
├── Dtos/
│   └── Requests/
│       └── CreateUserRequest.cs
├── Filters/
│   └── ApiExceptionFilter.cs
├── Mappers/
│   └── UsersMapping.cs
├── Models/
│   └── UserModel.cs
├── Service/
│   ├── Interface/
│   │   └── IUsersService.cs
│   └── UsersService.cs
├── Tests/
│   ├── Postman-Tests/
│   │   └── UseApiTests.postman_collection.json
│   └── Rest-assured-Tests/
│       └── UserApi.Test/
│           ├── src/
│           ├── target/
│           ├── .gitignore
│           └── pom.xml
├── Validation/
│   └── UserValidator.cs
└── (other project files and directories)
```

---