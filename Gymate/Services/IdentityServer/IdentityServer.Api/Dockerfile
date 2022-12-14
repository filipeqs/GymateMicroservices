#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/IdentityServer/IdentityServer.Api/IdentityServer.Api.csproj", "Services/IdentityServer/IdentityServer.Api/"]
RUN dotnet restore "Services/IdentityServer/IdentityServer.Api/IdentityServer.Api.csproj"
COPY . .
WORKDIR "/src/Services/IdentityServer/IdentityServer.Api"
RUN dotnet build "IdentityServer.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IdentityServer.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IdentityServer.Api.dll"]