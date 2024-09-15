#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR "/src"
COPY ["./Atlas-Monitoring-Web.sln", "./"]
COPY ["./Atlas-Monitoring-Web/Atlas-Monitoring-Web.csproj", "./Atlas-Monitoring-Web/Atlas-Monitoring-Web.csproj"]
COPY ["./Atlas-Monitoring-Web.Core.Application/Atlas-Monitoring-Web.Core.Application.csproj", "./Atlas-Monitoring-Web.Core.Application/Atlas-Monitoring-Web.Core.Application.csproj"]
COPY ["./Atlas-Monitoring-Web.Core.Infrastructure/Atlas-Monitoring-Web.Core.Infrastructure.csproj", "./Atlas-Monitoring-Web.Core.Infrastructure/Atlas-Monitoring.Core-Web.Infrastructure.csproj"]
COPY ["./Atlas-Monitoring-Web.Core.Interface/Atlas-Monitoring-Web.Core.Interface.csproj", "./Atlas-Monitoring-Web.Core.Interface/Atlas-Monitoring-Web.Core.Interface.csproj"]
COPY ["./Atlas-Monitoring-Web.Core.Models/Atlas-Monitoring-Web.Core.Models.csproj", "./Atlas-Monitoring-Web.Core.Models/Atlas-Monitoring-Web.Core.Models.csproj"]
COPY ["./Atlas-Monitoring-Web.CustomException/Atlas-Monitoring-Web.CustomException.csproj", "./Atlas-Monitoring-Web.CustomException/Atlas-Monitoring-Web.CustomException.csproj"]
RUN dotnet restore "./Atlas-Monitoring-Web/Atlas-Monitoring-Web.csproj"
COPY . .
WORKDIR "/src/Atlas-Monitoring-Web"
RUN dotnet build "./Atlas-Monitoring-Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Atlas-Monitoring-Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Atlas-Monitoring-Web.dll"]