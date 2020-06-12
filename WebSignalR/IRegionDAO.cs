using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSignalR
{
    public interface IRegionDAO
    {
        Region FindRegionByID(int RegionId);
        List<Region> GetAllRegions();
    }
}