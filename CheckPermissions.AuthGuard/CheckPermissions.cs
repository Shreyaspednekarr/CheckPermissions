namespace CheckPermissions.AuthGuard
{
    [AttributeUsage(AttributeTargets.Method)]
    public class CheckPermissions : Attribute
    {
        public string ApplicationName { get; }
        public string PermissionName { get; }

        public CheckPermissions(string applicationName, string permissionName)
        {
            ApplicationName = applicationName;
            PermissionName = permissionName;
        }
    }
}
