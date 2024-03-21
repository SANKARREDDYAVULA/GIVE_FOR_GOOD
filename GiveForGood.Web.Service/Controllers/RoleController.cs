using GiveForGood.Web.Service.Interfaces;
using GiveForGood.Web.Service.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GiveForGood.Web.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService roleService;
        public RoleController(IRoleService _roleService)
        {
            this.roleService = _roleService;
        }

        [HttpGet]
        [Route("GetAllRoles")]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = await roleService.GetAllRoles();
            return Ok(roles);
        }

        [HttpPost]
        [Route("AddRole")]
        public async Task<IActionResult> AddRole(Role role)
        {
            var responce = await roleService.AddRole(role);
            return Ok(responce);
        }

        [HttpPut]
        [Route("UpdateRole")]
        public async Task<IActionResult> UpdateRole(long roleId,Role role)
        {
            var responce = await roleService.UpdateRole(roleId, role);
            return Ok(responce);
        }

        [HttpDelete]
        [Route("DeleteRole")]
        public async Task<IActionResult> DeleteRole(long roleId)
        {
            var responce = await roleService.DeleteRole(roleId);
            return Ok(responce);
        }

        [HttpGet]
        [Route("GetRoleById")]
        public async Task<IActionResult> GetRoleById(long roleId)
        {
            var role = await roleService.GetRoleById(roleId);
            return Ok(role);
        }
    }
}
