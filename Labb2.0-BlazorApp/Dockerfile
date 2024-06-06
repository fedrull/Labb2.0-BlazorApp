#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 8080
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Labb2.0-BlazorApp/Labb2.0-BlazorApp.csproj", "Labb2.0-BlazorApp/"]
RUN dotnet restore "./Labb2.0-BlazorApp/./Labb2.0-BlazorApp.csproj"
COPY . .
WORKDIR "/src/Labb2.0-BlazorApp"
RUN dotnet build "./Labb2.0-BlazorApp.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Labb2.0-BlazorApp.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Labb2.0-BlazorApp.dll"]