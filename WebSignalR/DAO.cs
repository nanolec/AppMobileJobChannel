using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebSignalR
{
    public class DAO 
    {
        /// <summary>
        /// Représente le DAO qui gère la Table Offre de la base de données
        /// </summary>
        public class OffreDAO : DAO_BASE, IDAO
        {
            public OffreDAO(ISQLManager sQLManager) : base(sQLManager) { }

            /// <summary>
            /// Retourne toutes les Offres qui sont en base de données
            /// </summary>
            /// <returns>Liste des Offres</returns>
            public List<Offre> GetOffres()
            {
                List<Offre> offres = new List<Offre>();

                DataSet dataSet = SQLManager.ExcecuteQuery("SELECT * FROM OFFRE", new List<SqlParameter>());
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    Poste p = Configuration.ConfigDAL.posteDAO.FindPosteByID((int)row["POS_ID"]);
                    Contrat c = Configuration.ConfigDAL.contratDAO.FindContratByID((int)row["CON_ID"]);
                    Region r = Configuration.ConfigDAL.regionDAO.FindRegionByID((int)row["REG_ID"]);
                    Offre off = new Offre(row, p, c, r);
                    offres.Add(off);
                }
                return offres;
            }
        }
    }
}
