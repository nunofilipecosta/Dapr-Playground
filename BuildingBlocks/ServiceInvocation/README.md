# Service Invocation

## Local

### First step

This example uses 2 dapr sidecars ( with different ports ) and we try to invoke methods on the dummy apps

```bash
dapr run -a app1 -p 7120 --dapr-http-port 3500 --app-ssl -- dotnet run --project .\App1\App1.csproj  
```

```bash
dapr run -a app2 -p 7241 --dapr-http-port 3501 --app-ssl -- dotnet run --project .\App2\App2.csproj  
```

```pwsh
Invoke-WebRequest https://localhost:7120/

Invoke-WebRequest http://localhost:3500/v1.0/invoke/app1/method/test

Invoke-WebRequest https://localhost:7241/

Invoke-WebRequest http://localhost:3501/v1.0/invoke/app2/method/

```

### Second step

This example uses the 2 daps sidecars and we try to invoke method 2 of app2 on the the service-dapr of sidecar 1

```powershell
Invoke-WebRequest http://localhost:3500/v1.0/invoke/app2/method/
```

## Kubernetes

### Step 1 
First we need to build app docker images

```
docker build -f app1/Dockerfile -t nunofilipecosta/app1:local .

docker run -d -p 3546:80 --rm --name app1 nunofilipecosta/app1:local
```

```
docker build -f app2/Dockerfile Dockerfile -t nunofilipecosta/app2:local .

docker run -d -p 3547:80 --rm --name app1 nunofilipecosta/app2:local
```

Access on a browser <http://localhost:3546/> && <http://localhost:3546/test>
Access on a browser <http://localhost:3547/>

### Step 2

deploy to kubernetes `.\deploy.ps1` 

### step 3

Install ingress `.\deploy-ingress.ps1`
Make sure you can access the urls

* <http://kubernetes.docker.internal/app1-service>
* <http://kubernetes.docker.internal/app1-service/test>
* <http://kubernetes.docker.internal/app2-service>

### step 4

Create a service to target sidecar
deploy the new service and new ingress rule

kubectl exec -it <pod-name> -c app1
kubectl exec -it <pod-name> -c app2


curl http://localhost:3500/v1.0/invoke/app2/method/
curl http://localhost:3500/v1.0/invoke/app2/method/ -v


http://hello-world.info/v1.0/invoke/app2/method/