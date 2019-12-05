using Ifrocean.DAO;
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
        private int idCommunetPlage;



        public PlageViewModel() { }

        public PlageViewModel(int idPlage,string nomPlage,int idCommunetPlage)
        {
            this.idPlageProperty = idPlage;
            this.nomPlageProperty = nomPlage;
            this.idCommunePlageProperty = idCommunetPlage;

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
        public Int32 idCommunePlageProperty
        {
            get { return idCommunetPlage; }
            set
            {
                this.idCommunetPlage = value;
                OnPropertyChanged("idDepartementPlageProperty");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                PlageDAO.updatePlage(this);
            }
        }
    }
}
