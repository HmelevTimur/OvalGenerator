FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["OVALGenerator.Api/OVALGenerator.Api.csproj", "OVALGenerator.Api/"]
RUN dotnet restore "OVALGenerator.Api/OVALGenerator.Api.csproj"
COPY . .
WORKDIR "/src/OVALGenerator.Api"
RUN dotnet build "OVALGenerator.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "OVALGenerator.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OVALGenerator.Api.dll"]

CMD ["sh", "-c", "dotnet ef database update && dotnet OVALGenerator.Api.dll"]