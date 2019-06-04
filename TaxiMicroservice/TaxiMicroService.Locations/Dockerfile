FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["TaxiMicroService.Locations/TaxiMicroService.Locations.csproj", "TaxiMicroService.Locations/"]
RUN dotnet restore "TaxiMicroService.Locations/TaxiMicroService.Locations.csproj"
COPY . .
WORKDIR "/src/TaxiMicroService.Locations"
RUN dotnet build "TaxiMicroService.Locations.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "TaxiMicroService.Locations.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TaxiMicroService.Locations.dll"]