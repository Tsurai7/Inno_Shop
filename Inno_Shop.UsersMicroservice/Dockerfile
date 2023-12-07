#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Inno_Shop.UsersMicroservice/Inno_Shop.Services.Users.csproj", "Inno_Shop.UsersMicroservice/"]
RUN dotnet restore "Inno_Shop.UsersMicroservice/Inno_Shop.Services.Users.csproj"
COPY . .
WORKDIR "/src/Inno_Shop.UsersMicroservice"
RUN dotnet build "Inno_Shop.Services.Users.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Inno_Shop.Services.Users.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Inno_Shop.Services.Users.dll"]