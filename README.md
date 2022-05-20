# Hyves-2.0-Backend

## UserService
[![UserService](https://github.com/bramhurkmans/Hyves-2.0-Backend/actions/workflows/gke-user-service.yml/badge.svg)](https://github.com/bramhurkmans/Hyves-2.0-Backend/actions/workflows/gke-user-service.yml) [![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=UserService_Hyves-2.0-Backend&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=UserService_Hyves-2.0-Backend) [![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=UserService_Hyves-2.0-Backend&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=UserService_Hyves-2.0-Backend) [![Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=UserService_Hyves-2.0-Backend&metric=vulnerabilities)](https://sonarcloud.io/summary/new_code?id=UserService_Hyves-2.0-Backend) [![Bugs](https://sonarcloud.io/api/project_badges/measure?project=UserService_Hyves-2.0-Backend&metric=bugs)](https://sonarcloud.io/summary/new_code?id=UserService_Hyves-2.0-Backend) [![Coverage](https://sonarcloud.io/api/project_badges/measure?project=UserService_Hyves-2.0-Backend&metric=coverage)](https://sonarcloud.io/summary/new_code?id=UserService_Hyves-2.0-Backend) [![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=UserService_Hyves-2.0-Backend&metric=code_smells)](https://sonarcloud.io/summary/new_code?id=UserService_Hyves-2.0-Backend)

## Frontend
[![FrontendService](https://github.com/bramhurkmans/Hyves-2.0-Backend/actions/workflows/gke-frontend-service.yml/badge.svg)](https://github.com/bramhurkmans/Hyves-2.0-Backend/actions/workflows/gke-frontend-service.yml)

## Gateway
[![GatewayService](https://github.com/bramhurkmans/Hyves-2.0-Backend/actions/workflows/gke-gateway-service.yml/badge.svg)](https://github.com/bramhurkmans/Hyves-2.0-Backend/actions/workflows/gke-gateway-service.yml)

Individiual project for Semester 6.

kubectl apply -f https://raw.githubusercontent.com/kubernetes/ingress-nginx/controller-v1.1.3/deploy/static/provider/cloud/deploy.yaml

kubectl create secret generic mssql --from-literal=SA_PASSWORD="pa55w0rd!"

helm install -f ./hyves2-chart/values.yaml hyves2-chart .\hyves2-chart\
