& "$PSScriptRoot\scripts\build-images.ps1"
kubectl apply --namespace open-match -f "$PSScriptRoot\yaml\open-match-core-1_2_0.yaml"
kubectl apply --namespace open-match -f "$PSScriptRoot\yaml\open-match-override-configmap-1_2_0.yaml" -f "$PSScriptRoot\yaml\open-match-default-evaluator-1_2_0.yaml"
kubectl -n open-match apply -f "$PSScriptRoot\yaml\basics.yaml"