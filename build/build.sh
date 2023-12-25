#!/bin/bash
DIR=$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )
echo $DIR
cd "${DIR}"
cd ../src
docker build -t cifralabs.studentsapi:latest .