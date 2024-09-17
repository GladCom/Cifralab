#!/bin/bash

DIR=$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd );
echo $DIR;

docker compose --file build/docker-compose.yaml down