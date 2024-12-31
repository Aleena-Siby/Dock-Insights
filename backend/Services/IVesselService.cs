using System.Threading.Tasks;
using backend.Models;

namespace backend.Services
{
    public interface IVesselService
    {
        Task<VesselStatusData> GetVesselCounts();  // Method to get vessel counts based on status
    }
}
