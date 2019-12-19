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
            int id = pDAO.idCommunePlageDAO;
            CommuneViewModel m = CommuneORM.getCommune(id);
            PlageViewModel p = new PlageViewModel(pDAO.idPlageDAO, pDAO.nomPlageDAO,m);
            return p;
        }

        public static ObservableCollection<PlageViewModel> listePlage()
        {
            ObservableCollection<PlageDAO> lDAO = PlageDAO.listePlage();
            ObservableCollection<PlageViewModel> l = new ObservableCollection<PlageViewModel>();
            foreach (PlageDAO element in lDAO)
            {
                int id = element.idCommunePlageDAO;
                CommuneViewModel m = CommuneORM.getCommune(id);
                PlageViewModel p = new PlageViewModel(element.idPlageDAO ,element.nomPlageDAO,m);
                l.Add(p);
            }
            return l;
        }
        public static ObservableCollection<PlageViewModel> listePlageParCommune(CommuneViewModel commune)
        {
            ObservableCollection<PlageDAO> lDAO = PlageDAO.listePlageParCommune(commune.idCommuneProperty);
            ObservableCollection<PlageViewModel> l = new ObservableCollection<PlageViewModel>();
            foreach (PlageDAO element in lDAO)
            {
                int id = element.idCommunePlageDAO;
                
                PlageViewModel p = new PlageViewModel(element.idPlageDAO ,element.nomPlageDAO,commune);
                l.Add(p);
            }
            return l;
        }
        public static void updatePlage(PlageViewModel d)
        {
            PlageDAO.updatePlage(new PlageDAO(d.idPlageProperty, d.nomPlageProperty, d.communeProperty.idCommuneProperty));
        }

        public static void supprimerPlage(int id)
        {
            PlageDAO.supprimerPlage(id);
        }

        public static void insertPlage(PlageViewModel d)
        {
            PlageDAO.insertPlage(new PlageDAO(d.idPlageProperty, d.nomPlageProperty, d.communeProperty.idCommuneProperty));
        }
    }
}
