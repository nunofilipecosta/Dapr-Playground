# Dapr ( https://dapr.io/ )

## Get started
Instal and initialize the dapr cli ( https://docs.dapr.io/getting-started/install-dapr-cli/ )

# Side car and components 

```Shell
dapr run --app-id myapp --dapr-http-port 3500
```

```PowerShell
Invoke-RestMethod -Method Post -ContentType 'application/json' -Body '[{ "key": "name", "value": "Bruce Wayne"}]' -Uri 'http://localhost:3500/v1.0/state/statestore'


Invoke-RestMethod -Uri 'http://localhost:3500/v1.0/state/statestore/name'
```
