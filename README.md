# LeatherGoods
.NET Core multilayers proyect

## Requirements
To be able to run this proyect, you must have installed:
- [Dotnet Core 2.0](https://www.microsoft.com/net/core)
- [NodeJS v8.5.0](https://nodejs.org/es/)
- [yarn](https://yarnpkg.com/lang/en/) or [npm](https://www.npmjs.com/)


## Installation
Clone this repo and run the next command to install/restore the required packages:
```
dotnet restore LeatherGoods.sln
```

## Setup
Before running the app, you must set the necessary Environment Variables such db connection string, web or API url.
To set this vars, you can execute your platform script placed in ```Environment``` dir to create custom file, or just edit the given one.

### Linux
```
source Environment/linux.sh
```
This line will load the default vars into your environment and create a custom script called ```local_linux.sh```. In this new file you must set your specific custom vars.
After setting up the new vars, you need to reload this file.

### Windows
```
.\Environment/windows.ps1
```
This line will load the default vars into your environment and create a custom script called ```local_windows.ps1```. In this new file you must set your specific custom vars.
After setting up the new vars, you need to reload this file.
*Note: Run before running Visual Studio.*

## Available Vars

```ASPNETCORE_ENVIRONMENT```= Choose between **[Production, Development]**

```DB_PROVIDER```= Choose between **[MSSQLServer, Oracle, Postgres, MySQL]**

```DB_CONNECTION_STRING```= Your DB Connection String

```CACHE_STORE_PROVIDER```= Choose between **[Redis, Mongo]**

```CACHE_STORE_CONNECTION_STRING```= Your Cache Connection String

```API_URL```= Your API URL Here

```WEB_URL```= Your WEB URL Here



## Running the app

### Linux
After finishing the installation and setup, you can execute the npm task to run the Web and API using **yarn** or **npm**(We use yarn for this tutorial).

To run the Web:
```
yarn run web
```

To run the API:
```
yarn run api
```

Open your browser and browse the urls you have set up in the env scripts and enjoy your app running :).

### VisualStudio
If you want to run it in VS you must make the projects not to run IIS to make the project use the URLs assigned in the env scripts
In both the Web and API projects properties:
```
Debug -> Start -> Project
```

## Authors

- [Facundo Guini](https://github.com/fguini)
- [Marco Puccio](https://github.com/marcopuccio)
