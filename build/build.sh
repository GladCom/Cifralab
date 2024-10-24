#!/bin/bash

SCRIPT_PATH=$(realpath "${0}")
SCRIPT_DIR=$(dirname "${SCRIPT_PATH}")
cd $SCRIPT_DIR
cd ../src;

# Первый аргумент имя тега, значение по умолчанию latest
TAG="${1:-latest}";
# Формируем имена образов
IMAGE_BACK="cifralabs.students.api:$TAG"
IMAGE_BACK_BACKUP=$IMAGE_BACK-old

IMAGE_FRONT="cifralabs.students.front:$TAG"
IMAGE_FRONT_BACKUP=$IMAGE_FRONT-old


docker images
# Удаляем старый образ бэкенд если он есть
CURRENT_IMAGE_BACK=$(docker images -q $IMAGE_BACK)
if [[ -n $CURRENT_IMAGE_BACK ]]; then
  docker tag $IMAGE_BACK $IMAGE_BACK_BACKUP
fi

# Удаляем старый образ фронтенда если он есть
CURRENT_IMAGE_FRONT=$(docker images -q $IMAGE_FRONT)
if [[ -n $CURRENT_IMAGE_FRONT ]]; then
  docker tag $IMAGE_BACK $IMAGE_BACK_BACKUP
fi
docker images

# Сборка бэкенда
docker build -t $IMAGE_BACK .

BUILD_BACK_STATUS=$?
if [[ $BUILD_BACK_STATUS > 0 ]]; then
  echo "Back build failed. Use old image." >&2
  docker tag $IMAGE_BACK_BACKUP $IMAGE_BACK
fi

# Сборка фронтенда
docker build -t $IMAGE_FRONT ./Client


BUILD_FRONT_STATUS=$?
if [[ $BUILD_FRONT_STATUS > 0 ]]; then
  echo "Front build failed. Use old image." >&2
  docker tag $IMAGE_BACK_BACKUP $IMAGE_BACK
fi

BUILD_STATUS=$BUILD_BACK_STATUS
((BUILD_STATUS+=BUILD_FRONT_STATUS))

echo $BUILD_STATUS