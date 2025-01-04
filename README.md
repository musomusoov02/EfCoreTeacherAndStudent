EF Core Teacher and Student Console Application
Prerequisites
.NET 7.0 SDK or later
Visual Studio or any C# IDE
SQL Server or PostgreSQL
Setup
Create a Console Application project in your IDE.
Configure the appsettings.json file like this:
json
Copy code
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=your_server;Database=your_db;User Id=your_user;Password=your_password;"
  }
}
Run the following commands to add migrations and update the database:
bash
Copy code
dotnet ef migrations add InitialCreate
dotnet ef database update
This setup helps you configure an EF Core application for managing teacher and student data.
