using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ifrocean
{
    public class DepartementORM
    {

        public static DepartementViewModel getDepartement(int idDepartement)
        {
            DepartementDAO pDAO = DepartementDAO.getDepartement(idDepartement);
            DepartementViewModel p = new DepartementViewModel(pDAO.idDepartementDAO, pDAO.nomDepartementDAO, pDAO.numeroDepartementDAO);
            return p;
        }

        public static ObservableCollection<DepartementViewModel> listeDepartement()
        {
            ObservableCollection<DepartementDAO> lDAO = DepartementDAO.listeDepartement();
            ObservableCollection<DepartementViewModel> l = new ObservableCollection<DepartementViewModel>();
            foreach (DepartementDAO element in lDAO)
            {
                DepartementViewModel p = new DepartementViewModel(element.idDepartementDAO, element.nomDepartementDAO, element.numeroDepartementDAO);
                l.Add(p);
            }
            return l;
        }
        public static void updateDepartement(DepartementViewModel d)
        {
            DepartementDAO.updateDepartement(new DepartementDAO(d.idDepartementProperty, d.nomDepartementProperty, d.numeroDepartementProperty));
        }

        public static void supprimerDepartement(int id)
        {
            DepartementDAO.supprimerDepartement(id);
        }

        public static void insertDepartement(DepartementViewModel d)
        {
            DepartementDAO.insertDepartement(new DepartementDAO(d.idDepartementProperty, d.nomDepartementProperty, d.numeroDepartementProperty));
        }
    }
    
}
