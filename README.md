# All-Jokes Project

This project was presented at SETCON'19 (April 2019) and represents a Service Fabric application.

## Content

The following source code contains:
* JokesApi/ - ASP.NET Core Web API service implemented as Service Fabric stateful service. The reliable state is used to store service data.
* JokesStats/ - .NET Core based statistics service implemented as Service Fabric actor. The actor state is used to store statistics.
* JokesWeb/ - ASP.NET Core MVC application implemented as Service Fabric stateless service.
* JokesApp/ - Service Fabric application project (combines JokesWeb & JokesApi)
* JokesApiContracts/ - shared models used for communication between JokesApi & JokesWeb
* JokesStats.Interfaces/ - JokesStats actor interface and models

## Building demo project

This project is created using Visual Studio 2017 (15.9) and requires Azure Service Fabric SDK (3.3.644) to run.

### Preparing the development machine

* Install .NET Core SDK (Windows). https://www.microsoft.com/net/download/windows
* Install Azure Service Fabric SDK (Windows). https://azure.microsoft.com/en-us/downloads

### Build & Deploy

* Clone the master branch. `git clone https://github.com/coherentsolutionsinc/setcon-2019-introduction-to-service-fabric <path to the local folder>`
* Create local Service Fabric cluster. Use `Five Nodes` configuration
* Execute `build-and-run.ps1`. This will build and deploy JokesApp to local Service Fabric cluster _(run PowerShell with **administrative** privileges)_

> **Developer's comment:**
>
> The base path to `JokesWebService` in Service Fabric Explorer is http://localhost:19080/Explorer/index.html#/AppType/JokesAppType/app/JokesApp/service/JokesApp%252FJokesWebService

### Application Usage

There are several `.json` files in `mock-data/` directory that contains demo jokes. Feel free to use application `Import` functionality.

> **Developer's comment:**
>
> Please note. This demo application doesn't implement error handling. So be careful.

You can add additional languages to existing application:
1. Using **Service Fabric Explorer** create a new service of type `JokesApiServiceType` with the name matching the following pattern `JokesApiService/{Language}`

  > **Developer's comment:**
  > 
  > When creating service use `Naming` partitining schema

2. Create a `.json` with jokes.
3. Import the `.json` file.

## See Also

* Service Fabric Explorer documentation. https://docs.microsoft.com/en-us/azure/service-fabric/service-fabric-visualizing-your-cluster

## Authors

This project is owned by [Coherent Solutions][1].

## License

This project is licensed under the MIT License - see the [LICENSE.md][2] for details.

[1]: https://www.coherentsolutions.com/ "Coherent Solutions Inc."
[2]: LICENCE.md "License"
