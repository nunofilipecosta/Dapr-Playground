helm upgrade --install ingress-nginx ingress-nginx --repo https://kubernetes.github.io/ingress-nginx --namespace dapr-playground --create-namespace -f .\k8s\controller-dapr.yaml


#openssl req -x509 -sha256 -nodes -days 365 -newkey rsa:2048 -keyout tls.key -out tls.crt -subj "/CN=hello-world.info/O=hello-world.info"
kubectl create secret tls tls-secret -n dapr-playground --key tls.key --cert tls.crt
