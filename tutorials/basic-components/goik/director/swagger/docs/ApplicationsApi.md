# \ApplicationsApi

All URIs are relative to *https://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**AppVersionDelete**](ApplicationsApi.md#AppVersionDelete) | **Delete** /v1/app/{app_name}/version/{version_name} | Allow to Delete a single App Version
[**AppVersionGet**](ApplicationsApi.md#AppVersionGet) | **Get** /v1/app/{app_name}/version/{version_name} | Allow to Read a single App Version
[**AppVersionPost**](ApplicationsApi.md#AppVersionPost) | **Post** /v1/app/{app_name}/version | Allow to Create a Version for an App
[**AppVersionWhitelistEntryDelete**](ApplicationsApi.md#AppVersionWhitelistEntryDelete) | **Delete** /v1/app/{app_name}/version/{version_name}/whitelist/{entry_id} | Delete the ACL whitelist entry for an app version
[**AppVersionWhitelistEntryGet**](ApplicationsApi.md#AppVersionWhitelistEntryGet) | **Get** /v1/app/{app_name}/version/{version_name}/whitelist/{entry_id} | Get the ACL whitelist entry for an app version
[**AppVersionWhitelistGet**](ApplicationsApi.md#AppVersionWhitelistGet) | **Get** /v1/app/{app_name}/version/{version_name}/whitelist | Get the ACL whitelist for an app version
[**AppVersionWhitelistPost**](ApplicationsApi.md#AppVersionWhitelistPost) | **Post** /v1/app/{app_name}/version/{version_name}/whitelist | Create an ACL whitelist entry for an app version
[**AppVersionsGet**](ApplicationsApi.md#AppVersionsGet) | **Get** /v1/app/{app_name}/versions | Allow to List all Versions of an App
[**AppVersionsPatch**](ApplicationsApi.md#AppVersionsPatch) | **Patch** /v1/app/{app_name}/version/{version_name} | Allow to Update a single App Version
[**ApplicationDelete**](ApplicationsApi.md#ApplicationDelete) | **Delete** /v1/app/{app_name} | Delete an application
[**ApplicationGet**](ApplicationsApi.md#ApplicationGet) | **Get** /v1/app/{app_name} | Get an application with its unique name
[**ApplicationPatch**](ApplicationsApi.md#ApplicationPatch) | **Patch** /v1/app/{app_name} | Update an application with new data
[**ApplicationPost**](ApplicationsApi.md#ApplicationPost) | **Post** /v1/app | Create a new application
[**ApplicationsGet**](ApplicationsApi.md#ApplicationsGet) | **Get** /v1/apps | Get all applications you owns


# **AppVersionDelete**
> AppCreation AppVersionDelete(ctx, appName, versionName)
Allow to Delete a single App Version

Delete App Version

### Required Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **ctx** | **context.Context** | context for authentication, logging, cancellation, deadlines, tracing, etc.
  **appName** | **string**| The Name of the App | 
  **versionName** | **string**| The Name of the Version | 

### Return type

[**AppCreation**](AppCreation.md)

### Authorization

[apikey](../README.md#apikey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **AppVersionGet**
> AppVersion AppVersionGet(ctx, appName, versionName)
Allow to Read a single App Version

Get App version

### Required Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **ctx** | **context.Context** | context for authentication, logging, cancellation, deadlines, tracing, etc.
  **appName** | **string**| The Name of the App | 
  **versionName** | **string**| The Name of the Version | 

### Return type

[**AppVersion**](AppVersion.md)

### Authorization

[apikey](../README.md#apikey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **AppVersionPost**
> AppCreation AppVersionPost(ctx, appName, payload)
Allow to Create a Version for an App

Create app version

### Required Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **ctx** | **context.Context** | context for authentication, logging, cancellation, deadlines, tracing, etc.
  **appName** | **string**| The Name of the App | 
  **payload** | [**AppVersion**](AppVersion.md)|  | 

### Return type

[**AppCreation**](AppCreation.md)

### Authorization

[apikey](../README.md#apikey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **AppVersionWhitelistEntryDelete**
> AppVersionWhitelistEntrySuccess AppVersionWhitelistEntryDelete(ctx, appName, versionName, entryId)
Delete the ACL whitelist entry for an app version

Get the ACL whitelist entry for an app version

### Required Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **ctx** | **context.Context** | context for authentication, logging, cancellation, deadlines, tracing, etc.
  **appName** | **string**| The Name of the App | 
  **versionName** | **string**| The Name of the App version | 
  **entryId** | **string**| The unique ID of the entry | 

### Return type

[**AppVersionWhitelistEntrySuccess**](AppVersionWhitelistEntrySuccess.md)

### Authorization

[apikey](../README.md#apikey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **AppVersionWhitelistEntryGet**
> AppVersionWhitelistEntry AppVersionWhitelistEntryGet(ctx, appName, versionName, entryId)
Get the ACL whitelist entry for an app version

Get the ACL whitelist entry for an app version

### Required Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **ctx** | **context.Context** | context for authentication, logging, cancellation, deadlines, tracing, etc.
  **appName** | **string**| The Name of the App | 
  **versionName** | **string**| The Name of the App version | 
  **entryId** | **string**| The unique ID of the entry | 

### Return type

[**AppVersionWhitelistEntry**](AppVersionWhitelistEntry.md)

### Authorization

[apikey](../README.md#apikey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **AppVersionWhitelistGet**
> AppVersionWhitelistResponse AppVersionWhitelistGet(ctx, appName, versionName)
Get the ACL whitelist for an app version

Get the ACL whitelist for an app version

### Required Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **ctx** | **context.Context** | context for authentication, logging, cancellation, deadlines, tracing, etc.
  **appName** | **string**| The Name of the App | 
  **versionName** | **string**| The Name of the App version | 

### Return type

[**AppVersionWhitelistResponse**](AppVersionWhitelistResponse.md)

### Authorization

[apikey](../README.md#apikey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **AppVersionWhitelistPost**
> AppVersionWhitelistEntrySuccess AppVersionWhitelistPost(ctx, appName, versionName, payload)
Create an ACL whitelist entry for an app version

Create an ACL whitelist entry for an app version

### Required Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **ctx** | **context.Context** | context for authentication, logging, cancellation, deadlines, tracing, etc.
  **appName** | **string**| The Name of the App | 
  **versionName** | **string**| The Name of the App version | 
  **payload** | [**AppVersionWhitelistEntryPayload**](AppVersionWhitelistEntryPayload.md)|  | 

### Return type

[**AppVersionWhitelistEntrySuccess**](AppVersionWhitelistEntrySuccess.md)

### Authorization

[apikey](../README.md#apikey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **AppVersionsGet**
> AppVersions AppVersionsGet(ctx, appName)
Allow to List all Versions of an App

Get all app version of app

### Required Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **ctx** | **context.Context** | context for authentication, logging, cancellation, deadlines, tracing, etc.
  **appName** | **string**| The Name of the App | 

### Return type

[**AppVersions**](AppVersions.md)

### Authorization

[apikey](../README.md#apikey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **AppVersionsPatch**
> AppCreation AppVersionsPatch(ctx, appName, versionName, payload)
Allow to Update a single App Version

Update App Version

### Required Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **ctx** | **context.Context** | context for authentication, logging, cancellation, deadlines, tracing, etc.
  **appName** | **string**| The Name of the App | 
  **versionName** | **string**| The Name of the Version | 
  **payload** | [**AppVersionUpdate**](AppVersionUpdate.md)|  | 

### Return type

[**AppCreation**](AppCreation.md)

### Authorization

[apikey](../README.md#apikey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **ApplicationDelete**
> ApplicationDelete(ctx, appName)
Delete an application

Delete an application from a client

### Required Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **ctx** | **context.Context** | context for authentication, logging, cancellation, deadlines, tracing, etc.
  **appName** | **string**|  | 

### Return type

 (empty response body)

### Authorization

[apikey](../README.md#apikey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **ApplicationGet**
> Application ApplicationGet(ctx, appName)
Get an application with its unique name

Gets application

### Required Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **ctx** | **context.Context** | context for authentication, logging, cancellation, deadlines, tracing, etc.
  **appName** | **string**|  | 

### Return type

[**Application**](Application.md)

### Authorization

[apikey](../README.md#apikey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **ApplicationPatch**
> Application ApplicationPatch(ctx, appName, payload)
Update an application with new data

Update an application from a client

### Required Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **ctx** | **context.Context** | context for authentication, logging, cancellation, deadlines, tracing, etc.
  **appName** | **string**|  | 
  **payload** | [**ApplicationPatch**](ApplicationPatch.md)|  | 

### Return type

[**Application**](Application.md)

### Authorization

[apikey](../README.md#apikey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **ApplicationPost**
> Application ApplicationPost(ctx, payload)
Create a new application

Create an application from a client

### Required Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **ctx** | **context.Context** | context for authentication, logging, cancellation, deadlines, tracing, etc.
  **payload** | [**ApplicationPost**](ApplicationPost.md)|  | 

### Return type

[**Application**](Application.md)

### Authorization

[apikey](../README.md#apikey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **ApplicationsGet**
> Applications ApplicationsGet(ctx, )
Get all applications you owns

Get applications list

### Required Parameters
This endpoint does not need any parameter.

### Return type

[**Applications**](Applications.md)

### Authorization

[apikey](../README.md#apikey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

