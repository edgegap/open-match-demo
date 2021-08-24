# AppVersion

## Properties
Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Name** | **string** | The Version Name | [default to null]
**IsActive** | **bool** | If the Version is active currently in the system | [optional] [default to null]
**DockerRepository** | **string** | The Repository where the image is (i.e. &#39;harbor.edgegap.com&#39; or &#39;docker.io&#39;) | [default to null]
**DockerImage** | **string** | The name of your image (i.e. &#39;edgegap/demo&#39;) | [default to null]
**DockerTag** | **string** | The tag of your image (i.e. &#39;0.1.2&#39;) | [default to null]
**PrivateUsername** | **string** | The username to access the docker repository | [optional] [default to null]
**PrivateToken** | **string** | The Private Password or Token of the username (We recommend to use a token) | [optional] [default to null]
**ReqCpu** | **int32** | Units of vCPU needed (1024&#x3D; 1vcpu) | [default to null]
**ReqMemory** | **int32** | Units of memory in MB needed (1024 &#x3D; 1GB) | [default to null]
**ReqVideo** | **int32** | Units of GPU needed (1024&#x3D; 1 GPU) | [optional] [default to null]
**MaxDuration** | **int32** | The Max duration of the game in minute. 0 means forever. | [optional] [default to null]
**UseTelemetry** | **bool** | Allow to inject ASA Variables | [optional] [default to null]
**InjectContextEnv** | **bool** | Allow to inject Context Variables | [optional] [default to null]
**WhitelistingActive** | **bool** | ACL Protection is active | [optional] [default to null]
**ForceCache** | **bool** | Allow faster deployment by caching your container image in every Edge site | [optional] [default to null]
**CacheMinHour** | **int32** | Start of the preferred interval for caching your container | [optional] [default to null]
**CacheMaxHour** | **int32** | End of the preferred interval for caching your container | [optional] [default to null]
**TimeToDeploy** | **int32** | Estimated maximum time in seconds to deploy, after this time we will consider it not working and retry. | [optional] [default to null]
**SessionConfig** | [***AppVersionCreateSessionConfig**](AppVersionCreateSessionConfig.md) | Parameters defining the behavior of a session-based app version. If set, the app is considered to be session-based. | [optional] [default to null]
**Ports** | [**[]AppVersionPort**](AppVersionPort.md) |  | [optional] [default to null]
**Probe** | [***AppVersionProbe**](AppVersionProbe.md) |  | [optional] [default to null]
**Envs** | [**[]AppVersionEnv**](AppVersionEnv.md) |  | [optional] [default to null]

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)


