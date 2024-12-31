using backend.Data;
using backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly AppDbContext _context;

        public DashboardService(AppDbContext context)
        {
            _context = context;
        }


    public async Task<int> GetDistinctManagementsCountAsync()

{
    return await _context.VesselProjects
        .Select(vp => vp.ManagementName)
        .Distinct()
        .CountAsync();
}
 public async Task<IEnumerable<ProjectStageCount>> GetProjectCountByStageAsync()
    {
        // Example code to retrieve data
       return  await _context.VesselProjects
            .GroupBy(p => p.Stage)
            .Select(g => new ProjectStageCount
            {
                Stage = g.Key,
                ProjectCount = g.Count()
            })
            .ToListAsync();

       
    }

public async Task<IEnumerable<VesselTypeSummary>> GetVesselsCountByTypeAsync()
        {
            // Group vessels by type and count them
            return await _context.Vessels
                .GroupBy(v => v.VesselTypeName)
                .Select(g => new VesselTypeSummary
                {
                    VesselType = g.Key,
                    VesselCount = g.Count()//count of projects in each type
                })
                .ToListAsync();
        }

public async Task<IEnumerable<ProjectsByManagement>> GetProjectsByManagementAsync()
{
    return await _context.VesselProjects
        .GroupBy(p => p.ManagementName) // Group by ManagementName
        .Select(g => new ProjectsByManagement
        {
            ManagementName = g.Key, // ManagementName as the key for the group
            ProjectCount = g.Count() // Count of projects under each management
        })
        .ToListAsync();
}


       public async Task<IEnumerable<VesselsByManagement>> GetVesselsByManagementAsync()
{
    var data = await _context.VesselProjects
        .GroupBy(v => v.ManagementName)
        .Select(g => new VesselsByManagement
        {
            Management = g.Key,
            VesselCount = g.Count()
        })
        .ToListAsync();

    return data;
}
public async Task<int> GetDryDockDueCountAsync()
{
    // Check for vessels whose survey due date is less than or equal to today's date
    return await _context.DryDockDue
        .Where(v => v.SurveyDueDate <= DateTime.Now)
        .CountAsync();
}
 

       public async Task<IEnumerable<DryDockingTrend>> GetDryDockingTrendsAsync()
{
    var data = await _context.DryDockDue
        .Where(d => d.SurveyDueDate > DateTime.Now)  // You can adjust this condition based on your needs
        .GroupBy(d => d.SurveyDueDate.Year)  // Group by year (or month)
        .Select(g => new DryDockingTrend
        {
            Year = g.Key,  // Grouping by year
            VesselCount = g.Count()
        })
        .ToListAsync();

    return data;
}


}
}
public class VesselTypeSummary
{
    public string VesselType { get; set; }
    public int VesselCount { get; set; }
}
public class VesselsByManagement
{
    public string Management { get; set; }
    public int VesselCount { get; set; }
}
public class DryDockDueCount
{
    public int DryDockCount { get; set; }
}

public class DryDockingTrend
{
    public int Year { get; set; }
    public int VesselCount { get; set; }
}
public class ProjectsByManagement
{
    public string ManagementName { get; set; }
    public int ProjectCount { get; set; }
}
public class ProjectStageCount
{
    public string Stage { get; set; }  // The stage of the project, e.g., Plan, Specify, Tender, etc.
    public int ProjectCount { get; set; }     // The count of projects in that stage
}

public class PortCountryVesselCount
{
    public string PortOfRegistry { get; set; }
    public string Country { get; set; }
    public int VesselCount { get; set; }
}
