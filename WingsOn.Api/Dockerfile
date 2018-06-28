FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY WingsOn.Api/WingsOn.Api.csproj WingsOn.Api/
RUN dotnet restore WingsOn.Api/WingsOn.Api.csproj
COPY . .
WORKDIR /src/WingsOn.Api
RUN dotnet build WingsOn.Api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish WingsOn.Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WingsOn.Api.dll"]
