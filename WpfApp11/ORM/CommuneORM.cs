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
    public class CommuneORM
    {
        public static CommuneViewModel getCommune(int idCommune)
        {
            CommuneDAO pDAO = CommuneDAO.getCommune(idCommune);
            int idDep = pDAO.idDepartementCommuneDAO;
            DepartementViewModel m = DepartementORM.getDepartement(idDep);
            CommuneViewModel p = new CommuneViewModel(pDAO.idCommuneDAO,pDAO.nomCommuneDAO, pDAO.codePostalDAO,m);
            return p;
        }

        public static ObservableCollection<CommuneViewModel> listeCommune()
        {
            ObservableCollection<CommuneDAO> lDAO = CommuneDAO.listeCommune();
            ObservableCollection<CommuneViewModel> l = new ObservableCollection<CommuneViewModel>();
            foreach (CommuneDAO element in lDAO)
            {
                int idDep = element.idDepartementCommuneDAO;
                DepartementViewModel m = DepartementORM.getDepartement(idDep);
                CommuneViewModel p = new CommuneViewModel(element.idCommuneDAO,element.nomCommuneDAO, element.codePostalDAO,m);
                l.Add(p);
            }
            return l;
        }
        public static ObservableCollection<CommuneViewModel> listeCommuneDepartement(DepartementViewModel departement)
        {
            ObservableCollection<CommuneDAO> lDAO = CommuneDAO.listeCommuneDepartement(departement.idDepartementProperty);
            ObservableCollection<CommuneViewModel> l = new ObservableCollection<CommuneViewModel>();
            foreach (CommuneDAO element in lDAO)
            {
                int idDep = element.idDepartementCommuneDAO;
                CommuneViewModel p = new CommuneViewModel(element.idCommuneDAO,element.nomCommuneDAO, element.codePostalDAO,departement);
                l.Add(p);
            }
            return l;
        }

        public static void updateCommune(CommuneViewModel d)
        {
            CommuneDAO.updateCommune(new CommuneDAO(d.idCommuneProperty, d.nomCommuneProperty, d.codePostalProperty, d.departementProperty.idDepartementProperty));
        }

        public static void supprimerCommune(int id)
        {
            CommuneDAO.supprimerCommune(id);
        }

        public static void insertCommune(CommuneViewModel d)
        {
            CommuneDAO.insertCommune(new CommuneDAO(d.idCommuneProperty, d.nomCommuneProperty, d.codePostalProperty, d.departementProperty.idDepartementProperty));
        }
    }
}
