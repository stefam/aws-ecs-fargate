FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

# Restore packages
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["web.ui/web.ui.csproj", "web.ui/"]
RUN dotnet restore "web.ui/web.ui.csproj"

# Build the app
COPY . .
WORKDIR "/src/web.ui"
RUN dotnet build "web.ui.csproj" -c Release -o /app/build

# Publish project
FROM build AS publish
RUN dotnet publish "web.ui.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Run the app
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "web.ui.dll"]
