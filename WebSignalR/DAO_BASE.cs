using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSignalR
{
    public abstract class DAO_BASE
    {
        protected ISQLManager SQLManager;

        protected DAO_BASE(ISQLManager sQLManager)
        {
            SQLManager = sQLManager;
        }
    }
}
