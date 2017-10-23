#!/usr/bin/env bash

export ROOT=`pwd`

export RUN="dotnet run"

alias lg_run_web="$RUN --project $ROOT/Web/UI/UI.csproj"
alias lg_run_api="$RUN --project $ROOT/API/API.csproj"


# Set ASPNETCORE ENVIRONMENT var. Choose between [Production, Development]
export ASPNETCORE_ENVIRONMENT='<Your Environment Here>'
# Main Database connection string
export CONNECTION_STRING='<Your Environment Here>'

# API URL
export API_URL='<Your API URL Here>'
export WEB_URL='<Your API URL Here>'


if [ ! -f Environment/local.sh ]; then
    echo $'echo \"Local vars\"' > Environment/local.sh
    chmod o+x Environment/local.sh
fi
. $ROOT/Environment/local.sh
