# https://hub.docker.com/_/microsoft-dotnet-core
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /source
RUN dotnet --info
# copy csproj and restore as distinct layers
# COPY ./../*.sln .
COPY *.csproj ./DevBlog.Website/
WORKDIR /source/DevBlog.Website
RUN dotnet restore
WORKDIR /source

# copy everything else and build app
COPY . ./DevBlog.Website/
WORKDIR /source/DevBlog.Website
RUN dotnet publish -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "DevBlog.Website.dll"]
