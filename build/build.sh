#!/bin/bash
DIR=$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd );
echo $DIR;
cd "${DIR}";
cd ../src;

# Первый аргумент имя тега, значение по умолчанию latest
TAG="${1:-latest}";
IMAGE="cifralabs.studentsapi:$TAG"
echo $IMAGE

docker build -t $IMAGE .