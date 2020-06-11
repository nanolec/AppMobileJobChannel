using System;
using System.Collections.Generic;

namespace BusinessObjects
{
    public class Offre
    {
        public string Nom { get; set; }
        public string Detail { get; set; }
        public string Region { get; set; }
        public string Contrat { get; set; }
        public string Poste { get; set; }
        public string DatePublication { get; set; }
        public string Lien { get; set; }

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
            int hashCode = -2113597398;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nom);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Detail);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Region);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Contrat);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Poste);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(DatePublication);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Lien);
            return hashCode;
        }
    }
}
