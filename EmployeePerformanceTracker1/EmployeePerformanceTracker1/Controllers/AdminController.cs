using EmployeePerformanceTracker1.Models;
using EmployeePerformanceTracker1.Repository;
using EmployeePerformanceTracker1.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeePerformanceTracker1.Controllers
{
    /*
    [ApiController]
    [Route("api/[controller]/")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepository adminRepository;
        public AdminController(IAdminRepository adminRepository)
        {
            this.adminRepository = adminRepository;
        }

     
       

       

        [HttpPut]
        [Route("Update Admin")]
        public async Task<IActionResult> UpdateAsync(int AdminId, Models.Admin updateadmin)
        {
            var admin = new Models.Admin()
            {
                AdminId = updateadmin.AdminId,
                AdminName = updateadmin.AdminName,
                EmailId = updateadmin.EmailId,
                Password = updateadmin.Password,
                JobRole = updateadmin.JobRole
            };

            admin = await adminRepository.UpdateAsync(AdminId, admin);

            if (admin == null)
            {
                return NotFound();
            }

            return Ok(admin);
        }

      
    }
    */
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        public readonly AdminService _adminService;

        public AdminController(AdminService adminService)
        {
            _adminService = adminService;
        }

        #region update
        [HttpPut]
        public async Task<IActionResult> UpdateAdminRecord([FromBody] Admin admin)
        {
            try
            {
                await _adminService.UpdateAdminRecord(admin);
                return (Ok(admin));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

    }
}
