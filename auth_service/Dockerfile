
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /repo

COPY auth_service.slnx .
COPY global.json .
COPY Directory.Build.props .
COPY Directory.Packages.props .
COPY nuget.config .

COPY src/auth_service.Core/auth_service.Core.csproj             src/auth_service.Core/
COPY src/auth_service.UseCases/auth_service.UseCases.csproj     src/auth_service.UseCases/
COPY src/auth_service.Infrastructure/auth_service.Infrastructure.csproj src/auth_service.Infrastructure/
COPY src/auth_service.Web/auth_service.Web.csproj               src/auth_service.Web/
COPY src/auth_service.ServiceDefaults/auth_service.ServiceDefaults.csproj src/auth_service.ServiceDefaults/
COPY src/auth_service.AspireHost/auth_service.AspireHost.csproj src/auth_service.AspireHost/
COPY tests/auth_service.UnitTests/auth_service.UnitTests.csproj         tests/auth_service.UnitTests/
COPY tests/auth_service.IntegrationTests/auth_service.IntegrationTests.csproj tests/auth_service.IntegrationTests/
COPY tests/auth_service.FunctionalTests/auth_service.FunctionalTests.csproj   tests/auth_service.FunctionalTests/

RUN dotnet restore src/auth_service.Web/auth_service.Web.csproj

COPY src/ src/

RUN dotnet publish src/auth_service.Web/auth_service.Web.csproj \
    --configuration Release \
    --no-restore \
    --output /app/publish \
    -p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app

RUN addgroup --system --gid 1001 appgroup && \
    adduser  --system --uid 1001 --ingroup appgroup --no-create-home appuser

COPY --from=build /app/publish .

USER appuser

ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production
ENV DOTNET_RUNNING_IN_CONTAINER=true

EXPOSE 8080

ENTRYPOINT ["dotnet", "auth_service.Web.dll"]