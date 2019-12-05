using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ifrocean
{
    public class DepartementViewModel  : INotifyPropertyChanged
    {
        private int idDepartement;
        private string nomDepartement;
        private string numeroDepartement;
       
        

        public DepartementViewModel() { }

        
        public DepartementViewModel(int iDDepartement, string nomDepartement, string numeroDepartement)
        {
            this.idDepartementProperty = iDDepartement;           
            this.nomDepartementProperty = nomDepartement;
            this.numeroDepartementProperty = numeroDepartement;
           
        }
        public int idDepartementProperty
        {
            get { return idDepartement; }
            set
            {
                this.idDepartement = value;
            }
        }

        public String nomDepartementProperty
        {
            get { return nomDepartement; }
            set
            {
                nomDepartement = value.ToString();
                OnPropertyChanged("nomDepartementProperty");
            }

        }
        public String numeroDepartementProperty
        {
            get { return numeroDepartement; }
            set
            {
                this.numeroDepartement = value.ToString();
                OnPropertyChanged("numeroDepartementProperty");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                DepartementDAO.updateDepartement(this);
            }
        }
    }
}

