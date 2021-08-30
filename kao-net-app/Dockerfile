#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["kao-net-app.csproj", ""]
RUN dotnet restore "./kao-net-app.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "kao-net-app.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "kao-net-app.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "kao-net-app.dll"]