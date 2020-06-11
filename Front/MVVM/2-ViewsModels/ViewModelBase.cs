using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AppMobileJobChannel
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Implementation de l'Interface INotifyPropertyChanged
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        ///Méthode Protected Pour qu'elle soit utilisable et modifiable par les héritiés
        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            ///Envois un évènement qui dit qu'une propriétée a été modifiée
            ///le ? rend nullable >>> Pas d'exeption si PropertyChanged est nulll
            ///Appel le Invoke que si PropertyChanged n'est pas null
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

            /// Autre façon de l'écrire
            //if (PropertyChanged != null)
            //{
            //    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("propertyName"));
            //}
        }

        /// <summary>
        /// Méthode appelée à la fermeture de la View
        /// </summary>
        public virtual void Close() { }
    }
}
