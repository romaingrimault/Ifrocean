using Ifrocean.Ctrl;
using Ifrocean.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ifrocean.DAO
{
    public class PlageDAO
    {
        public int idCommunePlageDAO;
        public int idPlageDAO;
        public string nomPlageDAO;
        public PlageDAO(int idPlage,string newComPlage, int newIdDepartementPlage)
        {
            this.idPlageDAO = idPlage;
            this.nomPlageDAO = newComPlage;
            this.idCommunePlageDAO = newIdDepartementPlage;
        }
        public static ObservableCollection<PlageDAO> listePlage()
        {
            ObservableCollection<PlageDAO> l = PlageDAL.selectPlage();
            return l;
        }

        public static PlageDAO getPlage(int idPlage)
        {
            PlageDAO p = PlageDAL.getPlage(idPlage);
            return p;
        }

        public static void updatePlage(PlageViewModel d)
        {
            PlageDAL.updatePlage(new PlageDAO(d.idPlageProperty ,d.nomPlageProperty,d.idCommunePlageProperty)) ;
        }

        public static void supprimerPlage(int id)
        {
            PlageDAL.supprimerPlage(id);
        }

        public static void insertPlage(PlageViewModel d)
        {
            PlageDAL.insertPlage(new PlageDAO(d.idPlageProperty,d.nomPlageProperty, d.idCommunePlageProperty));
        }
    }
}
