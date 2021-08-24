# \DeploymentsApi

All URIs are relative to *https://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ContextGet**](DeploymentsApi.md#ContextGet) | **Get** /v1/context/{request_id}/{security_number} | Allow to get the Context of a deployment
[**Deploy**](DeploymentsApi.md#Deploy) | **Post** /v1/deploy | Allow to deploy a new Instance of an App
[**DeploymentDelete**](DeploymentsApi.md#DeploymentDelete) | **Delete** /v1/stop/{request_id} | Allow to stop an instance for the client
[**DeploymentGetLogs**](DeploymentsApi.md#DeploymentGetLogs) | **Get** /v1/deployment/{request_id}/container-logs | Allow to get the Container Logs of a Deployment
[**DeploymentStatusGet**](DeploymentsApi.md#DeploymentStatusGet) | **Get** /v1/status/{request_id} | Allow to get The current status of a request
[**DeploymentsGet**](DeploymentsApi.md#DeploymentsGet) | **Get** /v1/deployments | Allow to get the List of Deployments
[**SelfDeploymentDelete**](DeploymentsApi.md#SelfDeploymentDelete) | **Delete** /v1/self/stop/{request_id}/{access_point_id} | Allow to stop an instance for the client from inside a container


# **ContextGet**
> Deployment ContextGet(ctx, requestId, securityNumber, authorization)
Allow to get the Context of a deployment

Request Deployment Context Info You should use this URL inside your deployment. The URL is injected in your deployment and can be found via the environment variable named ARBITRIUM_CONTEXT_URL

### Required Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **ctx** | **context.Context** | context for authentication, logging, cancellation, deadlines, tracing, etc.
  **requestId** | **string**| Unique Identifier to keep track of your request across all Arbitrium ecosystem.  | 
  **securityNumber** | **int32**| Random Security number generate to validate the request id. | 
  **authorization** | **string**| Auto Generated token. This token is injected in your deployment and can be found via the environment variable named ARBITRIUM_CONTEXT_TOKEN  | 

### Return type

[**Deployment**](Deployment.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **Deploy**
> Request Deploy(ctx, payload)
Allow to deploy a new Instance of an App

Deploy an Application

### Required Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **ctx** | **context.Context** | context for authentication, logging, cancellation, deadlines, tracing, etc.
  **payload** | [**DeployModel**](DeployModel.md)|  | 

### Return type

[**Request**](Request.md)

### Authorization

[apikey](../README.md#apikey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **DeploymentDelete**
> Delete DeploymentDelete(ctx, requestId, optional)
Allow to stop an instance for the client

Delete a deployment

### Required Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **ctx** | **context.Context** | context for authentication, logging, cancellation, deadlines, tracing, etc.
  **requestId** | **string**| Unique Identifier to keep track of your request across all Arbitrium ecosystem. It&#39;s included in the response of the app deploy, example:    93924761ccde | 
 **optional** | ***DeploymentsApiDeploymentDeleteOpts** | optional parameters | nil if no parameters

### Optional Parameters
Optional parameters are passed through a pointer to a DeploymentsApiDeploymentDeleteOpts struct

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------

 **containerLogStorage** | **optional.String**| If you want to enable the container log storage for the deployment. You can put &#39;true&#39; if you already have endpoint storage associated with your deployment&#39;s app version. You can put &#39;false&#39; if it is enabled by default and you want to disable it for this specific request. Or you can put the name of your endpoint storage and if it is valid we will store the container logs. | 

### Return type

[**Delete**](Delete.md)

### Authorization

[apikey](../README.md#apikey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **DeploymentGetLogs**
> DeploymentLogs DeploymentGetLogs(ctx, requestId)
Allow to get the Container Logs of a Deployment

Get a deployment container log.

### Required Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **ctx** | **context.Context** | context for authentication, logging, cancellation, deadlines, tracing, etc.
  **requestId** | **string**|  | 

### Return type

[**DeploymentLogs**](DeploymentLogs.md)

### Authorization

[apikey](../README.md#apikey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **DeploymentStatusGet**
> Status DeploymentStatusGet(ctx, requestId)
Allow to get The current status of a request

Get Deployment Request status

### Required Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **ctx** | **context.Context** | context for authentication, logging, cancellation, deadlines, tracing, etc.
  **requestId** | **string**| Unique Identifier to keep track of your request across all Arbitrium ecosystem. It&#39;s included in the response of the app deploy, example:    93924761ccde | 

### Return type

[**Status**](Status.md)

### Authorization

[apikey](../README.md#apikey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **DeploymentsGet**
> Deployments DeploymentsGet(ctx, )
Allow to get the List of Deployments

Get All Deployments

### Required Parameters
This endpoint does not need any parameter.

### Return type

[**Deployments**](Deployments.md)

### Authorization

[apikey](../README.md#apikey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **SelfDeploymentDelete**
> Delete SelfDeploymentDelete(ctx, requestId, accessPointId, authorization, optional)
Allow to stop an instance for the client from inside a container

Self Delete a deployment You should use this URL inside your deployment. The URL is injected in your deployment and can be found via the environment variable named ARBITRIUM_DELETE_URL

### Required Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **ctx** | **context.Context** | context for authentication, logging, cancellation, deadlines, tracing, etc.
  **requestId** | **string**| Unique Identifier to keep track of your request across all Arbitrium ecosystem. It&#39;s included in the response of the app deploy, example:    93924761ccde | 
  **accessPointId** | **int32**| Access Point Number provided by our system | 
  **authorization** | **string**| Auto Generated token. This token is injected in your deployment and can be found via the environment variable named ARBITRIUM_DELETE_TOKEN | 
 **optional** | ***DeploymentsApiSelfDeploymentDeleteOpts** | optional parameters | nil if no parameters

### Optional Parameters
Optional parameters are passed through a pointer to a DeploymentsApiSelfDeploymentDeleteOpts struct

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------



 **containerLogStorage** | **optional.String**| If you want to enable the container log storage for the deployment. You can put &#39;true&#39; if you already have endpoint storage associated with your deployment&#39;s app version. You can put &#39;false&#39; if it is enabled by default and you want to disable it for this specific request. Or you can put the name of your endpoint storage and if it is valid we will store the container logs. | 

### Return type

[**Delete**](Delete.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

