using Ifrocean.Ctrl;
using Ifrocean.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ifrocean.DAO
{
    public class PersonneDAO
    {
        public int idPersonneDAO;
        public string nomPersonneDAO;
        public string prenomPersonneDAO;
        public string identifiantPersonneDAO;
        public string mdpPersonneDAO;
        public string mailPersonneDAO;
        public Byte adminPersonneDAO;
        public PersonneDAO(int newIdPersonne, string newNomPersonne, string newPrenomPersonne,string newIdentifiantPersonne,string newmdpPersonne,string newMail, Byte newAdmin)
        {
            this.idPersonneDAO = newIdPersonne;
            this.nomPersonneDAO = newNomPersonne;
            this.prenomPersonneDAO = newPrenomPersonne;
            this.identifiantPersonneDAO = newIdentifiantPersonne;
            this.mdpPersonneDAO = newmdpPersonne;
            this.mailPersonneDAO = newMail;
            this.adminPersonneDAO = newAdmin;
        }
        public static ObservableCollection<PersonneDAO> listePersonne()
        {
            ObservableCollection<PersonneDAO> l = PersonneDAL.selectPersonne();
            return l;
        }

        public static PersonneDAO getPersonne(int idPersonne)
        {
            PersonneDAO p = PersonneDAL.getPersonne(idPersonne);
            return p;
        }

        public static void updatePersonne(PersonneDAO d)
        {
            PersonneDAL.updatePersonne(d);
        }

        public static void supprimerPersonne(int id)
        {
            PersonneDAL.supprimerPersonne(id);
        }

        public static void insertPersonne(PersonneDAO d)
        {
            PersonneDAL.insertPersonne(d);
        }
    }
}
