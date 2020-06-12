using BusinessObjects;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSignalR
{
    public interface IContratDAO
    {
        List<Contrat> findByType(string Type);
        Contrat FindContratByID(int ContratId);
        List<Contrat> GetAllContrats();
    }
}
