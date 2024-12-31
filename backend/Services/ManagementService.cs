using backend.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Services
{
    public class ManagementService:IManagementService
    {
        private readonly AppDbContext _context;

        public ManagementService(AppDbContext context)
        {
            _context = context;
            }
        
   /* public async Task<List<TopManagementProjects>> GetTopManagementProjects()
        {
            return await _context.Vessels
                .GroupBy(v => v.GroupOwnerName)  // Group by the GroupOwnerName (management)
                .Select(g => new TopManagementProjects
                {
                    Management = g.Key,  // Management (GroupOwnerName)
                    Count = g.Count()    // Count the number of vessels under this management
                })
                .OrderByDescending(m => m.Count)  // Sort by the count of vessels
                .Take(5)  // Limit to top 5 managements
                .ToListAsync();  // Executes the query asynchronously
        }  
    }*/
public async Task<List<TopManagementProjects>> GetTopManagementProjects()
{
    return await _context.Vessels
        .GroupBy(v => v.GroupOwnerName)
        .Select(g => new TopManagementProjects
        {
            Management = g.Key ?? "Unknown", // If GroupOwnerName is null, default to "Unknown"
            Count = g.Count()
        })
        .OrderByDescending(m => m.Count)
        .Take(5)
        .ToListAsync();
}

    }
    public class TopManagementProjects
    {
        public string Management { get; set; }
        public int Count { get; set; }
    }
    }
