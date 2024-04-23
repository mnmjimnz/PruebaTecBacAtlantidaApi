#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["bco.atlantidad.estadocuenta.api/bco.atlantidad.estadocuenta.api.csproj", "bco.atlantidad.estadocuenta.api/"]
RUN dotnet restore "./bco.atlantidad.estadocuenta.api/bco.atlantidad.estadocuenta.api.csproj"
COPY . .
WORKDIR "/src/bco.atlantidad.estadocuenta.api"
RUN dotnet build "./bco.atlantidad.estadocuenta.api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./bco.atlantidad.estadocuenta.api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "bco.atlantidad.estadocuenta.api.dll"]