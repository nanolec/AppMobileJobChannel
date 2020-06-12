using System;
using System.Collections.Generic;
using System.Data;

namespace BusinessObjects
{
    public class Offre
    {
        //public string Nom { get; set; }
        //public string Detail { get; set; }
        //public string Region { get; set; }
        //public string Contrat { get; set; }
        //public string Poste { get; set; }
        //public string DatePublication { get; set; }
        //public string Lien { get; set; }

        /// <summary>
        /// Identifiant unique de l'Offre
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Identifiant unique du poste
        /// </summary>
        public Poste Poste { get; set; }

        /// <summary>
        /// Identifiant unique du contrat
        /// </summary>
        public Contrat Contrat { get; set; }

        /// <summary>
        /// Identifiant unique de la région de préférence
        /// </summary>
        public Region Region { get; set; }

        /// <summary>
        /// Titre de l'Offre
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// Description de l'Offre
        /// </summary>
        public string Detail { get; set; }

        /// <summary>
        /// Lien vers l'Offre
        /// </summary>
        public string Lien { get; set; }

        /// <summary>
        /// Date création de l'Offre
        /// </summary>
        public DateTime? DatePublication { get; set; }

        /// <summary>
        /// Modif date de l'Offre
        /// </summary>
        public DateTime? Modif { get; set; }

        public Offre() { }

        public Offre(int id, string nom, string detail, Poste poste, Contrat contrat, Region region, DateTime creation, string lien)
        {
            Id = id;
            Nom = nom;
            Detail = detail;
            Poste = poste;
            Contrat = contrat;
            Region = region;
            DatePublication = creation;
            Lien = lien;
        }

        public Offre(DataRow row, Poste poste, Contrat contrat, Region region)
        {
            DataColumnCollection columns = row.Table.Columns;

            this.Id = (columns.Contains("ID") && row["ID"] != DBNull.Value) ? (int?)row["ID"] : null;
            this.Poste = poste;
            this.Contrat = contrat;
            this.Region = region;
            this.Nom = (columns.Contains("TITRE") && row["TITRE"] != DBNull.Value) ? (string)row["TITRE"] : null;
            this.Detail = (columns.Contains("DESCRIPTION") && row["DESCRIPTION"] != DBNull.Value) ? (string)row["DESCRIPTION"] : null;
            this.Lien = (columns.Contains("LIEN") && row["LIEN"] != DBNull.Value) ? (string)row["LIEN"] : null;
            this.DatePublication = (columns.Contains("CREATION") && row["CREATION"] != DBNull.Value) ? (DateTime?)row["CREATION"] : null;
            this.Modif = (columns.Contains("MODIF") && row["MODIF"] != DBNull.Value) ? (DateTime?)row["MODIF"] : null;

        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Offre))
            {
                return false;
            }
            return obj is Offre offre &&
                   Nom == offre.Nom &&
                   Detail == offre.Detail &&
                   Region == offre.Region &&
                   Contrat == offre.Contrat &&
                   Poste == offre.Poste &&
                   DatePublication == offre.DatePublication &&
                   Lien == offre.Lien;
        }

        public override int GetHashCode()
        {
            int hashCode = 1601429354;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Poste>.Default.GetHashCode(Poste);
            hashCode = hashCode * -1521134295 + EqualityComparer<Contrat>.Default.GetHashCode(Contrat);
            hashCode = hashCode * -1521134295 + EqualityComparer<Region>.Default.GetHashCode(Region);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nom);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Detail);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Lien);
            hashCode = hashCode * -1521134295 + DatePublication.GetHashCode();
            hashCode = hashCode * -1521134295 + Modif.GetHashCode();
            return hashCode;
        }
    }
}
