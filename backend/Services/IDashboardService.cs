using backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend.Services
{
    public interface IDashboardService
    {

         
        Task<IEnumerable<VesselsByManagement>> GetVesselsByManagementAsync();
        Task<IEnumerable<DryDockingTrend>> GetDryDockingTrendsAsync();
         Task<IEnumerable<ProjectsByManagement>> GetProjectsByManagementAsync();
        Task<int> GetDryDockDueCountAsync();
       Task<int> GetDistinctManagementsCountAsync();
       Task<IEnumerable<VesselTypeSummary>> GetVesselsCountByTypeAsync();
      Task<IEnumerable<ProjectStageCount>> GetProjectCountByStageAsync();
      

       
    }
}
