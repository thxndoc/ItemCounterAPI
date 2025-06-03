# Use the official .NET 8 SDK image to build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore as distinct layers
COPY ItemCounterAPI/ItemCounterAPI.csproj ItemCounterAPI/
RUN dotnet restore "ItemCounterAPI/ItemCounterAPI.csproj"

# Copy everything else and build
COPY ItemCounterAPI/. ./ItemCounterAPI/
WORKDIR /src/ItemCounterAPI
RUN dotnet build "ItemCounterAPI.csproj" -c Release -o /app/build

# Publish
FROM build AS publish
RUN dotnet publish "ItemCounterAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ItemCounterAPI.dll"]
