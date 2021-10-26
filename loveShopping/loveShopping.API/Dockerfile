#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["loveShopping.API/loveShopping.API.csproj", "loveShopping.API/"]
RUN dotnet restore "loveShopping.API/loveShopping.API.csproj"
COPY . .
WORKDIR "/src/loveShopping.API"
RUN dotnet build "loveShopping.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "loveShopping.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "loveShopping.API.dll"]
