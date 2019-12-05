using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Linq;
using System.Windows.Media;
using System.Collections.ObjectModel;
using Ifrocean.Ctrl;
using Ifrocean.DAL;
using Ifrocean.DAO;
using Ifrocean.ORM;
using Ifrocean.Erreur;
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
        DalDepartement c = new DalDepartement();
        ObservableCollection<DepartementViewModel> lp;
        int compteur = 0;
        /// <summary>
        /// commune
        /// </summary>
        PersonneViewModel myDataObject1; // Objet de liaison
        PersonneDAL c1 = new PersonneDAL();
        ObservableCollection<PersonneViewModel> lp1;
        int compteur1 = 0;
        /// <summary>
        /// etude
        /// </summary>
        EtudeViewModel myDataObject2; // Objet de liaison
        EtudeDAL c2 = new EtudeDAL();
        ObservableCollection<EtudeViewModel> lp2;
        int compteur2 = 0;
        /// <summary>
        /// animaux
        /// </summary>
        AnimauxViewModel myDataObject3; // Objet de liaison
        AnimauxDAL c3 = new AnimauxDAL();
        ObservableCollection<AnimauxViewModel> lp3;
        int compteur3 = 0;
        /// <summary>
        /// commune
        /// </summary>
        CommuneViewModel myDataObject4; // Objet de liaison
        CommuneDAL c4 = new CommuneDAL();
        ObservableCollection<CommuneViewModel> lp4;
        int compteur4 = 0;
        PlageViewModel myDataObject5; // Objet de liaison
        PlageDAL c5 = new PlageDAL();
        ObservableCollection<PlageViewModel> lp5;
        int compteur5 = 0;

        public MainWindow()
        {
            InitializeComponent();

            lp = DepartementORM.listeDepartement();
            lp1 = PersonenORM.listePersonne();
            lp2 = EtudeORM.listeEtude();
            lp3 = AnimauxORM.listeAnimaux();
            lp4 = CommuneORM.listeCommune();
            lp5 = PlageORM.listePlage();
           

            //LIEN AVEC la VIEW
            listeDepartement.ItemsSource = lp;
            listeCommune.ItemsSource = lp4;
            listePlage.ItemsSource = lp5;
            // this.DataContext = lp; // bind de la liste avec la source, permettant le binding mais de façon globale sur toute la fenetre
        }

        private void nomPrenomButton_Click_1(object sender, EventArgs e)
        {
            myDataObject = new DepartementViewModel();
            myDataObject.numeroDepartementProperty = numeroDepartementTextBox.Text;
            myDataObject.nomDepartementProperty = nomDepartementTextBox.Text;
            DepartementViewModel nouveau = new DepartementViewModel(0, myDataObject.nomDepartementProperty, myDataObject.numeroDepartementProperty);
            lp.Add(nouveau);
            DepartementDAO.insertDepartement(nouveau);

            compteur = lp.Count();
            myDataObject = new DepartementViewModel(0, "", "");
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
            PersonneViewModel nouveau = new PersonneViewModel(myDataObject1.nomPersonneProperty, myDataObject1.prenomPersonneProperty,myDataObject1.identifiantPersonneProperty,myDataObject1.mdpPersonneProperty,myDataObject1.mailPersonneProperty,myDataObject1.adminPersonneProperty);
            lp1.Add(nouveau);
            PersonneDAO.insertPersonne(nouveau);

            compteur = lp1.Count();
            myDataObject1 = new PersonneViewModel("", "","","","",0) ;
            nomUserTextBox.Text = string.Empty;
            prenomTextBox.Text = string.Empty;
            mailTextBox.Text = string.Empty;
            identifiantTextBox.Text = string.Empty;
            mdpTextBox.Password = string.Empty;
        }
        private void AjouterEtude_Click_1(object sender, EventArgs e) {
            myDataObject2 = new EtudeViewModel();
            myDataObject2.nomEtudeProperty = nomEtudeTextBox.Text;

            EtudeViewModel nouveau = new EtudeViewModel(myDataObject2.nomEtudeProperty);
            lp2.Add(nouveau);
            EtudeDAO.insertEtude(nouveau);

            compteur = lp2.Count();
            myDataObject2 = new EtudeViewModel("") ;
            nomEtudeTextBox.Text = string.Empty;

        }
        private void AjouterAnimaux_Click_1(object sender, EventArgs e) {
            myDataObject3 = new AnimauxViewModel();
            myDataObject3.nomEspeceAnimauxProperty = nomEspeceTextBox.Text;

            AnimauxViewModel nouveau = new AnimauxViewModel(myDataObject3.nomEspeceAnimauxProperty);
            lp3.Add(nouveau);
            AnimauxDAO.insertAnimaux(nouveau);

            compteur = lp3.Count();
            myDataObject3 = new AnimauxViewModel("") ;
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
                var list = (DepartementViewModel)listeDepartement.SelectedItem;
                myDataObject4.idDepartementCommuneProperty = list.idDepartementProperty;
                CommuneViewModel nouveau = new CommuneViewModel(0,myDataObject4.nomCommuneProperty, myDataObject4.codePostalProperty, myDataObject4.idDepartementCommuneProperty);
                lp4.Add(nouveau);
                CommuneDAO.insertCommune(nouveau);
                compteur4 = lp4.Count();
                myDataObject4 = new CommuneViewModel (0, "", "",0);
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
            myDataObject5.idCommunePlageProperty = list.idCommuneProperty;
            PlageViewModel nouveau = new PlageViewModel(0, myDataObject5.nomPlageProperty, myDataObject5.idCommunePlageProperty);
            lp5.Add(nouveau);
            PlageDAO.insertPlage(nouveau);
            compteur4 = lp4.Count();
            myDataObject5 = new PlageViewModel(0, "", 0);
            nomPlage.Text = string.Empty;
            listeCommune.ItemsSource= null ;
        }
        private void AjoutZone_Click_1(object sender, EventArgs e)
        {
          /*  try
            {

                if (CoordonneATextBox.Text.<)
            }
            catch(CoordonneInvalidExeption coordExpte)
            {

            }*/

        }

        private void ListeCommune_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }



        /*
        private void DepartementCheck(object sender, SelectionChangedEventArgs e)
        {
            IdDep = idDepRadioButton;
        }*/
    }
}
