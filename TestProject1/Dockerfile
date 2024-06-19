# Use .NET SDK image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . .
RUN dotnet build "dierentuinn.csproj" -c Release -o /app/build

# Run the migrations
RUN dotnet ef database update

# Publish the app
FROM build AS publish
RUN dotnet publish "dierentuinn.csproj" -c Release -o /app/publish

# Final stage: use runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "dierentuinn.dll"]