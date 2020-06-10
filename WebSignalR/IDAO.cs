using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSignalR
{
    public interface IDAO
    {
        List<Offre> GetOffres();
    }
}
