namespace Afonsoft.Portal.Services.Permission
{
    public interface IPermissionService
    {
        bool HasPermission(string key);
    }
}