FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["RestWithASP-NETUdemy/RestWithASP-NETUdemy.csproj", "RestWithASP-NETUdemy/"]
RUN dotnet restore "RestWithASP-NETUdemy/RestWithASP-NETUdemy.csproj"
COPY . .
WORKDIR "/src/RestWithASP-NETUdemy"
RUN dotnet build "./RestWithASP-NETUdemy.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./RestWithASP-NETUdemy.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RestWithASP-NETUdemy.dll"]
