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
            PersonneViewModel p = new PersonneViewModel( pDAO.nomPersonneDAO, pDAO.prenomPersonneDAO, pDAO.identifiantPersonneDAO, pDAO.mdpPersonneDAO, pDAO.mailPersonneDAO, pDAO.adminPersonneDAO);
            return p;
        }

        public static ObservableCollection<PersonneViewModel> listePersonne()
        {
            ObservableCollection<PersonneDAO> lDAO = PersonneDAO.listePersonne();
            ObservableCollection<PersonneViewModel> l = new ObservableCollection<PersonneViewModel>();
            foreach (PersonneDAO element in lDAO)
            {
                PersonneViewModel p = new PersonneViewModel(element.nomPersonneDAO, element.prenomPersonneDAO, element.identifiantPersonneDAO, element.mdpPersonneDAO, element.mailPersonneDAO, element.adminPersonneDAO);
                l.Add(p);
            }
            return l;
        }
    }
  }

