# Custom component

## secrets store

### stop the app 
```
dapr stop myapp
```

### Run the sidecar with custom component
```
dapr run --app-id myapp --dapr-http-port 3500 --components-path ./my-components
```

Get the secret 
```Powershell
Invoke-RestMethod -Uri 'http://localhost:3500/v1.0/secrets/my-secret-store/my-secret'
```