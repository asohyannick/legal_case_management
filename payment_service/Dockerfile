FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /repo

COPY payment_service.slnx .
COPY global.json .
COPY Directory.Build.props .
COPY Directory.Packages.props .
COPY nuget.config .

COPY src/payment_service.Core/payment_service.Core.csproj                   src/payment_service.Core/
COPY src/payment_service.UseCases/payment_service.UseCases.csproj           src/payment_service.UseCases/
COPY src/payment_service.Infrastructure/payment_service.Infrastructure.csproj src/payment_service.Infrastructure/
COPY src/payment_service.Web/payment_service.Web.csproj                     src/payment_service.Web/
COPY src/payment_service.ServiceDefaults/payment_service.ServiceDefaults.csproj src/payment_service.ServiceDefaults/
COPY src/payment_service.AspireHost/payment_service.AspireHost.csproj       src/payment_service.AspireHost/
COPY tests/payment_service.UnitTests/payment_service.UnitTests.csproj               tests/payment_service.UnitTests/
COPY tests/payment_service.IntegrationTests/payment_service.IntegrationTests.csproj tests/payment_service.IntegrationTests/
COPY tests/payment_service.FunctionalTests/payment_service.FunctionalTests.csproj   tests/payment_service.FunctionalTests/

RUN dotnet restore src/payment_service.Web/payment_service.Web.csproj

COPY src/ src/

RUN dotnet publish src/payment_service.Web/payment_service.Web.csproj \
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

ENTRYPOINT ["dotnet", "payment_service.Web.dll"]