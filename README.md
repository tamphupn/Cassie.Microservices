# Cassie.Microservices

1. Database
1.1 Add & update new script database for service
- cd src 
- dotnet ef migrations add init_productdb -p ./Services/ProductService
- dotnet ef database update -p ./Services/ProductService

2. Run build service
- cd src
- Product Service: dotnet run --project Services/ProductService/ProductService.csproj

3. Using docker-compose:
- cd src
- docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d --remove-orphans