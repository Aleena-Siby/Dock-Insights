using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace backend.Services
{
    public interface IManagementService
    {
     Task<List<TopManagementProjects>> GetTopManagementProjects(); // Method to get top management projects
    }
}
