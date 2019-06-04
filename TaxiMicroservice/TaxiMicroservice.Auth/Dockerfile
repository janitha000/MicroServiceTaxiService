FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["TaxiMicroservice.Auth/TaxiMicroservice.Auth.csproj", "TaxiMicroservice.Auth/"]
RUN dotnet restore "TaxiMicroservice.Auth/TaxiMicroservice.Auth.csproj"
COPY . .
WORKDIR "/src/TaxiMicroservice.Auth"
RUN dotnet build "TaxiMicroservice.Auth.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "TaxiMicroservice.Auth.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TaxiMicroservice.Auth.dll"]