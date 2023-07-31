# Cassie.Microservices

1. Database
1.1 Add & update new script database for service
- dotnet ef migrations add init_productdb -p src/Services/ProductService
- dotnet ef database update -p src/Services/ProductService

2. Run build service
- Product Service: dotnet run --project src/Services/ProductService/ProductService.csproj

3. Using docker-compose:
- cd src && docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d --remove-orphans
- cd src && docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d --remove-orphans --build

4. Knowledge link
- Auto Mapper
    https://github.com/AutoMapper/AutoMapper
- IResult & IActionResult
    https://stackoverflow.com/questions/74256233/iactionresult-vs-iresult-asp-net-core
- MySQL
    https://geshan.com.np/blog/2022/02/mysql-docker-compose/

5. Urls
- Product Service
    - http://localhost:6002/swagger/index.html