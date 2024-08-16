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

## Usage

1. **Add a Credential:**

   You can add a new credential by specifying the service, username, password, and an optional comment.

2. **Retrieve a Credential:**

   Retrieve and decrypt credentials by providing the service and username.

3. **Delete a Credential:**

   Delete credentials using their unique ID.

## Contributing

Contributions are welcome! Whether you're fixing bugs, improving the code, or adding new features, your help is appreciated.

To contribute to this project, follow these steps:

1. **Fork the Repository:**

   Start by forking the repository to your own GitHub account:

   ```bash
   git clone https://github.com/your-username/PersonalVault.git
   cd PersonalVault
   ```

2. **Create a New Branch:**

   Create a new branch for your work:

   ```bash
   git checkout -b your-feature-branch
   ```

   Replace `your-feature-branch` with a descriptive name for your branch.

3. **Make Your Changes:**

   Make your code changes or additions.

4. **Commit Your Changes:**

   Once your changes are ready, commit them with a meaningful commit message:

   ```bash
   git add .
   git commit -m "Description of the changes made"
   ```

5. **Push to Your Fork:**

   Push your changes to your forked repository:

   ```bash
   git push origin your-feature-branch
   ```

6. **Submit a Pull Request:**

   Go to the original repository on GitHub and create a pull request from your fork. Provide a clear description of what you've done and why your changes should be merged.

### Guidelines

- Please ensure your code follows the project's coding standards.
- Write clear, concise commit messages.
- Update documentation as necessary.
- Test your changes to avoid introducing bugs.

Thank you for your contributions!

## How to Create a Release

1. **Create a New Tag:**

   First, create a new tag in your local Git repository that corresponds to the release version:

   ```bash
   git tag v1.0.0
   git push origin v1.0.0
   ```

   Replace `v1.0.0` with your version number.

2. **Create a GitHub Release:**

   - Go to your repository on GitHub.
   - Click on the "Releases" tab, which is usually located under your repository name, along with "Code", "Issues", and "Pull requests".
   - Click the "Draft a new release" button.
   - In the "Tag version" field, select the tag you created (e.g., `v1.0.0`).
   - Give your release a title (e.g., `v1.0.0 - Initial Release`).
   - Write a description for your release, including any new features, bug fixes, and other important changes.

3. **Attach Compiled Binaries (Optional):**

   If your project requires users to download compiled binaries or installers:

   - Scroll down to the "Attach binaries by dropping them here or selecting them" section.
   - Upload the compiled files (e.g., `.exe`, `.zip`, `.dll` files).

4. **Publish the Release:**

   - Once everything is set, click the "Publish Release" button.
   - Your release will now be available for others to download from the "Releases" section of your GitHub repository.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.