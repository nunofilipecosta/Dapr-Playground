# root folder

./bindings

docker build -f .\Subject.Actor\Dockerfile . -t nunofilipecosta/subjectactor:dev

kubectl apply -f namespace.yaml
kubectl apply -f dapr-config.yaml
kubectl apply -f subjectactor-deployment.yaml
