FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY StoreValidator/StoreValidator.csproj StoreValidator/
RUN dotnet restore StoreValidator/StoreValidator.csproj
COPY . .
WORKDIR /src/StoreValidator
RUN dotnet build StoreValidator.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish StoreValidator.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "StoreValidator.dll"]
