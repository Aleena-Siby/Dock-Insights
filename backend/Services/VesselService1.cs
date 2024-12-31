using backend.Data;
using backend.Models;

using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class VesselService: IVesselService
    {
    private readonly AppDbContext _context;

    public VesselService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<VesselStatusData> GetVesselCounts()
    {
        var activeCount = await _context.Vessels.CountAsync(v => v.Status == 1); // Assuming 1 = Active
        var inactiveCount = await _context.Vessels.CountAsync(v => v.Status == 0); // Assuming 0 = Inactive

        return new VesselStatusData
        {
            ActiveVessels = activeCount,
            InactiveVessels = inactiveCount
        };
    }
        };
    }


public class VesselStatusData
{
    public int ActiveVessels { get; set; }
    public int InactiveVessels { get; set; }
}
