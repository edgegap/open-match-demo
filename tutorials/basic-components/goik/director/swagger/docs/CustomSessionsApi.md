# \CustomSessionsApi

All URIs are relative to *https://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**DeleteCustomSession**](CustomSessionsApi.md#DeleteCustomSession) | **Delete** /v1/deployment/{request_id}/custom/session/{custom_id} | Delete a Custom Session from a Deployment
[**DeleteCustomSessions**](CustomSessionsApi.md#DeleteCustomSessions) | **Delete** /v1/deployment/{request_id}/custom/sessions | Delete Many Custom Sessions from a Deployment
[**GetCustomSession**](CustomSessionsApi.md#GetCustomSession) | **Get** /v1/deployment/{request_id}/custom/session/{custom_id} | Get a specific Custom Session from a Deployment
[**GetCustomSessions**](CustomSessionsApi.md#GetCustomSessions) | **Get** /v1/deployment/{request_id}/custom/sessions | Get Custom Sessions from a Deployment
[**PatchCustomSession**](CustomSessionsApi.md#PatchCustomSession) | **Patch** /v1/deployment/{request_id}/custom/session/{custom_id} | Update a Custom Session from a Deployment
[**PostCustomSession**](CustomSessionsApi.md#PostCustomSession) | **Post** /v1/deployment/{request_id}/custom/session/{custom_id} | Deploy a Custom Session to a Deployment
[**PostCustomSessions**](CustomSessionsApi.md#PostCustomSessions) | **Post** /v1/deployment/{request_id}/custom/sessions | Deploy Many Custom Sessions to a Deployment


# **DeleteCustomSession**
> Delete DeleteCustomSession(ctx, customId, requestId)
Delete a Custom Session from a Deployment

Delete a Custom Session from a Deployment

### Required Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **ctx** | **context.Context** | context for authentication, logging, cancellation, deadlines, tracing, etc.
  **customId** | **string**| Custom ID Managed by you | 
  **requestId** | **string**| Deployment Request ID | 

### Return type

[**Delete**](Delete.md)

### Authorization

[apikey](../README.md#apikey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **DeleteCustomSessions**
> BulkSessionDelete DeleteCustomSessions(ctx, requestId, payload)
Delete Many Custom Sessions from a Deployment

Delete Many Custom Sessions from a Deployment

### Required Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **ctx** | **context.Context** | context for authentication, logging, cancellation, deadlines, tracing, etc.
  **requestId** | **string**| Deployment Request ID | 
  **payload** | [**CustomSessionDeleteModel**](CustomSessionDeleteModel.md)|  | 

### Return type

[**BulkSessionDelete**](BulkSessionDelete.md)

### Authorization

[apikey](../README.md#apikey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **GetCustomSession**
> SessionGet GetCustomSession(ctx, customId, requestId)
Get a specific Custom Session from a Deployment

Get a specific Custom Session from a Deployment

### Required Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **ctx** | **context.Context** | context for authentication, logging, cancellation, deadlines, tracing, etc.
  **customId** | **string**| Custom ID Managed by you | 
  **requestId** | **string**| Deployment Request ID | 

### Return type

[**SessionGet**](SessionGet.md)

### Authorization

[apikey](../README.md#apikey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **GetCustomSessions**
> Sessions GetCustomSessions(ctx, requestId)
Get Custom Sessions from a Deployment

Get Custom Sessions from a Deployment

### Required Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **ctx** | **context.Context** | context for authentication, logging, cancellation, deadlines, tracing, etc.
  **requestId** | **string**| Deployment Request ID | 

### Return type

[**Sessions**](Sessions.md)

### Authorization

[apikey](../README.md#apikey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **PatchCustomSession**
> SessionGet PatchCustomSession(ctx, customId, requestId, payload)
Update a Custom Session from a Deployment

Update a Custom Session from a Deployment

### Required Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **ctx** | **context.Context** | context for authentication, logging, cancellation, deadlines, tracing, etc.
  **customId** | **string**| Custom ID Managed by you | 
  **requestId** | **string**| Deployment Request ID | 
  **payload** | [**CustomSessionModel**](CustomSessionModel.md)|  | 

### Return type

[**SessionGet**](SessionGet.md)

### Authorization

[apikey](../README.md#apikey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **PostCustomSession**
> SessionRequest PostCustomSession(ctx, customId, requestId, payload)
Deploy a Custom Session to a Deployment

Deploy a Custom Session to a Deployment

### Required Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **ctx** | **context.Context** | context for authentication, logging, cancellation, deadlines, tracing, etc.
  **customId** | **string**| Custom ID Managed by you | 
  **requestId** | **string**| Deployment Request ID | 
  **payload** | [**CustomSessionModel**](CustomSessionModel.md)|  | 

### Return type

[**SessionRequest**](SessionRequest.md)

### Authorization

[apikey](../README.md#apikey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **PostCustomSessions**
> BulkSessionPost PostCustomSessions(ctx, requestId, payload)
Deploy Many Custom Sessions to a Deployment

Deploy Many Custom Sessions to a Deployment

### Required Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **ctx** | **context.Context** | context for authentication, logging, cancellation, deadlines, tracing, etc.
  **requestId** | **string**| Deployment Request ID | 
  **payload** | [**CustomBulkSessionsModel**](CustomBulkSessionsModel.md)|  | 

### Return type

[**BulkSessionPost**](BulkSessionPost.md)

### Authorization

[apikey](../README.md#apikey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

