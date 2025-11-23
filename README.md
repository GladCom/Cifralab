# cifralab_students
[![.github/workflows/.github-ci.yml](https://github.com/GladCom/Cifralab/actions/workflows/.github-ci.yml/badge.svg?branch=develop)](https://github.com/GladCom/Cifralab/actions/workflows/.github-ci.yml)

Запуск Backend:

1. Установить систему контроля версий git (https://git-scm.com/downloads, если желаете работать из консоли).<br>
Для работы в визуальной среде разработки (IDE) поставить: VisualStudio, Rider, любое IDE со встроенным git
(https://visualstudio.microsoft.com/ru/downloads/) 

2. В браузере открыть ссылку https://cifra2024.mooo.com/cifra/cifra/-/branches
    1. Выбрать ветку для тестирования / разработки.
    2. В правой части окна найти синюю кнопку "Код" (Code).
    3. Нажать и выбрать "Clone with https"
    4. Нажать на кнопку рядом с текстом "Копировать URL"
    5. В коммандной строке "GIT CMD" набрать git clone "Сюда вставить, то что было скопировано на предыдущем шаге" и нажать enter

3. Установка переменных окружения (настраивается каждый раз, если меняется адрес базы данных): 
    1. Win + R, в строчку вставьте sysdm.cpl и нажмите "ОК", выбирите вкладку "Дополнительно",в нижней части окна нажмите кнопку "Переменные среды". В части "Переменные среды пользователя..." создайте переменные окружения:<br>
    DBLogin<br>
    DBName<br>
    DBPassword<br>
    DBPort<br>
    DBServer<br>
    В них прописать значения для подключения к базе данных
4. Создание базы данных (если не хотите подключаться к внешнй базе данных, а развернуть польносьсью свой сервер баз данных)
Если базы еще нет, то запустить миграцию Migration.bat 
(в пути необходимо указать путь где располагается ваш локальный репозиторий) 
Для запуска Backend-Server-API запустить runAPI.bat (в пути необходимо указать путь где располагается ваш локальный репозиторий)

5. Запустить swagger можно через браузер, прописав в адресе http://localhost:5137/swagger/index.html (нужен для отладки методов Backend)

6. Исходные тексты для файлов:
    1. Migration.bat:<br>
        ```
        dotnet tool install --global dotnet-ef<br>
        cd C:\cifra_repository\src\Server\Students.DBCore<br>
        dotnet ef migrations add AddColumnIsArchive --context="PGContext"<br>
        dotnet ef database update --context="PGContext"
        ```
    2. runAPI.bat:
        ```
        cd C:\cifra_repository\src<br>
        dotnet build dotnet run --project Server\Students.APIServer --verbosity m --launch-profile http
        ```