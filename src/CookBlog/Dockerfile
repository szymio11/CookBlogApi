FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/CookBlog/CookBlog.Api.csproj", "src/CookBlog/"]
COPY ["src/CookBlog.Infrastructure/CookBlog.Infrastructure.csproj", "src/CookBlog.Infrastructure/"]
COPY ["src/CookBlog.Application/CookBlog.Application.csproj", "src/CookBlog.Application/"]
COPY ["src/CookBlog.Data/CookBlog.Core.csproj", "src/CookBlog.Data/"]
RUN dotnet restore "src/CookBlog/CookBlog.Api.csproj"
COPY . .
WORKDIR "/src/src/CookBlog"
RUN dotnet build "CookBlog.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CookBlog.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CookBlog.Api.dll"]
