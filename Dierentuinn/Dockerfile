# Use the .NET runtime as a base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Use the .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy the project files and restore dependencies
COPY ["Dierentuinn/dierentuinn.csproj", "Dierentuinn/"]
COPY ["TestProject2/TestProject2.csproj", "TestProject2/"]
RUN dotnet restore "./Dierentuinn/./dierentuinn.csproj"
RUN dotnet restore "./TestProject2/./TestProject2.csproj"

# Debug step: List directory contents to verify files are copied
RUN ls -la /src/Dierentuinn
RUN ls -la /src/TestProject2

# Copy all files and build the application
COPY Dierentuinn/ Dierentuinn/
COPY TestProject2/ TestProject2/
WORKDIR /src/Dierentuinn
RUN dotnet build "dierentuinn.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Stage for running tests
FROM build AS testrunner
WORKDIR /src/TestProject2
RUN dotnet test --logger:trx

# Final stage: use the runtime image
FROM base AS final
WORKDIR /app
COPY --from=build /app/build .
ENTRYPOINT ["dotnet", "Dierentuinn.dll"]
