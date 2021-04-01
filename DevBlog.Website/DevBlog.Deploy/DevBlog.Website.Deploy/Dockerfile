# https://hub.docker.com/_/microsoft-dotnet-core
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /source
RUN dotnet --info
# copy csproj and restore as distinct layers
COPY *.sln .
COPY DevBlog.Core.Model/*.csproj ./DevBlog.Core.Model/
COPY DevBlog.Core.Service/*.csproj ./DevBlog.Core.Service/
COPY DevBlog.Core.Db/*.csproj ./DevBlog.Core.Db/
COPY DevBlog.Website/*.csproj ./DevBlog.Website/
COPY DevBlog.Management/*.csproj ./DevBlog.Management/
COPY DevBlog.Shared.Utils/*.csproj ./DevBlog.Shared.Utils/
RUN dotnet restore

# copy everything else and build app
COPY . .
WORKDIR /source/DevBlog.Website
RUN dotnet publish -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "DevBlog.Website.dll"]
