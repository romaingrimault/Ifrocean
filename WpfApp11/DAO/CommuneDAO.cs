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
    public class CommuneDAO
    {
        public int idDepartementCommuneDAO;
        public int idCommuneDAO;
        public string nomCommuneDAO;
        public string codePostalDAO;
        public CommuneDAO(int idCommune, string newComCommune, string newCodePostal, int newIdDepartementCommune)
        {
            this.idCommuneDAO = idCommune;
            this.nomCommuneDAO = newComCommune;
            this.codePostalDAO = newCodePostal;
            this.idDepartementCommuneDAO = newIdDepartementCommune;
        }
        public static ObservableCollection<CommuneDAO> listeCommune()
        {
            ObservableCollection<CommuneDAO> l = CommuneDAL.selectCommune();
            return l;
        }
        public static ObservableCollection<CommuneDAO> listeCommuneDepartement(int idDepartement)
        {
            ObservableCollection<CommuneDAO> l = CommuneDAL.selectCommuneDepartement(idDepartement);
            return l;
        }

        public static CommuneDAO getCommune(int idCommune)
        {
            CommuneDAO p = CommuneDAL.getCommune(idCommune);
            return p;
        }

        public static void updateCommune(CommuneDAO d)
        {
            CommuneDAL.updateCommune(d) ;
        }

        public static void supprimerCommune(int id)
        {
            CommuneDAL.supprimerCommune(id);
        }

        public static void insertCommune(CommuneDAO d)
        {
            CommuneDAL.insertCommune(d);
        }
    }
}
