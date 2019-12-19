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
    public class AnimauxDAO
    {
        public int idAnimauxDAO;
        public string nomAnimauxDAO;

        public AnimauxDAO(string newNomAnimaux)
        {

            this.nomAnimauxDAO = newNomAnimaux;

        }
        public static ObservableCollection<AnimauxDAO> listeAnimaux()
        {
            ObservableCollection<AnimauxDAO> l = AnimauxDAL.selectAnimaux();
            return l;
        }

        public static AnimauxDAO getAnimaux(int idAnimaux)
        {
            AnimauxDAO p = AnimauxDAL.getAnimaux(idAnimaux);
            return p;
        }

        public static void updateAnimaux(AnimauxDAO d)
        {
            AnimauxDAL.updateAnimaux(d);
        }

        public static void supprimerAnimaux(int id)
        {
            AnimauxDAL.supprimerAnimaux(id);
        }

        public static void insertAnimaux(AnimauxDAO d)
        {
            AnimauxDAL.insertAnimaux(d);
        }
    }
}
