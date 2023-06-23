# Dockerfile

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY AspNetCoreTodo/*.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY AspNetCoreTodo/. ./



RUN dotnet publish -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
ENV ASPNETCORE_URLS http://+:80
WORKDIR /app
COPY --from=build-env /app/out .

# Run the app on container startup
# Use your project name for the second parameter
# e.g. MyProject.dll
ENTRYPOINT [ "dotnet", "AspNetCoreTodo.dll" ]
