# LeatherGoods
.NET Core multilayers proyect

## Requirements
To be able to run this proyect, you must have installed:
- [Dotnet Core 2.0](https://www.microsoft.com/net/core)
- [NodeJS v8.5.0](https://nodejs.org/es/)
- [yarn](https://yarnpkg.com/lang/en/) or [npm](https://www.npmjs.com/)


## Installation

Clone this repo and run the next line to install required packages:
```
dotnet restore LeatherGoods.sln
```


## Running the app

You must activate the env running the next commands.
```
source Environment/activate.sh
```
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
