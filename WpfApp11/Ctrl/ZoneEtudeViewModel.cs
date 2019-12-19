using Ifrocean.DAO;
using Ifrocean.ORM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Ifrocean.Ctrl
{
    public class ZoneEtudeViewModel : INotifyPropertyChanged
    {
        private DateTime dateEtude;
        private string coordonneeA;
        private string coordonneeB;
        private string coordonneeC;
        private string coordonneeD;
        private float superficieEtude;
        private int idZoneEtude;
        private PersonneViewModel personne;
        private EtudeViewModel etude;
        private PlageViewModel plage;
       



        public ZoneEtudeViewModel() { }

        public ZoneEtudeViewModel(DateTime dateEtude, string coordonneeA, string coordonneeB, string coordonneeC, string coordonneeD, float superficieEtude, int idZoneEtude, PersonneViewModel personne, EtudeViewModel etude, PlageViewModel plage)
        {
            this.dateEtudeProperty = dateEtude;
            this.coordonneeAProperty = coordonneeA;
            this.coordonneeBProperty = coordonneeB;
            this.coordonneeCProperty = coordonneeC;
            this.coordonneeDProperty = coordonneeD;
            this.superficieEtudeProperty = superficieEtude;
            this.idZoneEtudeProperty = idZoneEtude;
            this.personneProperty = personne;
            this.etudeProperty = etude;
            this.plageProperty = plage;


        }
        public DateTime dateEtudeProperty
        {
            get { return dateEtude; }
            set
            {
                dateEtude = value;
            }
        }
        public string coordonneeAProperty
        {
            get { return coordonneeA; }
            set
            {
                coordonneeA = value;
            }
        }
        public string coordonneeBProperty
        {
            get { return coordonneeB; }
            set
            {
                coordonneeB = value;
            }
        }
        public string coordonneeCProperty
        {
            get { return coordonneeC; }
            set
            {
                coordonneeC = value;
            }
        }
        public string coordonneeDProperty
        {
            get { return coordonneeD; }
            set
            {
                coordonneeD = value;
            }
        }
        public float superficieEtudeProperty
        {
            get { return superficieEtude; }
            set
            {
                superficieEtude = value;
            }
        }

        public int idZoneEtudeProperty
        {
            get { return idZoneEtude; }
            set
            {
                idZoneEtude = value;
               
            }

        }
        public PersonneViewModel personneProperty
        {
            get { return personne; }
            set
            {
                this.personne = value;
               
            }
        }
        public EtudeViewModel etudeProperty
        {
            get { return etude; }
            set
            {
                this.etude = value;
               
            }
        }
        public PlageViewModel plageProperty
        {
            get { return plage; }
            set
            {
                this.plage = value;
                
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                ZoneEtudeORM.updateZoneEtude(this);
            }
        }

        
    }
}
