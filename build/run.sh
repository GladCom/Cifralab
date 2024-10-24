#!/bin/bash

STEND_NAME=$1
SCRIPT_PATH=$(realpath "${0}")
SCRIPT_DIR=$(dirname "${SCRIPT_PATH}")

docker compose --file ${SCRIPT_DIR}/compose/docker-compose.base.yaml --file ${SCRIPT_DIR}/compose/docker-compose.${STEND_NAME}.yaml --project-name ${STEND_NAME} up -d