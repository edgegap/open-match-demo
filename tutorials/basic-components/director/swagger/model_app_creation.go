/*
 * Codema
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * API version: 1.41.174.post.dev2
 * Generated by: Swagger Codegen (https://github.com/swagger-api/swagger-codegen.git)
 */

package swagger

type AppCreation struct {
	// If the creation happened correctly
	Success bool `json:"success,omitempty"`
	Version *AppVersion `json:"version,omitempty"`
}
