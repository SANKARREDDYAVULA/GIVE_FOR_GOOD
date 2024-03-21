using GiveForGood.Web.Service.DBConfiguration;
using GiveForGood.Web.Service.Interfaces;
using GiveForGood.Web.Service.Models;
using Microsoft.EntityFrameworkCore;

namespace GiveForGood.Web.Service.Repository
{
    public class RoleService : IRoleService
    {
        private readonly ApplicationDbContext dBcontext;
        public RoleService(ApplicationDbContext _dBcontext)
        {
            this.dBcontext = _dBcontext;
        }
        public async Task<bool> AddRole(Role role)
        {
            if (role != null)
                dBcontext.roles.Add(role);
            var response = await dBcontext.SaveChangesAsync();
            return response == 1 ? true : false;
        }

        public async Task<bool> DeleteRole(long id)
        {
            var role = await dBcontext.roles.FindAsync(id);
            if (role != null)
            {
                dBcontext.roles.Remove(role);
                var responce = await dBcontext.SaveChangesAsync();
                return responce == 1 ? true : false;
            }
            return false;
        }

        public async Task<List<Role>> GetAllRoles()
        {
            var roles = await dBcontext.roles.Where(x => x.IsActive).ToListAsync();
            return roles;
        }

        public async Task<Role> GetRoleById(long id)
        {
            var role = await dBcontext.roles.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (role == null)
                return new Role();
            return role;
        }

        public async Task<bool> UpdateRole(long roleId, Role _role)
        {
            var role = await dBcontext.roles.FindAsync(roleId);
            if (role != null)
            {
                role.Name = _role.Name;
                role.CreatedBy = _role.CreatedBy;
                role.CreatedOn = _role.CreatedOn;
                role.ModifiedBy = _role.ModifiedBy;
                role.ModifiedOn = _role.ModifiedOn;
                role.IsActive = _role.IsActive;
            }
            var responce = await dBcontext.SaveChangesAsync();
            return responce == 1 ? true : false;
        }
    }
}
