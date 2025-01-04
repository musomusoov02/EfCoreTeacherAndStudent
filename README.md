EF Core Teacher and Student Console Application

Prerequisites
1. .NET 7.0 SDK or later
2. Visual Studio or any C# IDE
3. SQL Server or PostgreSQL

Setup
1. Create a Console Application project in your IDE.
2. Configure the appsettings.json file like this:

```
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=your_server;Database=your_db;User Id=your_user;Password=your_password;"
  }
}
```
3. Run the following commands to add migrations and update the database:
```
dotnet ef migrations add InitialCreate
dotnet ef database update
```

This setup helps you configure an EF Core application for managing teacher and student data.
