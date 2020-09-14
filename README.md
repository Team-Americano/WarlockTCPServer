# Project Warlock

- [User Stories and Requirements](Requirements.md)

---
### We are deployed on Azure!

![Azure Deployment on VM](https://github.com/Team-Americano/WarlockTCPServer/blob/master/WarlockTCPServerScreen.png?raw=true)

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
$ git clone https://github.com/Team-Americano/WarlockTCPServer.git
```
Once downloaded, you can either use the dotnet CLI utilities or Visual Studio 2017 (or greater) to build the web application. The solution file is located in the WarlockTCPServer subdirectory at the root of the repository.
```
cd Team-Americano/WarlockTCPServer
dotnet build
```
The dotnet tools will automatically restore any NuGet dependencies. From the command line, the following will start an instance of the server:
```
cd Team-Americano/WarlockTCPServer/bin/x64/Release/netcoreapp3.1
./WarlockTCPServer.exe
```
You should start the server on a computer that is publicly accessible to one or more Warlock clients, which can be found here: [Click for Warlock client repo](https://github.com/Team-Americano/WarlockTCPClient). To configure the Warlock client, you will need to clone the repository.
```
$ git clone https://github.com/Team-Americano/WarlockTCPClient.git
```
After cloning the repo, you need to open the project in Unity using version 2019.4.9f1 or later. First, you require two clients on different machines that are configured to the public-facing IP of the machine running your server. This can be changed in the ```_hostname``` field of the WarlockTCPClient's NetworkManager.cs file. You can then run the client from the Unity editor by pressing the play button at the top or build the client by navigating to File -> Build and Run for a standalone build.

Lastly, unit testing is included in the WarlockTCPServer/WarlockTCPServerUnitTests project using the xUnit test framework. Tests have been provided for the model of the application.

---

## Usage TODO

### Main Menu
![Main Menu](https://github.com/Team-Americano/WarlockTCPServer/blob/master/MainMenu.png?raw=true)

### Draft Phase
![Draft Phase](https://github.com/Team-Americano/WarlockTCPServer/blob/master/DraftPhase.png?raw=true)

### Combat Phase
![Combat](https://github.com/Team-Americano/WarlockTCPServer/blob/master/CombatPhase.png?raw=true)

---
## Data Flow
![Data Flow Diagram](https://github.com/Team-Americano/WarlockTCPServer/blob/master/Data%20Flow.png?raw=true)

---

## UML Diagrams
![Server UML](https://github.com/Team-Americano/WarlockTCPServer/blob/master/Warlock_Server_UML.png?raw=true)

![Client UML](https://github.com/Team-Americano/WarlockTCPServer/blob/master/Warlock_ClientUML.png?raw=true)

---

## Change Log
- 0.10 - Inital Repo Setup with README 

---

## Authors
- Bade Habib
- Peyton Cysewski
- Trevor Stubbs
