using Ifrocean.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ifrocean.Ctrl
{
    public class AnimauxViewModel : INotifyPropertyChanged
    {
        private int idAnimaux;
        private string nomEspeceAnimaux;

        public AnimauxViewModel() { }

        public AnimauxViewModel(string nomAnimaux)
        {

            this.nomEspeceAnimaux = nomAnimaux;

        }
        public int idAnimauxProperty
        {
            get { return idAnimaux; }
        }

        public String nomEspeceAnimauxProperty
        {
            get { return nomEspeceAnimaux; }
            set
            {
                this.nomEspeceAnimaux = value.ToString();
                OnPropertyChanged("nomAnimauxProperty");
            }

        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                AnimauxDAO.updateAnimaux(this);
            }
        }
    }
}

