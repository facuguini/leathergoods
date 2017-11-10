New-Variable -Name "root" -Value $pwd
# New-Variable -Name "run" -Value "dotnet run"

# Set ASPNETCORE ENVIRONMENT var. Choose between [Production, Development]
New-Variable -Name "ASPNETCORE_ENVIRONMENT" -Value "<Your Environment Here>"
# Set DB_PROVIDER ENVIRONMENT var. Choose between [MSSQLServer, Oracle, Postgres]
New-Variable -Name "DB_PROVIDER" -Value "<Your Provider Here>"
# Main Database connection string
New-Variable -Name "DB_CONNECTION_STRING" -Value "<Your Environment Here>"
# Set CACHE_STORE_PROVIDER var. Choose between [Redis, Mongo]
New-Variable -Name "CACHE_STORE_PROVIDER" -Value "<Your Environment Here>"
# Cache Database connection string
New-Variable -Name "CACHE_STORE_CONNECTION_STRING" -Value "<Your Environment Here>"

# API URL
New-Variable -Name "API_URL" -Value "<Your API URL Here>"
New-Variable -Name "WEB_URL" -Value "<Your API URL Here>"

New-Variable -Name local_path -VALUE "$($pwd)/local.ps1"
If(!(Test-Path $local_path)) {
  New-Item $local_path -type file
  "[Environment]::SetEnvironmentVariable(`"ASPNETCORE_ENVIRONMENT`", `"$($ASPNETCORE_ENVIRONMENT)`", `"Machine`")" >> $local_path
  "[Environment]::SetEnvironmentVariable(`"DB_PROVIDER`", `"$($DB_PROVIDER)`", `"Machine`")" >> $local_path
  "[Environment]::SetEnvironmentVariable(`"DB_CONNECTION_STRING`", `"$($DB_CONNECTION_STRING)`", `"Machine`")" >> $local_path
  "[Environment]::SetEnvironmentVariable(`"CACHE_STORE_PROVIDER`", `"$($CACHE_STORE_PROVIDER)`", `"Machine`")" >> $local_path
  "[Environment]::SetEnvironmentVariable(`"CACHE_STORE_CONNECTION_STRING`", `"$($CACHE_STORE_CONNECTION_STRING)`", `"Machine`")" >> $local_path
  "[Environment]::SetEnvironmentVariable(`"API_URL`", `"$($API_URL)`", `"Machine`")" >> $local_path
  "[Environment]::SetEnvironmentVariable(`"WEB_URL`", `"$($WEB_URL)`", `"Machine`")" >> $local_path
}
invoke-expression -Command $local_path
