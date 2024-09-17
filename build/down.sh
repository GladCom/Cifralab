#!/bin/bash

DIR=$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd );
echo $DIR;

docker ps -a
docker compose --file build/docker-compose.yaml down
docker ps -a