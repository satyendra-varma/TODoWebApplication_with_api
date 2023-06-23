# Dockerfile

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /api

# Copy csproj and restore as distinct layers
COPY ToDoListApi/*.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY ./ToDoListApi/ ./

WORKDIR /api
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
ENV ASPNETCORE_URLS http://+:5217
WORKDIR /api
COPY --from=build-env /api .
COPY --from=build-env /api/out ./out

RUN apt-get update \
    && apt-get install -y wget \
    && wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb \
    && dpkg -i packages-microsoft-prod.deb \
    && apt-get update \
    && apt-get install -y apt-transport-https \
    && apt-get update \
    && apt-get install -y dotnet-sdk-6.0

ENV PATH="${PATH}:/root/.dotnet/tools"
RUN dotnet tool install -g dotnet-ef --version 6.0.1
CMD [ "sh", "-c", "dotnet ef database update --context DataContext" ]
# Run the app on container startup
# Use your project name for the second parameter
# e.g. MyProject.dll
WORKDIR /api/out
ENTRYPOINT [ "dotnet", "TodoListApi.dll" ]

