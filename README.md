# Koleh.Shop.Projects

[![.NET](https://img.shields.io/badge/.NET-9.0-blueviolet)](https://dotnet.microsoft.com/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

A modern, scalable, and maintainable web application built with **ASP.NET Core Minimal APIs**, embracing **Clean Architecture** and **Domain-Driven Design (DDD)** principles. This project implements **CQRS** using **MediatR** for clear separation of concerns, robust command/query handling, and a clean, testable codebase. It supports multiple databases (**MongoDB**, **SQL Server**, **PostgreSQL**) and leverages **Entity Framework Core**, **FluentValidation**, and **AutoMapper** for a production-ready solution.

## 🚀 Key Features

- **Minimal APIs**: Lightweight, high-performance endpoints using ASP.NET Core Minimal APIs.
- **Clean Architecture**: Organized into layers for maintainability, testability, and scalability.
- **Domain-Driven Design (DDD)**: Implements **Aggregate Root** patterns to model complex business domains.
- **CQRS with MediatR**: Separates read and write operations for better performance and clarity.
- **FluentValidation**: Provides robust, declarative validation for inputs.
- **Multi-Database Support**: Seamlessly integrates with **MongoDB** (NoSQL), **SQL Server**, and **PostgreSQL** using **Entity Framework Core**.
- **AutoMapper**: Simplifies object-to-object mapping to reduce boilerplate code.
- **Modular & Extensible**: Designed to easily accommodate new features and database providers.

## 🛠️ Tech Stack

- **ASP.NET Core Minimal APIs**: For building fast and lightweight APIs.
- **Entity Framework Core**: ORM for SQL Server and PostgreSQL database operations.
- **MongoDB**: NoSQL database for flexible data storage.
- **MediatR**: Implements CQRS and mediates commands/queries.
- **FluentValidation**: Declarative and expressive validation rules.
- **AutoMapper**: Efficient mapping between objects.
- **.NET 8.0**: The latest .NET framework for modern development.

## 🎯 Why This Project?

This project serves as a **reference implementation** for building modern .NET applications using best practices. Whether you're learning **DDD**, **CQRS**, or **Minimal APIs**, or building a production-grade application, this codebase provides a solid foundation. It’s designed to be scalable, testable, and easy to extend, making it ideal for developers and teams exploring advanced architectural patterns.

## 📋 Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [MongoDB](https://www.mongodb.com/try/download/community) (if using NoSQL)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or [PostgreSQL](https://www.postgresql.org/download/) (for relational databases)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) or [VS Code](https://code.visualstudio.com/) with C# extensions

## 🚀 Getting Started

1. **Clone the repository**:
   ```bash
   git clone https://github.com/yourusername/Koleh.Shop.Projects.git
   cd Koleh.Shop.Projects
   ```

2. **Configure database connections**:
   - Update `appsettings.json` with your connection strings for MongoDB, SQL Server, or PostgreSQL.
   - Example for SQL Server:
     ```json
     "ConnectionStrings": {
       "SqlServer": "Server=localhost;Database=KolehShop;Trusted_Connection=True;"
     }
     ```

3. **Restore dependencies**:
   ```bash
   dotnet restore
   ```

4. **Run the application**:
   ```bash
   dotnet run --project src/Koleh.Shop.Projects.WebApi
   ```

5. **Access the API**:
   - Open your browser or Postman and navigate to `https://localhost:5001/api` (or the configured port).
   - Check out the Swagger documentation at `/swagger` for API endpoints.

## 🧪 Running Tests

The project includes unit tests to ensure code quality. To run tests:

```bash
dotnet test
```

## 🤝 Contributing

Contributions are welcome! To contribute:

1. Fork the repository.
2. Create a new branch: `git checkout -b feature/your-feature-name`.
3. Commit your changes: `git commit -m "Add your feature"`.
4. Push to the branch: `git push origin feature/your-feature-name`.
5. Open a Pull Request.

Please ensure your code follows the project's coding standards and includes tests where applicable.

## 📜 License

This project is licensed under the [MIT License](LICENSE).

## 🙌 Acknowledgments

- Inspired by [Clean Architecture](https://github.com/ardalis/CleanArchitecture) by [ardalis](https://github.com/ardalis).
- Thanks to the .NET community for amazing tools and libraries like MediatR, FluentValidation, and AutoMapper.

---

Built with ❤️ using .NET and modern architectural patterns.  
Star ⭐ this repository if you find it useful!
