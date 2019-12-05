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
    public class PlageORM
    {
        public static PlageViewModel getPlage(int idPlage)
        {
            PlageDAO pDAO = PlageDAO.getPlage(idPlage);
            PlageViewModel p = new PlageViewModel(pDAO.idPlageDAO, pDAO.nomPlageDAO,pDAO.idCommunePlageDAO);
            return p;
        }

        public static ObservableCollection<PlageViewModel> listePlage()
        {
            ObservableCollection<PlageDAO> lDAO = PlageDAO.listePlage();
            ObservableCollection<PlageViewModel> l = new ObservableCollection<PlageViewModel>();
            foreach (PlageDAO element in lDAO)
            {
                PlageViewModel p = new PlageViewModel(element.idPlageDAO ,element.nomPlageDAO,element.idCommunePlageDAO);
                l.Add(p);
            }
            return l;
        }
    }
}
