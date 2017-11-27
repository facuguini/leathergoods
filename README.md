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
Before running the app, you must to set the necessary Environment Variables such db connection string, web or API url.
To set this vars, you can execute your platform script placed in ```Environment``` dir to create custom file, or just edit the given one.

### Linux
```
source Environment/linux.sh
```
This line, will load the default vars into your environment and create a custom script called ```local_linux.sh```. In this new file you must set your specific custom vars.
After set the new vars, you need to reload this file.

### Windows
```
.\Environment/windows.ps1
```
This line, will load the default vars into your environment and create a custom script called ```local_windows.ps1```. In this new file you must set your specific custom vars.
After set the new vars, you need to reload this file.



## Running the app

You must activate the env running the next commands.
This command will create a new file called ```local.sh```. You must set the keys of your project here and these will be safe because this file is ignored to commit. You can copy the env names from ```activate.sh``` file.

After set the vars, you can run the project alias set with this scripts.

To run the Web:
```
lg_run_web
```

To run the API:
```
lg_run_api
```
