# Hyves-2.0-Backend
Individiual project for Semester 6

kubectl apply -f https://raw.githubusercontent.com/kubernetes/ingress-nginx/controller-v1.1.3/deploy/static/provider/cloud/deploy.yaml

kubectl create secret generic mssql --from-literal=SA_PASSWORD="pa55w0rd!"

helm install -f ./hyves2-chart/values.yaml hyves2-chart .\hyves2-chart\