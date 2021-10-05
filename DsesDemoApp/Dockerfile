#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["DsesDemoApp.csproj", ""]
RUN dotnet restore "./DsesDemoApp.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "DsesDemoApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DsesDemoApp.csproj" -c Release -o /app/publish
RUN mkdir -p /app/publish/sqliteDb
COPY sqliteDb /app/publish/sqliteDb

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DsesDemoApp.dll"]