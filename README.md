# 🗳️ Survey Basket

A user-friendly RESTful API for creating and sharing surveys. Users can post questions, receive votes, and analyze responses in real-time to gain valuable insights.

---

## 📋 Table of Contents

- [About the Project](#about-the-project)
- [Features](#features)
- [Tech Stack](#tech-stack)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
  - [Configuration](#configuration)
  - [Running the Application](#running-the-application)
- [API Overview](#api-overview)
- [Authentication](#authentication)
- [Project Structure](#project-structure)
- [Contributing](#contributing)

---

## 📖 About the Project

**Survey Basket** is a backend API built with ASP.NET Core that enables users to create surveys, share them, collect votes, and view results in real time. It follows clean architecture principles and applies industry-standard patterns such as the Result Pattern and Options Pattern.

---

## ✨ Features

- 🔐 **JWT Authentication & Authorization** — Secure token-based access with refresh token support
- 👥 **Role-Based Access Control** — Different permissions for admins and regular users
- 📝 **Survey Management** — Create, update, delete, and retrieve surveys with questions
- 🗳️ **Voting System** — Users can cast votes on survey questions
- 📊 **Real-Time Results** — Instant analysis and response aggregation
- 🧩 **Claims-Based Identity** — Fine-grained authorization using claims
- 🏗️ **Result Pattern** — Consistent and predictable API response structure
- ⚙️ **Options Pattern** — Strongly typed configuration management

---

## 🛠️ Tech Stack

| Layer | Technology |
|---|---|
| Language | C# (.NET) |
| Framework | ASP.NET Core Web API |
| Auth | JWT Bearer Tokens, ASP.NET Core Identity |
| ORM | Entity Framework Core |
| Database | SQL Server |
| Docs | Swagger / OpenAPI |

---

## 🚀 Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (version 8.0 or later)
- [SQL Server](https://www.microsoft.com/en-us/sql-server) (or SQL Server Express / LocalDB)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)

### Installation

1. **Clone the repository:**

```bash
git clone https://github.com/Ahmd-Naser/survey-basket.git
cd survey-basket
```

2. **Restore dependencies:**

```bash
dotnet restore
```

### Configuration

1. Open `SurveyBasket.Api/appsettings.json` and update the connection string and JWT settings:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=SurveyBasketDb;Trusted_Connection=True;"
  },
  "JWT": {
    "Key": "your-secret-key-here",
    "Issuer": "SurveyBasketApi",
    "Audience": "SurveyBasketClient",
    "ExpiryMinutes": 60
  }
}
```

2. Apply database migrations:

```bash
cd SurveyBasket.Api
dotnet ef database update
```

### Running the Application

```bash
dotnet run --project SurveyBasket.Api
```

The API will be available at `https://localhost:5001` by default.
Navigate to `https://localhost:5001/swagger` to explore the API via Swagger UI.

---

## 📡 API Overview

| Method | Endpoint | Description |
|--------|----------|-------------|
| POST | `/api/auth/register` | Register a new user |
| POST | `/api/auth/login` | Login and receive JWT token |
| GET | `/api/polls` | Get all surveys/polls |
| POST | `/api/polls` | Create a new survey (Admin) |
| PUT | `/api/polls/{id}` | Update a survey (Admin) |
| DELETE | `/api/polls/{id}` | Delete a survey (Admin) |
| POST | `/api/polls/{id}/vote` | Submit a vote |
| GET | `/api/polls/{id}/results` | Get survey results |

> Full documentation is available via Swagger UI when running the application.

---

## 🔐 Authentication

This API uses **JWT Bearer Authentication**. To access protected endpoints:

1. Register or log in via the `/api/auth` endpoints.
2. Copy the returned `token` from the response.
3. Include it in the `Authorization` header of subsequent requests:

```
Authorization: Bearer <your_token_here>
```

---

## 🗂️ Project Structure

```
survey-basket/
│
├── SurveyBasket.sln
└── SurveyBasket.Api/
    ├── Controllers/        # API controllers
    ├── Models/             # Domain models & entities
    ├── DTOs/               # Data Transfer Objects
    ├── Services/           # Business logic layer
    ├── Persistence/        # EF Core DbContext & migrations
    ├── Authentication/     # JWT configuration & handlers
    ├── Abstractions/       # Interfaces & result pattern
    └── Program.cs          # App entry point & DI setup
```

---

## 🤝 Contributing

Contributions are welcome! Please follow these steps:

1. Fork the repository
2. Create a new branch (`git checkout -b feature/your-feature`)
3. Commit your changes (`git commit -m 'Add some feature'`)
4. Push to the branch (`git push origin feature/your-feature`)
5. Open a Pull Request

---

> Built with ❤️ by [Ahmd-Naser](https://github.com/Ahmd-Naser)
