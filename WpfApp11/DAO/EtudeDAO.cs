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

        public EtudeDAO(string newNomEtude)
        {

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

        public static void updateEtude(EtudeViewModel d)
        {
            EtudeDAL.updateEtude(new EtudeDAO(d.nomEtudeProperty));
        }

        public static void supprimerEtude(int id)
        {
            EtudeDAL.supprimerEtude(id);
        }

        public static void insertEtude(EtudeViewModel d)
        {
            EtudeDAL.insertEtude(new EtudeDAO(d.nomEtudeProperty));
        }
    }
}
