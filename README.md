# APIWithRedis
.NET 6 MVC API with REDIS as primary database.
![alt text](https://i.imgur.com/ah7y5OG.png)

# Technologies&Features
- .NET 6 MVC API
- VS Code
- Redis
- Docker
- Swagger
- Data Transfer Objects
- Repositor Pattern
- Auto Mapper
- IConnectionMultiplexer

# Step by step
## 1. Create project
- Create project with command:
```bash
dotnet new webapi -n ApiWithRedis
```
- Open project in VS Code:
```bash
code -r ApiWithRedis
```
- Try to first run:
```bash
dotnet run
```
## 2. Add Nuget packages
- Caching StackExchangeRedis
```bash
dotnet add package Microsoft.Extensions.Caching.StackExchangeRedis 
```
- Auto Mapper & Dependency Injection
```bash
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection
```
## 3. Setup Redis in Docker
- add docker-compose.yaml file
- start docker
```bash
docker-compose up -d
```
## 5. Setup connection with Redis in Program.cs using IconnectionMultiplexer
## 5. Create Models and DTOs
## 6. Create Interface for Repository Pattern 
- create IPlatformRepo and PlatformRepo
- register repository interface in Program.cs
## 6. Add Auto Mapper to Program.cs and create Profile

```
## 7. Create controller with endpoints
- use auto mapper
## 10. Config Swagger
