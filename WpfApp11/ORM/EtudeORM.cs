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
    public class EtudeORM
    {
        public static EtudeViewModel getEtude(int idEtude)
        {
            EtudeDAO pDAO = EtudeDAO.getEtude(idEtude);
            EtudeViewModel p = new EtudeViewModel(pDAO.idEtudeDAO, pDAO.nomEtudeDAO);
            return p;
        }

        public static ObservableCollection<EtudeViewModel> listeEtude()
        {
            ObservableCollection<EtudeDAO> lDAO = EtudeDAO.listeEtude();
            ObservableCollection<EtudeViewModel> l = new ObservableCollection<EtudeViewModel>();
            foreach (EtudeDAO element in lDAO)
            {
                EtudeViewModel p = new EtudeViewModel(element.idEtudeDAO,element.nomEtudeDAO);
                l.Add(p);
            }
            return l;
        }
        public static ObservableCollection<PlageViewModel> listeEtudePlage(EtudeViewModel etude)
        {
            ObservableCollection<PlageDAO> lDAO = PlageDAO.listeEtudePlage(etude.idEtudeProperty);
            ObservableCollection<PlageViewModel> l = new ObservableCollection<PlageViewModel>();
            foreach (PlageDAO element in lDAO)
            {
                int id = element.idCommunePlageDAO;
                CommuneViewModel m = CommuneORM.getCommune(id);
                PlageViewModel p = new PlageViewModel(element.idPlageDAO, element.nomPlageDAO, m);
                l.Add(p);
            }
            return l;
        }
        public static void updateEtude(EtudeViewModel d)
        {
            EtudeDAO.updateEtude(new EtudeDAO(d.idEtudeProperty,d.nomEtudeProperty));
        }

        public static void supprimerEtude(int id)
        {
            EtudeDAO.supprimerEtude(id);
        }

        public static void insertEtude(EtudeViewModel d)
        {
            EtudeDAO.insertEtude(new EtudeDAO(d.idEtudeProperty,d.nomEtudeProperty));
        }
    }
  }

