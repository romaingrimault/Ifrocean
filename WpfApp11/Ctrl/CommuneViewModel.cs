using Ifrocean.DAO;
using Ifrocean.ORM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ifrocean.Ctrl
{
    public class CommuneViewModel : INotifyPropertyChanged
    {
        private int idCommune;
        private string nomCommune;
        private string codePostal;
        private DepartementViewModel departement;



        public CommuneViewModel() { }

        public CommuneViewModel(int idCommune ,string nomCommune, string codePostal, DepartementViewModel departement)
        {
            this.idCommuneProperty = idCommune;
            this.nomCommuneProperty = nomCommune;
            this.codePostalProperty = codePostal;
            this.departementProperty = departement;

        }
        public int idCommuneProperty
        {
            get { return idCommune; }
            set
            {
                idCommune = value;
            }
        }

        public String nomCommuneProperty
        {
            get { return nomCommune; }
            set
            {
                nomCommune = value;
                OnPropertyChanged("nomCommuneProperty");
            }

        }
        public String codePostalProperty
        {
            get { return codePostal; }
            set
            {
                this.codePostal = value;
                OnPropertyChanged("codePostalProperty");
            }
        }
        public DepartementViewModel departementProperty
        {
            get { return departement; }
            set
            {
                this.departement = value;
                OnPropertyChanged("idDepartementCommuneProperty");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                CommuneORM.updateCommune(this);
            }
        }
    }
}
