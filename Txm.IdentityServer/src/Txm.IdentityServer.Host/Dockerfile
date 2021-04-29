#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Txm.IdentityServer.Host/Txm.IdentityServer.Host.csproj", "src/Txm.IdentityServer.Host/"]
COPY ["src/Txm.IdentityServer.EntityFrameworkCore/Txm.IdentityServer.EntityFrameworkCore.csproj", "src/Txm.IdentityServer.EntityFrameworkCore/"]
COPY ["src/Txm.IdentityServer.Domain/Txm.IdentityServer.Domain.csproj", "src/Txm.IdentityServer.Domain/"]
COPY ["src/Txm.IdentityServer.Domain.Shared/Txm.IdentityServer.Domain.Shared.csproj", "src/Txm.IdentityServer.Domain.Shared/"]
RUN dotnet restore "src/Txm.IdentityServer.Host/Txm.IdentityServer.Host.csproj"
COPY . .
WORKDIR "/src/src/Txm.IdentityServer.Host"
RUN dotnet build "Txm.IdentityServer.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Txm.IdentityServer.Host.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Txm.IdentityServer.Host.dll"]