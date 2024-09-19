FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
#EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/TimeCard.API/TimeCard.API.csproj", "src/TimeCard.API/"]
COPY ["src/TimeCard.DataAccess/TimeCard.Persistence.csproj", "src/TimeCard.DataAccess/"]
COPY ["src/TimeCard.Domain/TimeCard.Domain.csproj", "src/TimeCard.Domain/"]
RUN dotnet restore "./src/TimeCard.API/TimeCard.API.csproj"
COPY . .
WORKDIR "/src/src/TimeCard.API"
RUN dotnet build "./TimeCard.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./TimeCard.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TimeCard.API.dll"]