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
    public class PlageViewModel : INotifyPropertyChanged
    {
        private int idPlage;
        private string nomPlage;
        private CommuneViewModel commune;
        private Boolean IsChecked = false;



        public PlageViewModel() { }

        public PlageViewModel(int idPlage,string nomPlage,CommuneViewModel commune)
        {
            this.idPlageProperty = idPlage;
            this.nomPlageProperty = nomPlage;
            this.communeProperty = commune;

        }
        public int idPlageProperty
        {
            get { return idPlage; }
            set
            {
                idPlage = value;
            }
        }

        public String nomPlageProperty
        {
            get { return nomPlage; }
            set
            {
                nomPlage = value;
                OnPropertyChanged("nomPlageProperty");
            }

        }
        public CommuneViewModel communeProperty
        {
            get { return commune; }
            set
            {
                this.commune = value;
                OnPropertyChanged("idDepartementPlageProperty");
            }
        }
        public Boolean isChekedProperty
        {
            get { return IsChecked; }
            set
            {
                this.IsChecked = value;
                
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                PlageORM.updatePlage(this);
            }
        }

        
    }
}
