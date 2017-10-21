# LeatherGoods
.NET Core multilayers proyect

## Installation
To be able to run this proyect, you must have installed [Dotnet Core 2.0](https://www.microsoft.com/net/core).

Clone this repo and run to install required packages:
```
dotnet restore LeatherGoods/LeatherGoods.sln
```


## Running the app
You must activate the env running the next commands.
```
dotnet restore LeatherGoods/Environment.sh
```
This command will create a new file called ```local.sh```. You must set the keys of your project here and these will be safe because this file is ignored to commit. You can copy the env names from ```activate.sh``` file.

After set the vars, you can run the project normally with the ```dotnet cli```.

To run the Web:
```
dotnet run --project LeatherGoods/Web/UI/UI.csproj
```

To run the API:
```
dotnet run --project LeatherGoods/API/API.csproj
```
