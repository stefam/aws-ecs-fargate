FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 8080

ENV ASPNETCORE_URLS=http://*:8080

# Restore packages
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["web.api/web.api.csproj", "web.api/"]
RUN dotnet restore "web.api/web.api.csproj"

# Build the app
COPY . .
WORKDIR "/src/web.api"
RUN dotnet build "web.api.csproj" -c Release -o /app/build

# Publish project
FROM build AS publish
RUN dotnet publish "web.api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Run the app
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "web.api.dll"]
