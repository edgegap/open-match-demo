# SessionGet

## Properties
Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**SessionId** | **string** | Unique UUID | [default to null]
**CustomId** | **string** | Custom ID if Available | [default to null]
**Status** | **string** | Current status of the session | [default to null]
**Ready** | **bool** | If the session is linked to a ready deployment | [default to null]
**Linked** | **bool** | If the session is linked to a deployment | [default to null]
**Kind** | **string** | Type of session created | [default to null]
**UserCount** | **int32** | Count of user this session currently have | [default to null]
**AppId** | **int32** | App version linked to the session | [default to null]
**CreateTime** | **string** | Session created at | [default to null]
**Elapsed** | **int32** | Elapsed time | [default to null]
**Error_** | **string** | Error Detail | [optional] [default to null]
**SessionUsers** | [**[]SessionUser**](SessionUser.md) | Users in the session | [optional] [default to null]
**SessionIps** | [**[]SessionUser**](SessionUser.md) | IPS in the session | [optional] [default to null]
**Deployment** | [***Deployment**](Deployment.md) |  | [default to null]

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)


