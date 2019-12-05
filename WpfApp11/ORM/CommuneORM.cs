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
            CommuneViewModel p = new CommuneViewModel(pDAO.idCommuneDAO,pDAO.nomCommuneDAO, pDAO.codePostalDAO,pDAO.idDepartementCommuneDAO);
            return p;
        }

        public static ObservableCollection<CommuneViewModel> listeCommune()
        {
            ObservableCollection<CommuneDAO> lDAO = CommuneDAO.listeCommune();
            ObservableCollection<CommuneViewModel> l = new ObservableCollection<CommuneViewModel>();
            foreach (CommuneDAO element in lDAO)
            {
                CommuneViewModel p = new CommuneViewModel(element.idCommuneDAO,element.nomCommuneDAO, element.codePostalDAO,element.idDepartementCommuneDAO);
                l.Add(p);
            }
            return l;
        }
    }
}
