; Установить последний https://dotnet.microsoft.com/en-us/download/dotnet/3.1 в зависимости от системы
; C:\cifra_repository\src\Server\Students.DBCore - Заменить на путь до вашего проекта
; AddColumnIsArchive - Заменить на красивое название того ради чего произходит миграция (В нданном случае было добавленоа новая колонка, можно в помошь заявку из гита)

dotnet tool install --global dotnet-ef
cd C:\cifra_repository\src\Server\Students.DBCore
dotnet ef migrations add AddColumnIsArchive --context="PGContext"
dotnet ef database update --context="PGContext"