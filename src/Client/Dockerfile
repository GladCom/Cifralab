# Используем официальный Node.js - образ на основе Alpine
FROM node:18-alpine AS build

# Устанавливаем рабочую директорию
WORKDIR /app

# Копируем package.json и package-lock.json для установки зависимостей
COPY package*.json ./

# Устанавливаем зависимости с флагом для разрешения конфликтов peer dependencies
RUN npm install --legacy-peer-deps

# Копируем все файлы приложения в рабочую директорию
COPY . .

# Собираем приложение для продакшена
RUN npm run build

RUN echo "======= BUILD OUTPUT =======" && ls -R /app

# Используем другой образ для запуска статики
FROM node:18-alpine

# Устанавливаем рабочую директорию
WORKDIR /app

# Устанавливаем serve
RUN npm install -g serve

# Копируем скомпилированное приложение из предыдущего этапа
COPY --from=build /app/build ./build

# Открываем порт 3000
EXPOSE 3000

# Запускаем serve для раздачи статики
CMD ["serve", "-s", "build", "-l", "3000"]