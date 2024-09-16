#!/bin/bash

# Когда заливаем в main тег образа это имя сливаемой ветки.
# Берем имя ветки из переменной CI_COMMIT_TITLE, там будет что-то подобное:
# "Merge branch 'my_cool_branch' into 'main'"
echo ${1}
IMAGE_TAG_NAME=$(echo "${1}" | cut -d ' ' -f 3)
echo ${IMAGE_TAG_NAME}
IMAGE_TAG_NAME="${IMAGE_TAG_NAME:1:-1}"
echo ${IMAGE_TAG_NAME}

# Убераем из имени некоторые сиволы допустимы для веток git но не для тегов docker
IMAGE_TAG_NAME=$(echo "${IMAGE_TAG_NAME}" | tr -d "{}[]:;,")
echo $IMAGE_TAG_NAME