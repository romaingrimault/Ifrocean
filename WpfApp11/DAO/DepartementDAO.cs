using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ifrocean
{
    public class DepartementDAO
    {
        public int idDepartementDAO;
        public string nomDepartementDAO;
        public string numeroDepartementDAO;

        public DepartementDAO(int newID,string newNomDepartement, string newNumeroDepartement)
        {
            this.idDepartementDAO = newID;
            this.nomDepartementDAO = newNomDepartement;
            this.numeroDepartementDAO = newNumeroDepartement;
        }
        public static ObservableCollection<DepartementDAO> listeDepartement()
        {
            ObservableCollection<DepartementDAO> l = DalDepartement.selectDepartement();
            return l;
        }

        public static DepartementDAO getDepartement(int idDepartement)
        {
            DepartementDAO p = DalDepartement.getDepartement(idDepartement);
            return p;
        }

        public static void updateDepartement(DepartementViewModel d)
        {
            DalDepartement.updateDepartement(new DepartementDAO(d.idDepartementProperty, d.nomDepartementProperty, d.numeroDepartementProperty));
        }

        public static void supprimerDepartement(int id)
        {
            DalDepartement.supprimerDepartement(id);
        }

        public static void insertDepartement(DepartementViewModel d)
        {
            DalDepartement.insertDepartement(new DepartementDAO(d.idDepartementProperty, d.nomDepartementProperty, d.numeroDepartementProperty));
        }
    }

    
}
