# Deploy

Развертывание приложения Students.API

> **Среда для развертывания**
>
> Необходимо убедиться, что на компьютере для развертывания установлен пакет Docker и Docker Compose
>


## Локальный запуск
Для локального запуска API сервера необходимо подключить InMemoryContext вместо PgContext.
Сделать это можно в файле **Students.APIServer\Program.cs**. Необходимо закоментировать строку 
```C#
builder.Services.AddDbContext<StudentContext, PgContext>();
```
и раскоментировать 
```C#
builder.Services.AddDbContext<StudentContext, InMemoryContext>();
```
Сущности, созданные в InMemoryContext можно изменить в **Students.DBCore\Contexts\InMemoryContext.cs**

## Запуск в тестовой среде Docker
Для запуска в тестовой среде необходимо собрать Docker Image для Students.API.
Необходимо в директории **build** запустить файл **build.bat** или **build.sh** в зависимости от типа ОС.
`./build.sh`
Ожидаемый результат
```Shell
[+] Building 0.1s (18/18) FINISHED                                                                                                                                                     docker:desktop-linux
 => [internal] load .dockerignore                                                                                                                                                                      0.0s
 => => transferring context: 419B                                                                                                                                                                      0.0s
 => [internal] load build definition from Dockerfile                                                                                                                                                   0.0s
 => => transferring dockerfile: 706B                                                                                                                                                                   0.0s
 => [internal] load metadata for mcr.microsoft.com/dotnet/sdk:7.0                                                                                                                                      0.0s
 => [internal] load metadata for mcr.microsoft.com/dotnet/aspnet:7.0                                                                                                                                   0.0s
 => [build 1/7] FROM mcr.microsoft.com/dotnet/sdk:7.0                                                                                                                                                  0.0s
 => [base 1/2] FROM mcr.microsoft.com/dotnet/aspnet:7.0                                                                                                                                                0.0s
 => [internal] load build context                                                                                                                                                                      0.0s
 => => transferring context: 9.14kB                                                                                                                                                                    0.0s
 => CACHED [base 2/2] WORKDIR /app                                                                                                                                                                     0.0s
 => CACHED [final 1/2] WORKDIR /app                                                                                                                                                                    0.0s
 => CACHED [build 2/7] WORKDIR /src                                                                                                                                                                    0.0s
 => CACHED [build 3/7] COPY [Server/Students.APIServer/Students.APIServer.csproj, Server/Students.APIServer/]                                                                                          0.0s
 => CACHED [build 4/7] RUN dotnet restore "Server/Students.APIServer/Students.APIServer.csproj"                                                                                                        0.0s
 => CACHED [build 5/7] COPY . .                                                                                                                                                                        0.0s
 => CACHED [build 6/7] WORKDIR /src/Server/Students.APIServer                                                                                                                                          0.0s
 => CACHED [build 7/7] RUN dotnet build "Students.APIServer.csproj" -c Release -o /app/build                                                                                                           0.0s
 => CACHED [publish 1/1] RUN dotnet publish "Students.APIServer.csproj" -c Release -o /app/publish /p:UseAppHost=false                                                                                 0.0s
 => CACHED [final 2/2] COPY --from=publish /app/publish .                                                                                                                                              0.0s
 => exporting to image                                                                                                                                                                                 0.0s
 => => exporting layers                                                                                                                                                                                0.0s
 => => writing image sha256:61467226e2dbe53d00f5421f2829ab12edfa0317093dd3b4ec575331c1e98965                                                                                                           0.0s
 => => naming to docker.io/library/cifralabs.studentsapi:latest 
```
Далее необходимо запустить решение через docker compose, для этого необходимо выполнить
`
./run.sh
`
Ожидаемый результат
```Shell
[+] Building 0.0s (0/0)                                                                                                                                                                docker:desktop-linux
[+] Running 3/3                                                                                                                                                             0.2s 
 ✔ Container students.api      Started                                                                                                                                                                 0.3s 
 ✔ Container postgres          Started     
```
После чего можно проверить работу Swagger UI в браузере
`
http://localhost/swagger/index.html
`
## Запуск в продуктивной среде
Для запуска в продуктивной среде необходимо собрать контейнер по инструкции выше и отредактировать файл **docker-compose.yaml**
В файле необходимо удалить секцию postgres и в переменных окружения прописать подключение к продуктивной БД

Пример:
```Docker
version: '3.3'
services:
    students.api:
        ports:
            - '80:80'
        environment:
            - 'ASPNETCORE_URLS=http://+'
            - DBServer=IP или URL сервера
            - DBPort=5432
            - DBName=Имя БД
            - DBLogin=логин сервисной УЗ
            - 'DBPassword=Пароль
        container_name: students.api
        image: cifralabs.studentsapi:latest
        restart: unless-stopped
```

## Инициализация БД
При первом развертывании БД в продуктивной или тестовой среде необходимо применить все миграции
Для этого на компьютере с установленным dotnet и efcore необходимо выполнить команду
`
dotnet ef database update --context Students.DBCore.Contexts.PgContext  --connection "Host=ip сервера;Port=5432;Database=cifralabs_studentDB;Username=cifralabs_studentDB_Service;Password=пароль;"
`