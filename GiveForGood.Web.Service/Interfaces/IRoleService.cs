using GiveForGood.Web.Service.Models;

namespace GiveForGood.Web.Service.Interfaces
{
    public interface IRoleService
    {
        Task<List<Role>> GetAllRoles();
        Task<Role> GetRoleById(long id);
        Task<bool> AddRole(Role role);
        Task<bool> UpdateRole(long roleId,Role role);
        Task<bool> DeleteRole(long id);
    }
}
