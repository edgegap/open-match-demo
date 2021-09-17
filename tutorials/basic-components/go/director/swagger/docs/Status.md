# Status

## Properties
Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**RequestId** | **string** | The Unique ID of the Request | [default to null]
**Fqdn** | **string** | The FQDN that allow to connect to your instance | [default to null]
**AppName** | **string** | The name of the deployed App | [default to null]
**AppVersion** | **string** | The version of the deployed App | [default to null]
**CurrentStatus** | **string** | The Current Status of the Request | [default to null]
**Running** | **bool** | True if the Current Request is Ready to be connected and running | [default to null]
**WhitelistingActive** | **bool** | True if the Current Request is ACL Protected | [default to null]
**StartTime** | **string** | Timestamp of the beginning of the Request | [default to null]
**ElapsedTime** | **int32** | Time since the Request is up and running in seconds | [default to null]
**LastStatus** | **string** | The Last Status of the Request | [optional] [default to null]
**Error_** | **bool** | True if there is an Error with the Request | [default to null]
**ErrorDetail** | **string** | The Error detail of the Request | [optional] [default to null]
**Ports** | [**map[string]PortMapping**](PortMapping.md) |  | [optional] [default to null]
**PublicIp** | **string** | The public IP | [default to null]
**Sessions** | [**[]DeploymentSessionContext**](DeploymentSessionContext.md) | List of Active Sessions if Deployment App is Session Based | [optional] [default to null]
**Location** | [***DeploymentLocation**](DeploymentLocation.md) | Location related information | [optional] [default to null]
**Tags** | **[]string** | List of tags associated with the deployment | [optional] [default to null]
**Sockets** | **int32** | The Capacity of the Deployment | [optional] [default to null]
**SocketsUsage** | **int32** | The Capacity Usage of the Deployment | [optional] [default to null]

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)


