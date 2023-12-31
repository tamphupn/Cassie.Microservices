#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
#EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR .
COPY ["Services/ProductService/ProductService.csproj", "Services/ProductService/"]
COPY ["Infrastructure/Common.Logging/Common.Logging.csproj", "Infrastructure/Common.Logging/"]
COPY ["Infrastructure/Cassie.SharedInfrastructure/Cassie.SharedInfrastructure.csproj", "Infrastructure/Cassie.SharedInfrastructure/"]
COPY ["Infrastructure/Cassie.Contracts/Cassie.Contracts.csproj", "Infrastructure/Cassie.Contracts/"]
COPY ["Infrastructure/Cassie.SharedApplication/Cassie.SharedApplication.csproj", "Infrastructure/Cassie.SharedApplication/"]
RUN dotnet restore "Services/ProductService"
COPY . .
WORKDIR "/Services/ProductService"
RUN dotnet build "ProductService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProductService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProductService.dll"]
