#!/bin/bash

DIR=$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd );
echo $DIR;
cd "${DIR}";

cd ../bild;

docker compose --file docker-compose.yaml up -d