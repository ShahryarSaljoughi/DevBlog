# #See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

# FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
# WORKDIR /app

# FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
# WORKDIR /src
# COPY ["DevBlog.Core.Db/DevBlog.Core.Db.csproj", "DevBlog.Core.Db/"]
# COPY ["DevBlog.Core.Model/DevBlog.Core.Model.csproj", "DevBlog.Core.Model/"]
# COPY ["DevBlog.Shared.Utils/DevBlog.Shared.Utils.csproj", "DevBlog.Shared.Utils/"]
# RUN dotnet restore "DevBlog.Core.Db/DevBlog.Core.Db.csproj"
# COPY . .
# WORKDIR "/src/DevBlog.Core.Db"
# RUN dotnet build "DevBlog.Core.Db.csproj" -c Release -o /app/build

# FROM build AS publish
# RUN dotnet publish "DevBlog.Core.Db.csproj" -c Release -o /app/publish

# FROM base AS final
# WORKDIR /app
# COPY --from=publish /app/publish .
# ENTRYPOINT ["dotnet", "DevBlog.Core.Db.dll"]


# # https://hub.docker.com/_/microsoft-dotnet-core
# FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
# WORKDIR /source
# RUN dotnet --info
# # copy csproj and restore as distinct layers
# COPY *.sln .
# COPY DevBlog.Core.Model/*.csproj ./DevBlog.Core.Model/
# COPY DevBlog.Core.Service/*.csproj ./DevBlog.Core.Service/
# COPY DevBlog.Core.Db/*.csproj ./DevBlog.Core.Db/
# COPY DevBlog.Website/*.csproj ./DevBlog.Website/
# COPY DevBlog.Management/*.csproj ./DevBlog.Management/
# COPY DevBlog.Shared.Utils/*.csproj ./DevBlog.Shared.Utils/
# RUN dotnet restore

# # copy everything else and build app
# COPY . .
# WORKDIR /source/DevBlog.Website
# RUN dotnet publish -c release -o /app --no-restore

# # final stage/image
# FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
# WORKDIR /app
# COPY --from=build /app ./
# ENTRYPOINT ["dotnet", "DevBlog.Website.dll"]



#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["DevBlog.Management/DevBlog.Management.csproj", "DevBlog.Management/"]
COPY ["DevBlog.Core.Service/DevBlog.Core.Service.csproj", "DevBlog.Core.Service/"]
COPY ["DevBlog.Core.Model/DevBlog.Core.Model.csproj", "DevBlog.Core.Model/"]
COPY ["DevBlog.Core.Db/DevBlog.Core.Db.csproj", "DevBlog.Core.Db/"]
COPY ["DevBlog.Shared.Utils/DevBlog.Shared.Utils.csproj", "DevBlog.Shared.Utils/"]
RUN dotnet restore "DevBlog.Management/DevBlog.Management.csproj"
COPY . .
WORKDIR "/src/DevBlog.Management"
RUN dotnet build "DevBlog.Management.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DevBlog.Management.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DevBlog.Management.dll"]