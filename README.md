# PersonalVault

**PersonalVault** is a C# application built with WPF and UWP that securely stores and manages your credentials (like passwords for various accounts). The application uses AES encryption to ensure that your data remains safe. The credentials are stored in a SQL Server database, with a straightforward interface for adding, retrieving, and deleting entries.

## Features

- **Encryption**: AES encryption ensures that your passwords are securely stored.
- **CRUD Operations**: Add, retrieve, and delete credentials easily.
- **Service-Based Architecture**: The application is structured using services for better separation of concerns and maintainability.
- **WPF and UWP Support**: The UI is built using WPF, with potential support for UWP through integration.

## Technologies Used

- **C#**
- **WPF**
- **UWP**
- **SQL Server**
- **Entity Framework Core**
- **AES Encryption**

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- Visual Studio with WPF and UWP development workloads installed.

1. **Clone the repository:**

 ```bash
 git clone https://github.com/your-username/PersonalVault.git
 cd PersonalVault
```

2. **Set up the database:

- Create a new SQL Server database.
- Update the connection string in appsettings.json or in your VaultDbContext class with the details of your SQL Server database.

3. **Build and run the application:

- Open the solution in Visual Studio.
- Build the project using the appropriate build configuration (Debug or Release).
- Run the application using the Visual Studio debugger or by launching the compiled executable.
