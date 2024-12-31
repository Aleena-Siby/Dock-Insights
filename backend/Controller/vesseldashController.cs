using Microsoft.AspNetCore.Mvc;
using backend.Services;
using backend.Data;
using backend.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class vesseldashController : ControllerBase
    {   private readonly AppDbContext _context;
        private readonly IVesselService _vesselService;
        private readonly IManagementService _managementService;
        private readonly IDashboardService _dashboardService;
        

        // Constructor Injection for both services
        public vesseldashController( AppDbContext context,IVesselService vesselService, IManagementService managementService, IDashboardService dashboardService) 
        {   _context=context;
            _vesselService = vesselService;
            _managementService = managementService;
            _dashboardService = dashboardService;
        }

        [HttpGet("vessel-counts")]
        public async Task<ActionResult<VesselStatusData>> GetVesselCounts()
        {
            var vesselCounts = await _vesselService.GetVesselCounts();
            return Ok(vesselCounts);
        }

        [HttpGet("top-management-projects")]
        public async Task<ActionResult<List<TopManagementProjects>>> GetTopManagementProjects()
        {
            var projects = await _managementService.GetTopManagementProjects();
            return Ok(projects);
        }
 

[HttpGet("distinct-managements-count")]
public async Task<IActionResult> GetDistinctManagementsCountAsync()
{
    var distinctManagementsCount = await _dashboardService.GetDistinctManagementsCountAsync();
    return Ok(new { distinctManagements = distinctManagementsCount });
}


[HttpGet("vessels-due-dry-docking")]
public async Task<IActionResult> GetDryDockDueCountAsync()
{
    var vesselsDue = await _dashboardService.GetDryDockDueCountAsync();
    return Ok(new { vesselsDueForDryDocking = vesselsDue });
}
[HttpGet("projects-by-management")]
public async Task<IActionResult> GetProjectsByManagement()
{
    var projectsByManagement = await _dashboardService.GetProjectsByManagementAsync();
    return Ok(projectsByManagement);
}

[HttpGet("vessel-count-by-type")]
        public async Task<IActionResult> GetVesselsCountByTypeAsync()
        {
            var vesselTypeSummary = await _dashboardService.GetVesselsCountByTypeAsync();
            return Ok(vesselTypeSummary);
        }
   


    }
}