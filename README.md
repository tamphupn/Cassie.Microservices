# Cassie.Microservices

1. Run build service
- cd src
- Product Service: dotnet run --project Services/ProductService/ProductService.csproj

2. Using docker-compose:
- cd src
- docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d --remove-orphans