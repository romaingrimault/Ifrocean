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
            EtudeViewModel p = new EtudeViewModel( pDAO.nomEtudeDAO);
            return p;
        }

        public static ObservableCollection<EtudeViewModel> listeEtude()
        {
            ObservableCollection<EtudeDAO> lDAO = EtudeDAO.listeEtude();
            ObservableCollection<EtudeViewModel> l = new ObservableCollection<EtudeViewModel>();
            foreach (EtudeDAO element in lDAO)
            {
                EtudeViewModel p = new EtudeViewModel(element.nomEtudeDAO);
                l.Add(p);
            }
            return l;
        }
    }
  }

