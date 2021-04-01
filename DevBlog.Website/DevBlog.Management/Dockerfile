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