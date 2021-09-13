# \LocationsApi

All URIs are relative to *https://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**LocationsGet**](LocationsApi.md#LocationsGet) | **Get** /v1/locations | Get all Locations


# **LocationsGet**
> Locations LocationsGet(ctx, optional)
Get all Locations

Get Locations list, You can specify App and Version to filter Locations considering your App Requirements (cpu, memory)

### Required Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **ctx** | **context.Context** | context for authentication, logging, cancellation, deadlines, tracing, etc.
 **optional** | ***LocationsApiLocationsGetOpts** | optional parameters | nil if no parameters

### Optional Parameters
Optional parameters are passed through a pointer to a LocationsApiLocationsGetOpts struct

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **app** | **optional.String**| The App Name you want to filter with capacity | 
 **version** | **optional.String**| The Version Name you want to filter with capacity | 

### Return type

[**Locations**](Locations.md)

### Authorization

[apikey](../README.md#apikey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

