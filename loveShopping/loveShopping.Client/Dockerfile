#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["loveShopping.Client/loveShopping.Client.csproj", "loveShopping.Client/"]
COPY ["loveShopping.API/loveShopping.API.csproj", "loveShopping.API/"]
RUN dotnet restore "loveShopping.Client/loveShopping.Client.csproj"
COPY . .
WORKDIR "/src/loveShopping.Client"
RUN dotnet build "loveShopping.Client.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "loveShopping.Client.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "loveShopping.Client.dll"]