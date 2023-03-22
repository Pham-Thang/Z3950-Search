FROM mcr.microsoft.com/dotnet/aspnet:6.0-windowsservercore-ltsc2022 AS base

WORKDIR /app
COPY /bin/Release/net6.0/publish/ ./

EXPOSE 80
ENTRYPOINT ["dotnet", "Z3950.Api.dll", "--runtime x86"]