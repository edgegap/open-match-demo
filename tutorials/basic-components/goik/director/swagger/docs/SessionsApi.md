# \SessionsApi

All URIs are relative to *https://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**DeleteUsersSession**](SessionsApi.md#DeleteUsersSession) | **Delete** /v1/session/{session_id}/users | Delete Users from a Session
[**GetSession**](SessionsApi.md#GetSession) | **Get** /v1/session/{session_id} | Allow to get a specific session&#39;s information
[**GetUsersSession**](SessionsApi.md#GetUsersSession) | **Get** /v1/session/{session_id}/users | Get Users of a Specific Session
[**ListSessions**](SessionsApi.md#ListSessions) | **Get** /v1/sessions | Allow to get a list of sessions with basic information
[**PutUsersSession**](SessionsApi.md#PutUsersSession) | **Put** /v1/session/{session_id}/users | Add Users to a Specific Session
[**SessionDelete**](SessionsApi.md#SessionDelete) | **Delete** /v1/session/{session_id} | Allow to stop a session for the client
[**SessionPost**](SessionsApi.md#SessionPost) | **Post** /v1/session | Create a new Session with it&#39;s user


# **DeleteUsersSession**
> SessionUserContext DeleteUsersSession(ctx, sessionId, payload)
Delete Users from a Session

Remove Users from a Specific Session

### Required Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **ctx** | **context.Context** | context for authentication, logging, cancellation, deadlines, tracing, etc.
  **sessionId** | **string**|  | 
  **payload** | [**PatchSessionModel**](PatchSessionModel.md)|  | 

### Return type

[**SessionUserContext**](SessionUserContext.md)

### Authorization

[apikey](../README.md#apikey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **GetSession**
> SessionGet GetSession(ctx, sessionId)
Allow to get a specific session's information

Get a specific session

### Required Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **ctx** | **context.Context** | context for authentication, logging, cancellation, deadlines, tracing, etc.
  **sessionId** | **string**|  | 

### Return type

[**SessionGet**](SessionGet.md)

### Authorization

[apikey](../README.md#apikey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **GetUsersSession**
> SessionUserContext GetUsersSession(ctx, sessionId)
Get Users of a Specific Session

Get Users of a Specific Session

### Required Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **ctx** | **context.Context** | context for authentication, logging, cancellation, deadlines, tracing, etc.
  **sessionId** | **string**|  | 

### Return type

[**SessionUserContext**](SessionUserContext.md)

### Authorization

[apikey](../README.md#apikey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **ListSessions**
> Sessions ListSessions(ctx, )
Allow to get a list of sessions with basic information

Get All Sessions

### Required Parameters
This endpoint does not need any parameter.

### Return type

[**Sessions**](Sessions.md)

### Authorization

[apikey](../README.md#apikey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **PutUsersSession**
> SessionUserContext PutUsersSession(ctx, sessionId, payload)
Add Users to a Specific Session

Add Users to a Specific Session

### Required Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **ctx** | **context.Context** | context for authentication, logging, cancellation, deadlines, tracing, etc.
  **sessionId** | **string**|  | 
  **payload** | [**PatchSessionModel**](PatchSessionModel.md)|  | 

### Return type

[**SessionUserContext**](SessionUserContext.md)

### Authorization

[apikey](../README.md#apikey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **SessionDelete**
> Delete SessionDelete(ctx, sessionId)
Allow to stop a session for the client

Delete a session with it's users

### Required Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **ctx** | **context.Context** | context for authentication, logging, cancellation, deadlines, tracing, etc.
  **sessionId** | **string**|  | 

### Return type

[**Delete**](Delete.md)

### Authorization

[apikey](../README.md#apikey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **SessionPost**
> SessionRequest SessionPost(ctx, payload)
Create a new Session with it's user

Create a session with it's session users

### Required Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **ctx** | **context.Context** | context for authentication, logging, cancellation, deadlines, tracing, etc.
  **payload** | [**SessionModel**](SessionModel.md)|  | 

### Return type

[**SessionRequest**](SessionRequest.md)

### Authorization

[apikey](../README.md#apikey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

