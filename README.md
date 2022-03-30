# Info
Created by Jules Torfs
r0878800

## Install .NET 6.0 SDK
https://dotnet.microsoft.com/en-us/download/dotnet/6.0

## Install Packages
dotnet add package Microsoft.AspNet.WebApi.Client --version 5.2.7

## Build
### Windows
dotnet publish --runtime win-x64 --configuration Release -p:PublishSingleFile=true -p:PublishTrimmed=true --self-contained true
### Linux
dotnet publish --runtime linux-x64 --configuration Release -p:PublishSingleFile=true -p:PublishTrimmed=true --self-contained true
### OSX
dotnet publish --runtime osx-x64 --configuration Release -p:PublishSingleFile=true -p:PublishTrimmed=true --self-contained true


## Extra
- use 'dotnet run' to execute the app