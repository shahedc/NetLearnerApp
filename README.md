# NetLearnerApp
NetLearner: The Internet Resource Learning Helper built with ASP .NET Core

# Architecture

The current version of NetLearner on Github includes a shared .NET Standard Class Library, used by multiple web app projects. The web apps include:

* MVC: familiar to most ASP .NET developers
* Razor Pages: relatively new in ASP .NET
* Blazor: the latest offering from ASP .NET

![NetLearner Archicture: Web App + API](/design/architecture/NetLearner-AspNetCore31-Architecture.png "NetLearner Archicture: Web App + API")


Future updates will also include:

* Web API, exposed for use by other consumers
* JavaScript front-end web app(s)

Note that an ASP .NET Core web app can contain various combinations of all of the above. However, the purpose of the NetLearner application code is to demonstrate how to achieve similar results using all of the above. So, each of the web app projects will be developed in parallel, using a shared library.

# Shared Library

The shared library is a .NET Standard 2.1 library. This version was selected because .NET Core 3.x supports .NET Standard 2.1, as seen in the official documentation.

.NET Standard: https://docs.microsoft.com/en-us/dotnet/standard/net-standard

The shared library contains the following:

* Database Context: for use by Entity Framework Core
* Migrations: for EF Core to manage the (SQL Server) db
* Models: db entities, used by web apps
* Services: service classes to handle CRUD operations

Using terms from Clean Architecture references, you may think of the DB Context and Migrations as part of the Infrastructure code, while the Models and Services are part of the Core code. For simplicity, these are all kept in a single library. In your own application, you may split them up into separate assemblies named Core and Infrastructure.

# Running the Application

In order to run the web app samples, clone the following repository:

NetLearner:  https://github.com/shahedc/NetLearnerApp

Here, you will find at least 4 projects:

1. NetLearner.SharedLib: shared library project
2. NetLearner.Blazor: Blazor server-side web project
3. NetLearner.Mvc: MVC web project
4. NetLearner.Pages: Razor Pages web project

To create a local copy of the database:

1. Open the solution file in Visual Studio 2019
2. In the Package Manager Console panel, change the Default Project to “NetLearner.SharedLib” to ensure that EF Core commands are run against the correct project
3. In the Package Manager console, run the Update-Database command
4. Verify that there are no errors upon database creation

To run the samples from Visual Studio 2019:

1. Run each web project one after another
2. Navigate to the links in the navigation menu, e.g. Lists and Resources
3. Add/Edit/Delete items in any of the web apps
4. Create one or more lists
5. Create one more resources, assign each to a list
6. Verify that your data changes are reflected no matter which web app you use


![NetLearner MVC: Resource Lists](/design/screenshots/NetLearner-Lists.PNG "NetLearner MVC: Resource Lists")
NetLearner MVC: Resource Lists

![NetLearner MVC: Learning Resources](/design/screenshots/NetLearner-Resources.PNG "NetLearner MVC: Learning Resources")
NetLearner MVC: Learning Resources

![NetLearner Razor Pages: Resource Lists](/design/screenshots/NetLearner-Pages-Lists.PNG "NetLearner Razor Pages: Resource Lists")
NetLearner Razor Pages: Resource Lists 

![NetLearner Razor Pages: Learning Resources](/design/screenshots/NetLearner-Pages-Resources.PNG "NetLearner Razor Pages: Learning Resources")
NetLearner Razor Pages: Learning Resources

![NetLearner Blazor: Resource Lists](/design/screenshots/NetLearner-Blazor-Lists.PNG "NetLearner Blazor: Resource Lists")
NetLearner Blazor: Resource Lists   

![NetLearner Blazor: Learning Resources](/design/screenshots/NetLearner-Blazor-Resources.PNG "NetLearner Blazor: Learning Resources")
NetLearner Blazor: Learning Resources

# What's Next?

In 2020, you can expect a new A-Z weekly blog series to cover 26 different topics from January through June 2020. To get a sneak peek of what's to come, take a peek at the [2019 A-Z series](https://wakeupandcode.com/aspnetcore/#aspnetcore2019).







