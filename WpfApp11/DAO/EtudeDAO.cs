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
    public class EtudeDAO
    {
        public int idEtudeDAO;
        public string nomEtudeDAO;

        public EtudeDAO(int newId,string newNomEtude)
        {
            this.idEtudeDAO = newId;
            this.nomEtudeDAO = newNomEtude;

        }
        public static ObservableCollection<EtudeDAO> listeEtude()
        {
            ObservableCollection<EtudeDAO> l = EtudeDAL.selectEtude();
            return l;
        }

        public static EtudeDAO getEtude(int idEtude)
        {
            EtudeDAO p = EtudeDAL.getEtude(idEtude);
            return p;
        }

        public static void updateEtude(EtudeDAO d)
        {
            EtudeDAL.updateEtude(d);
        }

        public static void supprimerEtude(int id)
        {
            EtudeDAL.supprimerEtude(id);
        }

        public static void insertEtude(EtudeDAO d)
        {
            EtudeDAL.insertEtude(d);
        }
    }
}
