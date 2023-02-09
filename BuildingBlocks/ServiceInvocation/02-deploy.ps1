kubectl config use-context docker-desktop
kubectl create namespace dapr-playground

kubectl apply -f .\k8s\deployment-app1.yaml -f .\k8s\deployment-app2.yaml