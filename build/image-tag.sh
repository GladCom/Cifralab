#!/bin/bash

# Когда заливаем в main тег образа это имя сливаемой ветки.
# Берем имя ветки из переменной CI_COMMIT_TITLE, там будет что-то подобное:
# "Merge branch 'my_cool_branch' into 'main'"
IMAGE_TAG_NAME=$(echo "${1}" | cut -d ' ' -f 3)
IMAGE_TAG_NAME="${IMAGE_TAG_NAME:1:-1}"

# Убераем из имени некоторые сиволы допустимы для веток git но не для тегов docker
IMAGE_TAG_NAME=$(echo "${IMAGE_TAG_NAME}" | tr -d "{}[]:;,")
echo $IMAGE_TAG_NAME