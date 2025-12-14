<img width="1024" height="512" alt="Без имени" src="https://github.com/user-attachments/assets/ae2cc515-b428-4dd0-9bfe-e6c6d9db31e7" />

[![Pull Request CI](https://github.com/GladCom/Cifralab/actions/workflows/ci_pullrequest.yml/badge.svg)](https://github.com/GladCom/Cifralab/actions/workflows/ci_pullrequest.yml) [![CI/CD Pipeline](https://github.com/GladCom/Cifralab/actions/workflows/cicd.yml/badge.svg)](https://github.com/GladCom/Cifralab/actions/workflows/cicd.yml) [![CodeQL](https://github.com/GladCom/Cifralab/actions/workflows/github-code-scanning/codeql/badge.svg)](https://github.com/GladCom/Cifralab/actions/workflows/github-code-scanning/codeql)

Учебная платформа для студентов курса ["ЦифраЛаб"](https://academy.udmr.ru/promprogramming).

[Академия «Цифра»](https://academy.udmr.ru/) — учебный центр по подготовке ИТ-специалистов, созданный при поддержке Минцифры УР. Чтобы записаться на курс будущие студенты оставляют на сайте заявку на обучение по выбранной программе. Наш сервис даёт возможность интеграции с сайтом Академии, обрабатывать и управлять заявками, зачислять студентов на курс и многое другое.

# Содержание
- [Работа с исходниками](#работа-с-исходниками)
  - [Подготовка окружения](#подготовка-окружения)
  - [Развёртывание серверной части на Windows](#развёртывание-серверной-части-на-windows)
  - [Развёртывание клиентской части на Windows](#развёртывание-клиентской-части-на-windows)

# Работа с исходниками

## Подготовка окружения

0. Чтобы скачать как git-репозиторий: ```git clone https://github.com/GladCom/Cifralab.git```. 
Или скачать последний релиз репозитория, либо же конкретную версию ветки.
1. Скачайте [PostgreSQL 14](https://www.enterprisedb.com/downloads/postgres-postgresql-downloads).
> [!NOTE]
> Для подключения к серверу БД на хосте пропустите этап с установкой PG локально.
2. Скачайте [.NET 7](https://dotnet.microsoft.com/ru-ru/download/dotnet/7.0)
3. Скачайте [node.js 18 версии](https://nodejs.org/en/download)
> [!NOTE]
> После всех установок рекомендуется перезапустить систему, если вы ещё этого не сделали.


## Развёртывание серверной части на Windows

1. Установка переменных окружения. 
   1. Запустите окно "Выполнить" (Win + R)
   2. Введите `sysdm.cpl` и нажмите "ОК"
   3. Выберете вкладку "Дополнительно"
   4. В нижней части окна нажмите кнопку "Переменные среды". 
   5. В части "Переменные среды пользователя..." создайте переменные окружения:
       - DBLogin
       - DBName
       - DBPassword
       - DBPort
       - DBServer
    
       В них прописать значения для подключения к базе данных.
> [!IMPORTANT] 
> Убедитесь, что заданный пользователь в DBLogin действительно существует.
2. Если БД уже существует, то запустите миграцию БД. TODO дописать: @dezodemius.
3. Через `cmd` из папки `src` запустите сборку проекта командой `dotnet build Students.sln`.
4. Из папки `src/Server/Students.APIServer` запустите сервер командой `dotnet run .\Students.APIServer.csproj`
5. Готово! 
   - Доступ к Swagger осуществляется по адресу http://localhost:5137/Swagger/index.html.
   - API сервера доступно по адресу http://localhost:5137


## Развёртывание клиентской части на Windows

1. Перейдите в папку `src/Client`.
2. Запустите в этой папке `cmd` и запустите установку зависимостей командой `npm install --legacy-peer-deps`.
3. В папке `src/Client` создать файл `.env` со следующим содержимым:
   ```js
   REACT_APP_API_URL=http://localhost:5137
   ```
4. Запустить клиент из этой же папки командой `npm start`.
5. Готово!
   - Доступ к клиенту осуществляется по адресу http://localhost:3000/.