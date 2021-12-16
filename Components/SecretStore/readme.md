# secrets store

## Run the sidecar with custom component

```bash
dapr run --app-id myapp --dapr-http-port 3500 --components-path ./my-components
```

Get the secret

```Powershell
Invoke-RestMethod -Uri 'http://localhost:3500/v1.0/secrets/my-secret-store/my-secret'
```

```PowerShell
Invoke-RestMethod -Method Post -ContentType 'application/json' -Body '[{ "key": "name", "value": "Bruce Wayne"}]' -Uri 'http://localhost:3500/v1.0/state/statestore'


Invoke-RestMethod -Uri 'http://localhost:3500/v1.0/state/statestore/name'
```

### stop the app

```bash
dapr stop myapp
```
