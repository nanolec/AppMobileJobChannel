using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static WebSignalR.DAO;

namespace WebSignalR.Configuration
{
    public class ConfigDAL
    {
        /// <summary>
        /// Mangager SQL
        /// </summary>
        public static ISQLManager sQLManager = SQLServerManager.GetInstance();

        /* List of DAO
         * 
         * public static IMyDAO myDAO = MyDAOImplementation.GetInstance();
         *
         */

        public static OffreDAO offreDAO = new OffreDAO(sQLManager);

        public static IContratDAO contratDAO = new ContratDAO(sQLManager);

        public static IPosteDAO posteDAO = new PosteDAO(sQLManager);

        public static IRegionDAO regionDAO = new RegionDAO(sQLManager);


        /*
        End List of DAO */
    }
}
