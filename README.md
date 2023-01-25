# ComITProject - HealthCom

This is a individual project for the ComIT 2022 Class by Anh Tu Nguyen.

It is a health clinic management web application that allows staff members to view, store, and update patients' health records. 
Additionally, patients can access and edit their personal information.

Tech stack: Visual Studio 2022, C#, MS SQL Server, SQL, Blazor 
Frameworks: .NET Entity Framework, .NET Identity Framework 

Detailed Explanation:
The project includes 2 main folders:
1. ComITProject.Dal: contain the database portion of the application. 
    - Model folder: each .cs file represent one table of the database. Each file describes the column data type and data parameter along with primary/foreign key
    - Migrations folder: each .cs file represent one migration of the model database to Microsoft SQL Server
    - After building the model, it was migrated to Microsoft SQL Server with the use of ASP.NET Entity Framework
    
2. ComITProject.Web: contain the web portion of the application
    - Pages folder: contains all the pages of the web application. Each page is designed using Blazor with C# language for back-end and a combination of C#, HTML, CSS for front-end
    - Services folder: contains the interfaces and services of the application. CRUD operations are done with the ASP.NET Entity Framework
3. Other features of the project:
    - Application of ASP.NET Identity Framework with 3 specific roles: SysAdmin, Doctor, Patient, and the implementation of access control
    - Application of Bootsrap framework to create front-end presentation
    - Application of Modal form with JavaScript in Create, Edit and Delete functions (Located in Shared Folder)
    - Database is stored in Microsoft SQL Server and data is manipulated with SQL language
