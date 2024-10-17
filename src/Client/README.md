# Frontend  для проекта ЦифраЛаб
Приложение представляет из себя клиентскую часть сервиса обработки заявок и инструментарий работы с реестрами, справочниками и отчетами.
Приложение создано при помощи [Create React App](https://create-react-app.dev/).

[Технологии](#technology)  
[Установка приложения](#install)    
[Справочная информация](#inform)    

<a name="technology"><h2>Стек технологий</h2></a>
- [React](https://ru.legacy.reactjs.org/)
- [React-Redux](https://react-redux.js.org/)
- [Redux Toolkit](https://redux-toolkit.js.org/)
- [RTK Query](https://redux-toolkit.js.org/rtk-query/overview)
- [React Router](https://reactrouter.com/en/main)
- [Ant Design](https://ant.design/components/overview)
- [React Bootstrap](https://react-bootstrap.netlify.app/)
- [eslint](https://eslint.org/)
- [jest](https://jestjs.io/ru/docs/tutorial-react)

<a name="install"><h2>Установка приложения</h2></a>
### На Windows



### На Ubuntu
1) Установите nodejs:
```
# installs nvm (Node Version Manager)
curl -o- https://raw.githubusercontent.com/nvm-sh/nvm/v0.40.0/install.sh | bash

# download and install Node.js (you may need to restart the terminal)
nvm install 20

# verifies the right Node.js version is in the environment
node -v # should print `v20.18.0`

# verifies the right npm version is in the environment
npm -v # should print `10.8.2`
```
2) Откройте в терминале директорию [Client](./src/Client)
3) Установите необходимые зависимости: выполните команду `make install` (все необходимые команды расположены в файле [Makefile](./src/Client/Makefile))
4) В файле [package.json](./src/Client/package.json)) в поле `proxy` указывается адрес сервера, куда приложение будет отсылать запросы, при необходимости исправьте его на нужное (необходимый вам сервер)
5) Запустите приложение: выполните команду `make start` - [Create React App](https://create-react-app.dev/) запустит локальный сервер по адресу [localhost:3000](url) и откроет в браузере страницу приложения (если не откроет, откройте сами)

### Возможные проблемы при установке
- Если порт 3000 уже занят другим процессом, React предложит использовать другой порт или можно остановить занятый процесс
- Если при запуске возникают ошибки, убедитесь, что все зависимости установлены корректно через команду npm install

<a name="inform"><h2>Справочная информация</h2></a>
- [Makefile](https://guides.hexlet.io/ru/makefile-as-task-runner/)
- [Create React App](https://create-react-app.dev/)
- [Node.js и npm](https://habr.com/ru/articles/243335/)
- [nvm](https://habr.com/ru/companies/timeweb/articles/541452/)
- [CRA и localhost:3000](https://ru.w3docs.com/quiz/question/AQN0AN==#:~:text=%D0%9F%D0%BE%20%D1%83%D0%BC%D0%BE%D0%BB%D1%87%D0%B0%D0%BD%D0%B8%D1%8E%20Create%2DReact%2DApp,%D0%B2%D0%B0%D1%88%D0%B5%20%D0%BF%D1%80%D0%B8%D0%BB%D0%BE%D0%B6%D0%B5%D0%BD%D0%B8%D0%B5%2C%20%D1%81%D0%BB%D1%83%D1%88%D0%B0%D0%B5%D1%82%20%D0%BF%D0%BE%D1%80%D1%82%203000.)