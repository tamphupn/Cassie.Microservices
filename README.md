# Cassie.Microservices

1. Database
   1.1 Add & update new script database for service

-   dotnet ef migrations add init_productdb -p src/Services/ProductService
-   dotnet ef database update -p src/Services/ProductService

-   dotnet ef migrations add init_productdb -p src/Services/CustomerService
-   dotnet ef database update -p src/Services/CustomerService

2. Run build service

-   Product Service: dotnet run --project src/Services/ProductService
-   Customer Service: dotnet run --project src/Services/CustomerService
-   Basket Service: dotnet run --project src/Services/BasketService/

3. Using docker-compose:

-   cd src && docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d --remove-orphans
-   cd src && docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d --remove-orphans --build

-   rebuild one service
    -   docker compose up -d --no-deps --build customer.service
    -   docker compose up -d --no-deps --build product.service

4. Knowledge link

-   Auto Mapper
    https://github.com/AutoMapper/AutoMapper
-   IResult & IActionResult
    https://stackoverflow.com/questions/74256233/iactionresult-vs-iresult-asp-net-core
-   MySQL
    https://geshan.com.np/blog/2022/02/mysql-docker-compose/
-   Minimal API
    https://code-maze.com/dotnet-minimal-api/
    https://binaryintellect.net/articles/f3dcbb45-fa8b-4e12-b284-f0cd2e5b2dcf.aspx

5. Urls

-   Product Service
    -   Development: http://localhost:5002/swagger/index.html
    -   Dockerize: http://localhost:6002/swagger/index.html
-   Customer Service
    -   Development: http://localhost:5003/swagger/index.html
    -   Dockerize: http://localhost:6002/swagger/index.html
-   Basket Service
    -   Build: dotnet build Services/BasketService/BasketService.csproj
    -   Development: dotnet run --project src/Services/BasketService/
    -   Dockerize: http://localhost:6002/swagger/index.html

6. Basic commands

-   Redis
    -   Ping
    -   Set <key> <value>
    -   Get <key>
    -   INCR <key_integer>
    -   LPUSH <key> [element1, element2]
    -   LINDEX <key> <index>
    -   LRANGE <key> <from: ex 0> <to: ex 2 or -1 for all>
