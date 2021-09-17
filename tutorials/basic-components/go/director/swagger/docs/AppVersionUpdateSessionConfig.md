# AppVersionUpdateSessionConfig

## Properties
Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Kind** | **string** | The kind of session to create. If &#39;Default&#39; if chosen, the application will be handled like a normal application. | [optional] [default to null]
**Sockets** | **int32** | The number of game slots on each deployment of this app version. | [optional] [default to null]
**Autodeploy** | **bool** | If a deployment should be made autonomously if there is not enough sockets open on a new session. | [optional] [default to null]
**EmptyTtl** | **int32** | The number of minutes a deployment of this app version can spend with no session connected before being terminated. | [optional] [default to null]

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)


