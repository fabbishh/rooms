#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["webapi/webapi.csproj", "webapi/"]
COPY ["Application/Application.csproj", "Application/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]
COPY ["DataAccess/DataAccess.csproj", "DataAccess/"]
COPY ["Logging/Logging.csproj", "Logging/"]
RUN dotnet restore "webapi/webapi.csproj"
COPY . .
WORKDIR "/src/webapi"
RUN dotnet build "webapi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "webapi.csproj" -c Release -o /app/publish /p:UseAppHost=false
RUN dotnet ef database update

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "webapi.dll"]