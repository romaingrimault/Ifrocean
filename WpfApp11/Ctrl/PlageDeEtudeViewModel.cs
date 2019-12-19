using Ifrocean.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ifrocean.Ctrl
{
    public class PlageDeEtudeViewModel
    {
        private EtudeViewModel etude;
        private PlageViewModel plage;

        public PlageDeEtudeViewModel() { }

        public PlageDeEtudeViewModel(EtudeViewModel etude, PlageViewModel plage)
        {

            this.etudeProperty = etude;
            this.plageProperty = plage;

        }
        public EtudeViewModel etudeProperty
        {
            get { return etude; }
            set
            {
                etude = value;
            }
        }
        public PlageViewModel plageProperty
        {
            get { return plage; }
            set
            {
                plage = value;
            }
        }
       
    }
}

