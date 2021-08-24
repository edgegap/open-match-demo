# \MetricsApi

All URIs are relative to *https://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**DeploymentMetricsGet**](MetricsApi.md#DeploymentMetricsGet) | **Get** /v1/metrics/deployment/{request_id} | Get the metrics for a specific deployment based on the start_time, end_time and steps


# **DeploymentMetricsGet**
> MetricsResponse DeploymentMetricsGet(ctx, requestId, optional)
Get the metrics for a specific deployment based on the start_time, end_time and steps

Get the metrics of a deployment.

### Required Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **ctx** | **context.Context** | context for authentication, logging, cancellation, deadlines, tracing, etc.
  **requestId** | **string**|  | 
 **optional** | ***MetricsApiDeploymentMetricsGetOpts** | optional parameters | nil if no parameters

### Optional Parameters
Optional parameters are passed through a pointer to a MetricsApiDeploymentMetricsGetOpts struct

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------

 **startTime** | **optional.String**| Starting time for the query. Default to deployment start time. Should match %Y-%m-%d %H:%M:%S    Example: 2021-07-10 00:00:00 | 
 **endTime** | **optional.String**| End time for the metrics. Default to now.Must be greater than start_time. Should match %Y-%m-%d %H:%M:%S    Example: 2021-07-19 00:00:00 | 
 **steps** | **optional.String**| Steps between each metrics.    Example: 30s, 1m, 5m 10m, 1h  | 

### Return type

[**MetricsResponse**](MetricsResponse.md)

### Authorization

[apikey](../README.md#apikey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

