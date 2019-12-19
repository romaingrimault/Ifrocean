using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
using System.Collections.ObjectModel;
using Ifrocean.Ctrl;
using Ifrocean.ORM;
using Ifrocean.Erreur;
using System.Text.RegularExpressions;
using Ifrocean.Exeption;

namespace Ifrocean
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// departement
        /// </summary>
        int selectDepartementId;
        DepartementViewModel myDataObject; // Objet de liaison
        ObservableCollection<DepartementViewModel> lp;
        /// <summary>
        /// commune
        /// </summary>
        PersonneViewModel myDataObject1; // Objet de liaison
        ObservableCollection<PersonneViewModel> lp1;
        /// <summary>
        /// etude
        /// </summary>
        EtudeViewModel myDataObject2; // Objet de liaison
        ObservableCollection<EtudeViewModel> lp2;
       
        /// <summary>
        /// animaux
        /// </summary>
        AnimauxViewModel myDataObject3; // Objet de liaison
        ObservableCollection<AnimauxViewModel> lp3;
        /// <summary>
        /// commune
        /// </summary>
        CommuneViewModel myDataObject4; // Objet de liaison
        ObservableCollection<CommuneViewModel> lp4;
        /// <summary>
        /// Plage
        /// </summary>
        PlageViewModel myDataObject5; // Objet de liaison
        ObservableCollection<PlageViewModel> lp5;
        PlageDeEtudeViewModel myDataObject6;

        ObservableCollection<PlageViewModel> PlageZone;
        ObservableCollection<CommuneViewModel> CommuneParDepartement;
        ObservableCollection<PlageViewModel> listePlageParCommune;

        ZoneEtudeViewModel myDataObject7; // Objet de liaison
        ObservableCollection<ZoneEtudeViewModel> lp7;

        public MainWindow()
        {
            InitializeComponent();
            DALConnection.OpenConnection();
           
            lp = DepartementORM.listeDepartement();
            lp1 = PersonenORM.listePersonne();
            lp2 = EtudeORM.listeEtude();
            lp3 = AnimauxORM.listeAnimaux();
            lp4 = CommuneORM.listeCommune();
            lp5 = PlageORM.listePlage();
            lp7 = ZoneEtudeORM.listeZoneEtude();

            
           
           

            //LIEN AVEC la VIEW
            listeDepartement.ItemsSource = lp;
            listeCommune.ItemsSource = lp4;
            listePlage.ItemsSource = PlageZone;
            listeEtude.ItemsSource = lp2;
           // listeDepartement2.ItemsSource = lp;
           // listeCommune2.ItemsSource = CommuneParDepartement;
            listePlage2.ItemsSource = lp5;
            // this.DataContext = lp; // bind de la liste avec la source, permettant le binding mais de façon globale sur toute la fenetre
        }

        private void nomPrenomButton_Click_1(object sender, EventArgs e)
        {
            myDataObject = new DepartementViewModel();
            myDataObject.numeroDepartementProperty = numeroDepartementTextBox.Text;
            myDataObject.nomDepartementProperty = nomDepartementTextBox.Text;
            DepartementViewModel nouveau = new DepartementViewModel(0, myDataObject.nomDepartementProperty, myDataObject.numeroDepartementProperty);
            lp.Add(nouveau);
            DepartementORM.insertDepartement(nouveau);
            lp = DepartementORM.listeDepartement();
            numeroDepartementTextBox.Text = string.Empty;
            nomDepartementTextBox.Text = string.Empty;
        }
        
        private void AjouterUser_Click_1(object sender, EventArgs e) {
            myDataObject1 = new PersonneViewModel();
            myDataObject1.nomPersonneProperty = nomUserTextBox.Text;
            myDataObject1.prenomPersonneProperty = prenomTextBox.Text;
            myDataObject1.mailPersonneProperty = mailTextBox.Text;
            myDataObject1.identifiantPersonneProperty = identifiantTextBox.Text;
            myDataObject1.mdpPersonneProperty = mdpTextBox.Password;
            if (adminOui.IsChecked ?? true)
                myDataObject1.adminPersonneProperty = 1;
            else
                myDataObject1.adminPersonneProperty = 0;
            PersonneViewModel nouveau = new PersonneViewModel(0,myDataObject1.nomPersonneProperty, myDataObject1.prenomPersonneProperty,myDataObject1.identifiantPersonneProperty,myDataObject1.mdpPersonneProperty,myDataObject1.mailPersonneProperty,myDataObject1.adminPersonneProperty);
            lp1.Add(nouveau);
            PersonenORM.insertPersonne(nouveau);
            lp1 = PersonenORM.listePersonne();
            nomUserTextBox.Text = string.Empty;
            prenomTextBox.Text = string.Empty;
            mailTextBox.Text = string.Empty;
            identifiantTextBox.Text = string.Empty;
            mdpTextBox.Password = string.Empty;
        }

        private void AjouterEtude_Click_1(object sender, EventArgs e) {
            myDataObject2 = new EtudeViewModel();
            myDataObject2.nomEtudeProperty = nomEtudeTextBox.Text;
            
            myDataObject6 = new PlageDeEtudeViewModel();
           
            EtudeViewModel nouveau = new EtudeViewModel(0,myDataObject2.nomEtudeProperty);
            lp2.Add(nouveau);
            EtudeORM.insertEtude(nouveau);
            lp2 = EtudeORM.listeEtude();
            EtudeViewModel newEtude=EtudeORM.listeEtude().Last();
            foreach (PlageViewModel plage in lp5)
            {
                if (plage.isChekedProperty)
                {
                    PlageDeEtudeViewModel ajoutNouveau = new PlageDeEtudeViewModel(newEtude, plage);
                    PlageDeEtudeORM.insertPlageDeEtude(ajoutNouveau);
                }
            }
            nomEtudeTextBox.Text = string.Empty;

        }
        private void AjouterAnimaux_Click_1(object sender, EventArgs e) {
            myDataObject3 = new AnimauxViewModel();
            myDataObject3.nomEspeceAnimauxProperty = nomEspeceTextBox.Text;

            AnimauxViewModel nouveau = new AnimauxViewModel(myDataObject3.nomEspeceAnimauxProperty);
            lp3.Add(nouveau);
            AnimauxORM.insertAnimaux(nouveau);
            lp3 = AnimauxORM.listeAnimaux();
            nomEspeceTextBox.Text = string.Empty;
        }
        private void AjoutCommune_Click_1(object sender, EventArgs e)
        {
            
            try
            {
                if( codePosatelDepartementTextBox.Text.Length > 5)
                    throw new CodePostalCommuneInvalideException("Code Postal trop long");
                if ( codePosatelDepartementTextBox.Text.Length < 5)
                    throw new CodePostalCommuneInvalideException("Code Postal trop court");
                if ( codePosatelDepartementTextBox.Text.Length == 0)
                    throw new CodePostalCommuneInvalideException("Code Postal requit");
                myDataObject4 = new CommuneViewModel();
                myDataObject4.nomCommuneProperty = nomCommuneTextBox.Text;
                myDataObject4.codePostalProperty = codePosatelDepartementTextBox.Text;
                DepartementViewModel departement = (DepartementViewModel)listeDepartement.SelectedItem;
                CommuneViewModel nouveau = new CommuneViewModel(0,myDataObject4.nomCommuneProperty, myDataObject4.codePostalProperty,departement);
                lp4.Add(nouveau);
                CommuneORM.insertCommune(nouveau);
                lp4 = CommuneORM.listeCommune();
                nomCommuneTextBox.Text = string.Empty;
                codePosatelDepartementTextBox.Text = string.Empty;
                listeDepartement.Items.Refresh();
            }
            catch ( CodePostalCommuneInvalideException exptcodepostal)
            {
                MessageBox.Show(exptcodepostal.Message);
            }

        }

        private void listeDepartement_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listeDepartement.SelectedIndex < lp.Count) && (listeDepartement.SelectedIndex >= 0))
            {
                selectDepartementId = (lp.ElementAt<DepartementViewModel>(listeDepartement.SelectedIndex)).idDepartementProperty;
            }
        }

        private void AjoutPlage_Click_1(object sender, EventArgs e)
        {
            myDataObject5 = new PlageViewModel();
            myDataObject5.nomPlageProperty = nomPlage.Text;
            var list = (CommuneViewModel)listeCommune.SelectedItem;
            PlageViewModel nouveau = new PlageViewModel(0, myDataObject5.nomPlageProperty, new CommuneViewModel(list.idCommuneProperty,"","",null));
            lp5.Add(nouveau);
            PlageORM.insertPlage(nouveau);
            lp5 = PlageORM.listePlage();
            nomPlage.Text = string.Empty;
            listeCommune.ItemsSource= null ;
        }
        private void AjoutZone_Click_1(object sender, EventArgs e)
        {
            try
            {
                Regex coordonne = new Regex( @"^[-+]?([1-8]?\d(\.\d+)?|90(\.0+)?),\s*[-+]?(180(\.0+)?|((1[0-7]\d)|([1-9]?\d))(\.\d+)?)$");
                if (!coordonne.Match(CoordonneATextBox.Text).Success)
                    throw new CoordonneInvalidExeption("Coordonnée A invalide");
                if (!coordonne.Match(CoordonneBTextBox.Text).Success)
                    throw new CoordonneInvalidExeption("Coordonnée B invalide");
                if (!coordonne.Match(CoordonneCTextBox.Text).Success)
                    throw new CoordonneInvalidExeption("Coordonnée C invalide"); 
                if (!coordonne.Match(CoordonneDTextBox.Text).Success)
                    throw new CoordonneInvalidExeption("Coordonnée D invalide");
                string pointA = coordonnee(CoordonneATextBox.Text);
                string pointB = coordonnee(CoordonneBTextBox.Text);
                string pointC = coordonnee(CoordonneCTextBox.Text);
                string pointD = coordonnee(CoordonneDTextBox.Text);

                myDataObject7 = new ZoneEtudeViewModel();
                EtudeViewModel etude= (EtudeViewModel)listeEtude.SelectedItem;
                PlageViewModel plage= (PlageViewModel)listePlage.SelectedItem;

                int idZone = ZoneEtudeORM.getMaxIdZone(etude,plage);
                idZone += 1;
                PersonneViewModel personne = new PersonneViewModel(2,"","","","","",0);

                ZoneEtudeViewModel nouveau = new ZoneEtudeViewModel(DateTime.Now,pointA,pointB,pointC,pointD,10,idZone,personne,etude,plage);
                lp7.Add(nouveau);
                ZoneEtudeORM.insertZoneEtude(nouveau);
                lp7 = ZoneEtudeORM.listeZoneEtude();

            }
            catch(CoordonneInvalidExeption coordExpte)
            {
                MessageBox.Show(coordExpte.Message);
            }
             CoordonneATextBox.Text=string.Empty;
             CoordonneBTextBox.Text=string.Empty;
             CoordonneCTextBox.Text=string.Empty;
             CoordonneDTextBox.Text=string.Empty;
             listeEtude.Items.Refresh();
             listePlage.Items.Refresh();
                }
        public string coordonnee(string valeur)
        {/*
            int index = CoordonneATextBox.Text.IndexOf(',');
            double Latitude = 0;
            if (index > 0)
            {
                string latitude = valeur.Substring(0, index);
                latitude = latitude.Replace('.', ',');
                Latitude = Convert.ToDouble(latitude);
            }
            double Longitude = 0;
            if (index > 0)
            {
                index += 1;
                string longitude = valeur.Substring(index);
                longitude = longitude.Replace('.', ',');
                Longitude = Convert.ToDouble(longitude);
            }
            Point point = new Point(Latitude, Longitude);*/
            int index = valeur.IndexOf(',');
            string modif = valeur.Replace('.', ',');
            modif = modif.Remove(index,1);
            modif = modif.Insert(index,".");
            return modif;
        }


        private void ListeEtude_Selected(object sender, RoutedEventArgs e)
        {
            PlageZone = new ObservableCollection<PlageViewModel>();
            PlageZone = EtudeORM.listeEtudePlage((EtudeViewModel)listeEtude.SelectedItem);
            listePlage.ItemsSource = PlageZone;
        }
       /* private void ListeCommune_SelectionChanged(object sender, RoutedEventArgs e)
        {
            CommuneParDepartement = new ObservableCollection<CommuneViewModel>();
            CommuneParDepartement = CommuneORM.listeCommuneDepartement((DepartementViewModel)listeDepartement2.SelectedItem);
            listeCommune2.ItemsSource = CommuneParDepartement;
            listePlage2.ItemsSource = null;
        }
        private void ListePlage_SelectionChanged(object sender, RoutedEventArgs e)
        {
            listePlageParCommune = new ObservableCollection<PlageViewModel>();
            listePlageParCommune = PlageORM.listePlageParCommune((CommuneViewModel)listeCommune2.SelectedItem);
            listePlage2.ItemsSource = listePlageParCommune;
        }*/

        private void Box_Checked(object sender, RoutedEventArgs e)
        {

        }

        /*
        private void DepartementCheck(object sender, SelectionChangedEventArgs e)
        {
            IdDep = idDepRadioButton;
        }*/
    }
}
