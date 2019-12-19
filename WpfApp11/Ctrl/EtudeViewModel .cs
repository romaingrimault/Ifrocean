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
    public class EtudeViewModel : INotifyPropertyChanged
    {
        private int idEtude;
        private string nomEtude;

        public EtudeViewModel() { }

        public EtudeViewModel(int idEtude,string nomEtude)
        {
            this.idEtudeProperty = idEtude;
            this.nomEtudeProperty = nomEtude;

        }
        public int idEtudeProperty
        {
            get { return idEtude; }
            set
            {
                this.idEtude = value;
            }
        }

        public String nomEtudeProperty
        {
            get { return nomEtude; }
            set
            {
                this.nomEtude = value.ToString();
                OnPropertyChanged("nomEtudeProperty");
            }

        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                EtudeORM.updateEtude(this);
            }
        }
    }
}

