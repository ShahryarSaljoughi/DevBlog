#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["DevBlog.Core.Db/DevBlog.Core.Db.csproj", "DevBlog.Core.Db/"]
COPY ["DevBlog.Core.Model/DevBlog.Core.Model.csproj", "DevBlog.Core.Model/"]
COPY ["DevBlog.Shared.Utils/DevBlog.Shared.Utils.csproj", "DevBlog.Shared.Utils/"]
RUN dotnet restore "DevBlog.Core.Db/DevBlog.Core.Db.csproj"
COPY . .
WORKDIR "/src/DevBlog.Core.Db"
RUN dotnet build "DevBlog.Core.Db.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DevBlog.Core.Db.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DevBlog.Core.Db.dll"]