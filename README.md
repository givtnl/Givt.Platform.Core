# Givt.Platform.Core

## Getting started for cloud people
1. Create new file `src/Core/Givt.Core.API/appsettings.Development.json` with content
~~~
    {
        "Logging": {
        "LogLevel": {
            "Default": "Debug",
            "Microsoft.AspNetCore": "Warning"
        }
        },
        "ConnectionStrings": {
			"GivtCoreDb": "Server=localhost;Port=26257;Database=givt_platform_debug;Password=_SECRET_PASSWORD_"
        }
    }
~~~~
2. Set environment variable for the environment
    1. On linux: `export ASPNETCORE_ENVIRONMENT=Development`
    2. On Windows: `set ASPNETCORE_ENVIRONMENT=Development`
3. Build everything: `dotnet build`
4. Go to binary location: `cd src/Core/Givt.Core.API/bin/Debug/net6.0/`
5. Run binary: `dotnet Givt.Core.API.dll`


## Upgrade/Downgrade the database
Requires environment variable set and appsettings with db connection configured (both described above)

* Initial seed of the database and updating to latest version: `dotnet ef database update -p ../Givt.Core.Persistance/Givt.Core.Persistance.csproj -s Givt.Core.API.csproj`
* Migrate to a specific version: `dotnet ef database update InitialCreate -p ../Givt.Core.Persistance/Givt.Core.Persistance.csproj -s Givt.Core.API.csproj`

On the database you can see the latest applied version: `SELECT * FROM __EFMigrationsHistory;`