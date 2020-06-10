using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSignalR
{
    public interface IHubData
    {
        Task HubConnectionsCount(int count);
    }
}
