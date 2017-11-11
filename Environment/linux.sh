#!/usr/bin/env bash

export ROOT=`pwd`

export RUN="dotnet run"

alias lg_run_web="$RUN --project $ROOT/Web/UI/UI.csproj"
alias lg_run_api="$RUN --project $ROOT/API/API.csproj"


# Set ASPNETCORE ENVIRONMENT var. Choose between [Production, Development]
export ASPNETCORE_ENVIRONMENT='<Your Environment Here>'
# Set DB_PROVIDER ENVIRONMENT var. Choose between [MSSQLServer, Oracle, Postgres, MySQL]
export DB_PROVIDER='<Your Provider Here>'
# Main Database connection string
export DB_CONNECTION_STRING='<Your Environment Here>'
# Set CACHE_STORE_PROVIDER var. Choose between [Redis, Mongo]
export CACHE_STORE_PROVIDER='<Your Environment Here>'
# Cache Database connection string
export CACHE_STORE_CONNECTION_STRING='<Your Environment Here>'

# API URL
export API_URL='<Your API URL Here>'
export WEB_URL='<Your API URL Here>'


if [ ! -f Environment/local_linux.sh ]; then
    echo $'echo \"Local vars\"' > Environment/local_linux.sh
    chmod o+x Environment/local_linux.sh
fi
. $ROOT/Environment/local_linux.sh
