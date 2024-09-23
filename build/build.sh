#!/bin/bash
DIR=$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd );
echo $DIR;
cd "${DIR}";
cd ../src;


# Первый аргумент имя тега, значение по умолчанию latest
TAG="${1:-latest}";
# Формируем имена образов
IMAGE_BACK="cifralabs.students.api:$TAG"
echo $IMAGE_BACK
IMAGE_FRONT="cifralabs.students.front:$TAG"
echo $IMAGE_FRONT


docker images
# Удаляем старый образ бэкенд если он есть
CURRENT_IMAGE_BACK=$(docker images -q $IMAGE_BACK)
if [[ -n $CURRENT_IMAGE_BACK ]]; then
  echo $CURRENT_IMAGE_BACK
  docker rmi $CURRENT_IMAGE_BACK
fi

# Удаляем старый образ фронтенда если он есть
CURRENT_IMAGE_FRONT=$(docker images -q $IMAGE_FRONT)
if [[ -n $CURRENT_IMAGE_FRONT ]]; then
  echo $CURRENT_IMAGE_FRONT
  docker rmi $CURRENT_IMAGE_FRONT
fi
docker images



# Сборка бэкенда
docker build -t $IMAGE_BACK .

# Сборка фронтенда
docker build -t $IMAGE_FRONT ./Client