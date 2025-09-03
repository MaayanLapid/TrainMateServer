# TrainMate Server

This is the **backend API** for the TrainMate fitness tracking application.  
It is built with **ASP.NET Core 7** and communicates with a **SQL Server** database.

---

## Key Features

- RESTful API for managing:
  - Trainees
  - Exercise types
  - Exercises
  - Workouts
- Entity Framework Core for database access and migrations
- Authentication & authorization support
- Swagger UI documentation
- CORS enabled for integration with the React frontend

---

## Getting Started

### Prerequisites

- [.NET 7 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/YOUR_USERNAME/TrainMateServer.git
2. Set your connection string
Update the connection string in appsettings.json:

    "ConnectionStrings": {
      "DefaultConnection": "Server=YOUR_SERVER_NAME; Database=TrainMateDb; Trusted_Connection=True;TrustServerCertificate=True;"
    }

3. Apply database migrations
   ```bash
   dotnet ef database update
4. Run the application
   ```bash
   dotnet run
   
### Default URL for Swagger: https://localhost:7225/swagger/index.html

## Technologies Used
- ASP.NET Core 7
- Entity Framework Core
- SQL Server
- LINQ & C#
- Swagger
