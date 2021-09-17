# DeployModel

## Properties
Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AppName** | **string** | The Name of the App you want to deploy | [default to null]
**VersionName** | **string** | The Name of the App Version you want to deploy, if not present, the last version created is picked | [optional] [default to null]
**IpList** | **[]string** | The List of IP of your user | [optional] [default to null]
**GeoIpList** | [**[]GeoIpListModel**](GeoIpListModel.md) | The list of IP of your user with their location (latitude, longitude) | [optional] [default to null]
**EnvVars** | [**[]DeployEnvModel**](DeployEnvModel.md) | A list of deployment variables | [optional] [default to null]
**SkipTelemetry** | **bool** | If you want to skip the Telemetry and use a geolocations decision only | [optional] [default to null]
**Location** | [***LocationModel**](LocationModel.md) | If you want to specify a centroid for your deployment. | [optional] [default to null]
**City** | **string** | If you want to deploy in a specific city | [optional] [default to null]
**Country** | **string** | If you want to deploy in a specific country | [optional] [default to null]
**Continent** | **string** | If you want to deploy in a specific continent | [optional] [default to null]
**Region** | **string** | If you want to deploy in a specific region | [optional] [default to null]
**AdministrativeDivision** | **string** | If you want to deploy in a specific administrative division | [optional] [default to null]
**WebhookUrl** | **string** | A web URL. This url will be called with method POST. The deployment status will be send in JSON format | [optional] [default to null]
**Tags** | **[]string** | The list of tags for your deployment | [optional] [default to null]
**ContainerLogStorage** | [***ContainerLogStorageModel**](ContainerLogStorageModel.md) | The container log storage options for the deployment | [optional] [default to null]

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)


