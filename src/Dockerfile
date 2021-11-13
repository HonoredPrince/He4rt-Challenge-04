#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/HeartChallenge4.sln", "src/"]
COPY ["src/Api.Application/Application.csproj", "src/Api.Application/"]
COPY ["src/Api.CrossCutting/CrossCutting.csproj", "src/Api.CrossCutting/"]
COPY ["src/Api.Data/Data.csproj", "src/Api.Data/"]
COPY ["src/Api.Domain/Domain.csproj", "src/Api.Domain/"]
COPY ["src/Api.PokeApiNet/PokeApiNet.csproj", "src/Api.PokeApiNet/"]
COPY ["src/Api.Service/Service.csproj", "src/Api.Service/"]
RUN dotnet restore "src/Api.Application/Application.csproj"
RUN dotnet restore "src/Api.CrossCutting/CrossCutting.csproj"
RUN dotnet restore "src/Api.Data/Data.csproj"
RUN dotnet restore "src/Api.Domain/Domain.csproj"
RUN dotnet restore "src/Api.PokeApiNet/PokeApiNet.csproj"
RUN dotnet restore "src/Api.Service/Service.csproj"
COPY . .
WORKDIR "src/Api.Application"
RUN dotnet build "Application.csproj" -c Release -o /app/build

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS migration
WORKDIR /src
COPY . .
RUN dotnet restore "src/Api.Migration/Migration.csproj"
COPY . .
WORKDIR "src/Api.Migration"
RUN dotnet build "Migration.csproj" -c Release -o /app/migration

FROM build AS publish
RUN dotnet publish "Application.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /migration
COPY --from=migration /app/migration .

WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Application.dll"]
