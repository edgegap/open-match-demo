# Request

## Properties
Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**RequestId** | **string** | The Unique Identifier of the request | [default to null]
**RequestDns** | **string** | The URL to connect to the instance | [default to null]
**RequestApp** | **string** | The Name of the App you requested | [default to null]
**RequestVersion** | **string** | The name of the App Version you requested | [default to null]
**RequestUserCount** | **int32** | How Many Users your request contain | [default to null]
**City** | **string** | The city where the deployment is located | [optional] [default to null]
**Country** | **string** | The country where the deployment is located | [optional] [default to null]
**Continent** | **string** | The continent where the deployment is located | [optional] [default to null]
**AdministrativeDivision** | **string** | The administrative division where the deployment is located | [optional] [default to null]
**Tags** | **[]string** | List of tags associated with the deployment | [optional] [default to null]
**ContainerLogStorage** | [***ContainerLogStorageModel**](ContainerLogStorageModel.md) | The container log storage options for the deployment | [default to null]

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)


