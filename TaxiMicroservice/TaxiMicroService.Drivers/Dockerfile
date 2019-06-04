FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["TaxiMicroService.Drivers/TaxiMicroService.Drivers.csproj", "TaxiMicroService.Drivers/"]
RUN dotnet restore "TaxiMicroService.Drivers/TaxiMicroService.Drivers.csproj"
COPY . .
WORKDIR "/src/TaxiMicroService.Drivers"
RUN dotnet build "TaxiMicroService.Drivers.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "TaxiMicroService.Drivers.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TaxiMicroService.Drivers.dll"]