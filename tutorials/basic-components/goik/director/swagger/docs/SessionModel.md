# SessionModel

## Properties
Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AppName** | **string** | The Name of the App you want to deploy, example:    supermario | [default to null]
**VersionName** | **string** | The Name of the App Version you want to deploy, example:    v1.0 | [optional] [default to null]
**IpList** | **[]string** | The List of IP of your user, Array of String, example:     [\&quot;162.254.103.13\&quot;,\&quot;198.12.116.39\&quot;, \&quot;162.254.135.39\&quot;, \&quot;162.254.129.34\&quot;] | [optional] [default to null]
**GeoIpList** | [**[]GeoIpListModel**](GeoIpListModel.md) | The list of IP of your user with their location (latitude, longitude) | [optional] [default to null]
**DeploymentRequestId** | **string** | The request id of your deployment. If specified, the session will link to the deployment | [optional] [default to null]
**Location** | [***LocationModel**](LocationModel.md) | If you want to specify a centroid for your session. | [optional] [default to null]
**City** | **string** | If you want your session in a specific city | [optional] [default to null]
**Country** | **string** | If you want your session in a specific country | [optional] [default to null]
**Continent** | **string** | If you want your session in a specific continent | [optional] [default to null]
**AdministrativeDivision** | **string** | If you want your session in a specific administrative division | [optional] [default to null]
**Region** | **string** | If you want your session in a specific region | [optional] [default to null]

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)


