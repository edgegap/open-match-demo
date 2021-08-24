/*
 * Codema
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * API version: 1.41.174.post.dev2
 * Generated by: Swagger Codegen (https://github.com/swagger-api/swagger-codegen.git)
 */

package swagger

type SessionGet struct {
	// Unique UUID
	SessionId string `json:"session_id"`
	// Custom ID if Available
	CustomId string `json:"custom_id"`
	// Current status of the session
	Status string `json:"status"`
	// If the session is linked to a ready deployment
	Ready bool `json:"ready"`
	// If the session is linked to a deployment
	Linked bool `json:"linked"`
	// Type of session created
	Kind string `json:"kind"`
	// Count of user this session currently have
	UserCount int32 `json:"user_count"`
	// App version linked to the session
	AppId int32 `json:"app_id"`
	// Session created at
	CreateTime string `json:"create_time"`
	// Elapsed time
	Elapsed int32 `json:"elapsed"`
	// Error Detail
	Error_ string `json:"error,omitempty"`
	// Users in the session
	SessionUsers []SessionUser `json:"session_users,omitempty"`
	// IPS in the session
	SessionIps []SessionUser `json:"session_ips,omitempty"`
	Deployment *Deployment `json:"deployment"`
}
