/*
 * Codema
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * API version: 1.41.174.post.dev2
 * Generated by: Swagger Codegen (https://github.com/swagger-api/swagger-codegen.git)
 */

package swagger

type ContainerLogStorageModel struct {
	// Will override the app version container log storage for this deployment
	Enabled bool `json:"enabled"`
	// The name of your endpoint storage. If container log storage is enabled without this parameter, we will try to take the app version endpoint storage. If there is no endpoint storage in your app version, the container logs will not be stored. If we don't find any endpoint storage associated with this name, the container logs will not be stored.
	EndpointStorage string `json:"endpoint_storage,omitempty"`
}
