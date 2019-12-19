using Ifrocean.Ctrl;
using Ifrocean.DAO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ifrocean.ORM
{
    class PersonenORM
    {
        public static PersonneViewModel getPersonne(int idPersonne)
        {
            PersonneDAO pDAO = PersonneDAO.getPersonne(idPersonne);
            PersonneViewModel p = new PersonneViewModel(pDAO.idPersonneDAO, pDAO.nomPersonneDAO, pDAO.prenomPersonneDAO, pDAO.identifiantPersonneDAO, pDAO.mdpPersonneDAO, pDAO.mailPersonneDAO, pDAO.adminPersonneDAO);
            return p;
        }

        public static ObservableCollection<PersonneViewModel> listePersonne()
        {
            ObservableCollection<PersonneDAO> lDAO = PersonneDAO.listePersonne();
            ObservableCollection<PersonneViewModel> l = new ObservableCollection<PersonneViewModel>();
            foreach (PersonneDAO element in lDAO)
            {
                PersonneViewModel p = new PersonneViewModel(element.idPersonneDAO, element.nomPersonneDAO, element.prenomPersonneDAO, element.identifiantPersonneDAO, element.mdpPersonneDAO, element.mailPersonneDAO, element.adminPersonneDAO);
                l.Add(p);
            }
            return l;
        }
        public static void updatePersonne(PersonneViewModel d)
        {
            PersonneDAO.updatePersonne(new PersonneDAO(d.idPersonneProperty,d.nomPersonneProperty, d.prenomPersonneProperty, d.identifiantPersonneProperty, d.mdpPersonneProperty, d.mailPersonneProperty, d.adminPersonneProperty));
        }

        public static void supprimerPersonne(int id)
        {
            PersonneDAO.supprimerPersonne(id);
        }

        public static void insertPersonne(PersonneViewModel d)
        {
            PersonneDAO.insertPersonne(new PersonneDAO(d.idPersonneProperty,d.nomPersonneProperty, d.prenomPersonneProperty, d.identifiantPersonneProperty, d.mdpPersonneProperty, d.mailPersonneProperty, d.adminPersonneProperty));
        }
    }
  }

