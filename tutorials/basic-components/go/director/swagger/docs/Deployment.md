# Deployment

## Properties
Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**RequestId** | **string** | Unique UUID | [default to null]
**PublicIp** | **string** | The public IP | [default to null]
**Status** | **string** | Current status of Deployment | [default to null]
**Ready** | **bool** | if the deployment is ready | [default to null]
**WhitelistingActive** | **bool** | if the deployment ACL is active | [default to null]
**Fqdn** | **string** |  | [default to null]
**Ports** | [**map[string]PortMapping**](PortMapping.md) |  | [optional] [default to null]
**Location** | [***DeploymentLocation**](DeploymentLocation.md) | Location related information | [optional] [default to null]
**Tags** | **[]string** | List of tags associated with the deployment | [optional] [default to null]
**Sockets** | **int32** | The Capacity of the Deployment | [optional] [default to null]
**SocketsUsage** | **int32** | The Capacity Usage of the Deployment | [optional] [default to null]

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)


