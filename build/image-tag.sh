#!/bin/bash

# Когда заливаем в main тег образа это имя сливаемой ветки.
# Берем имя ветки из переменной CI_COMMIT_TITLE, там будет что-то подобное:
# "Merge branch 'my_cool_branch' into 'main'"
IMAGE_TAG=$(echo "${1}" | cut -d ' ' -f 3)
IMAGE_TAG="${IMAGE_TAG:1:-1}"

# Убераем из имени некоторые сиволы допустимы для веток git но не для тегов docker
IMAGE_TAG=$(echo "${IMAGE_TAG}" | tr -d "{}[]:;,")
echo $IMAGE_TAG