#! /usr/bin/env bash
set -uvx
set -e
cd "$(dirname "$0")"
cwd=`pwd`
ts=`date "+%Y.%m%d.%H%M.%S"`
dotnet run --project Javascript.Demo/Javascript.Demo.csproj --framework net462 "$@"
