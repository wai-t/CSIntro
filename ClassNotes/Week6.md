## 05 Mar 2025
# Anatomy of a React ASP.NET project
We used the Visual Studio new project template called React and ASP.NET to create a starter project.

## Architecture of the starter project
[ReactApp architecture](ReactApp_Architecture.png) shows the processes that run on the developer's machine when the programs are launched.

### Client
The client consists of a web server running a node.js program from the top level folder of the ReactApp1.Client project. Vite is used as a development framework, and the benefit of this is to improve startup efficiency of the web server, and to enable hot reloading of the application when the code changes - both are important in the development environment when the code changes are frequent.

The client can be run from Visual Studio using the Play button after configuring the Startup Projects. It can also be run from command line from the project folder using:
`npm run dev`. See the package.json file "scripts" section to see other options for `npm run...`

### Server
The server consists of an app server built using the ASP.NEt framework from C# source code in the ReactApp1.Server project.

- Server startup is controlled by the launchsettings.json file which contains alternative profiles to use. The profile determines settings such as the port that the app server will listen on for incoming requests, and whether the swagger open api UI will be added to the app server's end points. The profile also sets environment variables to control the running of the program, in particular whether the ASPNETCORE_ENVIRONMENT should be set to "Development" or something else such as "Production" or "Test".
- Runtime settings are controlled by the appsettings.json file. This controls settings such as Logging (how much detail to log and where the log output should be sent), and links to external resources such as databases and general urls. Depending on the ASPNETCORE_ENVIRONMENT value, an appsettings.Development.json file will be used to override any settings made by the appsettings.json file.

The server can be run from Visual Studio using the Play button after configuring the Startup Projects. It can also be run from command line from the project folder using:

`dotnet run --launch-profile [profile]`

### Runtime Environments
An Environment refers the machines and resources, such as databases and other apis, used when running the programs. The Development environment is the one that you'll be most involved with in your dream job. Here, the resources you connect to will be safe ones where you can change data, setup tests, and be protected from seeing sensitive data. The program can be configured to produce helpful logging output. The Production environment will be typically be locked down from developer access and is a business operation. It might contain sensitive data and will be streamlined so that performance drains such as logging will be minimised. In between will be Integration, Test or QA environments which are intended to prove the system is working before it is deployed to Production. The purpose of the ASPNETCORE_ENVIRONMENT variable is to allow you to write code which can conditionally execute depending on the environment, so that the actual code itself is the same for all environments. You should not be creating different versions of code or git branches for different environments. 

The vite.config.js and the launchsettings.json are mainly intended to support the development environment. In Production, these probably won't be used, and the programs might run on different types of platform. The important thing is the that code is written to obtain the correct settings for things like database connection strings, and external urls, transparently and without hard coding.

## Software Components of an ASP.NET app.
ASP.NET is a framework which supports **Dependency Injection**. It means that the software components you write to determine what your appserver runs (Program.cs), what endpoints you want to implement (Controllers), and what access you need to external systems can all be written independently of each other. This reduces coupling between your components so that when you change one thing, you don't have to change other things. For example, in Program.cs, you only need to tell the ASP.NET framework that you want controllers in your appserver by calling `builder.Services.AddControllers()`. You don't need to say what those controllers are, so whenever you add a new endpoint you don't need to change the Program.cs. And in the controller class you only need to add the attribute `[ApiController]` or `[Controller]` to inform ASP.NET that this class contains end points that you would like to be called when the relevent request comes in. You don't need to write any code to add your class to the framework. That means that if the framework changes with the next version of ASP.NET your code does not need to change. Similarly, by adding `[HttpGet],` `[HttpPost]`, etc to the methods of your endpoints you don't need to write any code to add them to the framework. 

## Writing for Platform Independence
I made a beginner's mistake during the demo when I tried to create the VS project, which caused it to fail. The path of the folder I was using looked like "L:\Dev\...\C#Intro\ReactApp1". It turned out that the "#" character caused problems with vite. In hindsight it's not surprising because "#" is handled slightly differently between linux and Windows, and depending on the program it might be dealing with those differences incorrectly. So, as a general rule we should try to stick to the subset of things that work on all platforms and most programs. For file paths that generally means only using these characters [A-Z,a-z,0-9,-,_].