FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

# Copy csproj and restore
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -o out


# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY . ./
EXPOSE 80
EXPOSE 443 
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "BeerService.dll"]