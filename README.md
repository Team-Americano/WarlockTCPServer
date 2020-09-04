# Project Warlock

- [User Stories and Requirements](Requirements.md)

---
### We are deployed on Azure! TODO

[project url here]

---
## TCP Server and Unity Application TODO

---

## Tools Used
Microsoft Visual Studio Community 2017 (Version 15.5.7)

- C#
- ASP.Net Core
- Unity
- PlayFab
- Docker 

---

## Getting Started TODO

Clone this repository to your local machine.

```
$ git clone https://github.com/YourRepo/YourProject.git
```
Once downloaded, you can either use the dotnet CLI utilities or Visual Studio 2017 (or greater) to build the web application. The solution file is located in the AmandaFE subdirectory at the root of the repository.
```
cd YourRepo/YourProject
dotnet build
```
The dotnet tools will automatically restore any NuGet dependencies. Before running the application, the provided code-first migration will need to be applied to the SQL server of your choice configured in the /AmandaFE/AmandaFE/appsettings.json file. This requires the Microsoft.EntityFrameworkCore.Tools NuGet package and can be run from the NuGet Package Manager Console:
```
Update-Database
```
Once the database has been created, the application can be run. Options for running and debugging the application using IIS Express or Kestrel are provided within Visual Studio. From the command line, the following will start an instance of the Kestrel server to host the application:
```
cd YourRepo/YourProject
dotnet run
```
Unit testing is included in the AmandaFE/FrontendTesting project using the xUnit test framework. Tests have been provided for models, view models, controllers, and utility classes for the application.

---

## Usage TODO

### Game Lobby
![Game Lobby](https://via.placeholder.com/500x250)

### Start of Game
![Start of Game](https://via.placeholder.com/500x250)

### Mid Game
![Mid Game](https://via.placeholder.com/500x250)

### Game End
![Game End](https://via.placeholder.com/500x250)

---
## Data Flow TODO
![Data Flow Diagram](/Assets/img/Flowchart.png)

---

## UML Diagrams TODO

---

## Change Log
- 0.10 - Inital Repo Setup with README 

---

## Authors
- Bade Habib
- Peyton Cysewski
- Trevor Stubbs

---

For more information on Markdown: https://www.markdownguide.org/cheat-sheet
