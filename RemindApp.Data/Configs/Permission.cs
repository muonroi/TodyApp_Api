namespace RemindApp.Data.Configs;

[Flags]
public enum Permission : long
{
    None = 0,
    Auth_CreateRole = 1L << 0,         // 1
    Auth_UpdateRole = 1L << 1,         // 2
    Auth_DeleteRole = 1L << 2,         // 4
    Auth_GetRoles = 1L << 3,           // 8
    Auth_GetRoleById = 1L << 4,        // 16
    Auth_AssignPermission = 1L << 5,   // 32
    Auth_GetPermissions = 1L << 6,     // 64
    Auth_GetRolePermissions = 1L << 7, // 128
    Auth_GetRoleUsers = 1L << 8,       // 256
    Auth_AssignRoleUser = 1L << 11,    // 2048
    Auth_RemovePermissionFromRole = 1L << 12, // 4096
    Auth_All = Auth_CreateRole | Auth_UpdateRole | Auth_DeleteRole | Auth_GetRoles | Auth_GetRoleById |
           Auth_AssignPermission | Auth_GetPermissions | Auth_GetRolePermissions | Auth_GetRoleUsers |
           Auth_AssignRoleUser | Auth_RemovePermissionFromRole,
}
