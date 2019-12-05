using Ifrocean.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ifrocean.Ctrl
{
    public class PersonneViewModel : INotifyPropertyChanged
    {
        private int idPersonne;
        private string nomPersonne;
        private string prenomPersonne;
        private string identifiantPersonne;
        private string mdpPersonne;
        private string mailPersonne;
        private Byte adminPersonne;



        public PersonneViewModel() { }

        public PersonneViewModel(string nomPersonne, string prenomPersonne,string identifiantPersonne, string mdpPersonne,string mailPersonne, Byte adminPersonne)
        {

            this.nomPersonneProperty = nomPersonne;
            this.prenomPersonneProperty = prenomPersonne;
            this.identifiantPersonne = identifiantPersonne;
            this.mdpPersonneProperty = mdpPersonne;
            this.mailPersonne = mailPersonne;
            this.adminPersonne = adminPersonne;


        }
        public int idPersonneProperty
        {
            get { return idPersonne; }
        }

        public String nomPersonneProperty
        {
            get { return nomPersonne; }
            set
            {
                this.nomPersonne = value.ToString();
                OnPropertyChanged("nomPersonneProperty");
            }

        } public String prenomPersonneProperty
        {
            get { return prenomPersonne; }
            set
            {
                this.prenomPersonne = value.ToString();
                OnPropertyChanged("prenomPersooneProperty");
            }

        } public String identifiantPersonneProperty
        {
            get { return identifiantPersonne; }
            set
            {
                this.identifiantPersonne = value.ToString();
                OnPropertyChanged("identifiantPersonneProperty");
            }

        } public String mdpPersonneProperty
        {
            get { return mdpPersonne; }
            set
            {
                this.mdpPersonne = value.ToString();
                OnPropertyChanged("mdpPersonneProperty");
            }

        } public String mailPersonneProperty
        {
            get { return mailPersonne; }
            set
            {
                this.mailPersonne = value.ToString();
                OnPropertyChanged("mailPersonneProperty");
            }

        }
        public Byte adminPersonneProperty
        {
            get { return adminPersonne; }
            set
            {
                this.adminPersonne = value;
                OnPropertyChanged("adminPersonneProperty");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                PersonneDAO.updatePersonne(this);
            }
        }
    }
}

