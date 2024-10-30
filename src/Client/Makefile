# Makefile

install: # Установка зависимостей
	npm ci

build: # Сборка
	npm run build

start: #  Запуск приложения (на localhost:3000)
	npm start

test: #  Запуск тестов (Jest)
	npm test

lint: #  Запуск линтера
	npx eslint

server: #  Запуск тестового сервера
	node test_server/server.js

test: #  Запуск тестов (Jest)
	npm test

dockerBuild: 
	docker build -t cyfralab-app --build-arg API_PROXY=http://localhost:2056/ .

dockerStart:
	docker run -p 80:3000 cyfralab-app
