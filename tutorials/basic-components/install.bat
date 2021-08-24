call "%~dp0\scripts\build-images.bat"
kubectl apply --namespace open-match -f "%~dp0\yaml\open-match-core-1_2_0.yaml"
kubectl apply --namespace open-match -f "%~dp0\yaml\open-match-override-configmap-1_2_0.yaml" -f "%~dp0\yaml\open-match-default-evaluator-1_2_0.yaml"
kubectl -n open-match apply -f "%~dp0\yaml\basics.yaml"