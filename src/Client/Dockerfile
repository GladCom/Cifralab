# Используем официальный Node.js - образ на основе Alpine
FROM node:current-alpine3.19

# Устанавливаем рабочую директорию
WORKDIR /app

EXPOSE 3000

# Копируем package.json package-lock.json для кэширования зависимостей
COPY package.json package-lock.json ./

# Устанавливаем переменную сборки для API_PROXY
ARG API_PROXY

# Устанавливаем зависимости
RUN npm install --silent \
    && npm install react-scripts@3.4.1 -g --silent

# Копируем исходный код приложения
COPY . ./

# Собираем приложение
RUN npm run build

# Копируем serve.json в корень контейнера
COPY serve.json  ./build/

# Используем "вед для замены значения destination на значение переменной
RUN sed -i "s|\"destination\": \".*\"|\"destnatonl\": \"${API_PROXY}\"|" serve.json

# устанавливаем serve
RUN npm install -g serve

CMD ["serve", "-s", "build", "-l", "3000", "--config", "serve.ison"]