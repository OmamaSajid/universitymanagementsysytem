# University Desktop Application

## Description
The University Desktop Application is a comprehensive tool designed to streamline administrative tasks and enhance communication within the university community. Developed using C# and integrated with an SQL database, this application provides a user-friendly interface for managing student records, course information, faculty details, and more.

## Features
- **Student Management**: Easily add, update, and delete student records. View detailed information about each student, including personal details, academic history, and enrollment status.
- **Course Management**: Manage course offerings, including course schedules, instructors, and enrollment information. Track prerequisites and course dependencies.
- **Faculty Management**: Maintain a database of faculty members, including contact information, teaching assignments, and research interests.
- **Administrative Tools**: Access administrative tools for user management, system configuration, and data backup. Ensure data integrity and security with role-based access controls.

## Installation
1. Clone the repository to your local machine.
2. Open the project in Visual Studio or your preferred C# IDE.
3. Ensure your SQL Server instance is running.
4. Update the connection string in the `app.config` file to point to your SQL Server database.
5. Ensure you use the provided database file (myproject.bacpac) included in the repository.
6. Build and run the application.

## Importing Database to SQL Server
1. Open SQL Server Management Studio (SSMS).
2. Connect to your SQL Server instance.
3. In the Object Explorer, right-click on the database where you want to import the University database.
4. Select "Tasks" > "Import Data...".
5. Follow the Import Wizard to specify the data source, destination, and mapping settings.
6. Choose the provided database file (`myproject.bacpac`) as the data source.
7. Complete the import process and verify that the database schema and data have been successfully imported.

## Usage
1. Upon launching the application, log in using your administrator credentials.
2. Navigate through the intuitive user interface to access different modules.
3. Use the search functionality to quickly find specific students, courses, or faculty members.
4. Perform CRUD operations as needed to manage university data.
5. Ensure regular backups of the SQL database to prevent data loss.

## Contributing
We welcome contributions from the community to improve the functionality and usability of the University Desktop Application. If you would like to contribute, please follow these steps:
1. Fork the repository.
2. Create a new branch for your feature or bug fix.
3. Make your changes and ensure all tests pass.
4. Submit a pull request with a detailed description of your changes.
## Contact
For support, feedback, or questions, please contact:
- Omama Sajid: omamasajid345@gmail.com

