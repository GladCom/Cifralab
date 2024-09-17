#!/bin/bash
DIR=$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd );
echo $DIR;
cd "${DIR}";
cd ../src;

# Первый аргумент имя тега, значение по умолчанию latest
TAG="${1:-latest}";
IMAGE="cifralabs.students.api:$TAG"
echo $IMAGE

# Сборка бэкенда
docker build -t $IMAGE .

# Сборка фронтенда
docker build -t cifralabs.students.front:latest ./Client