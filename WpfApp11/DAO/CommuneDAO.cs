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

        public static CommuneDAO getCommune(int idCommune)
        {
            CommuneDAO p = CommuneDAL.getCommune(idCommune);
            return p;
        }

        public static void updateCommune(CommuneViewModel d)
        {
            CommuneDAL.updateCommune(new CommuneDAO(d.idCommuneProperty ,d.nomCommuneProperty, d.codePostalProperty, d.idDepartementCommuneProperty)) ;
        }

        public static void supprimerCommune(int id)
        {
            CommuneDAL.supprimerCommune(id);
        }

        public static void insertCommune(CommuneViewModel d)
        {
            CommuneDAL.insertCommune(new CommuneDAO(d.idCommuneProperty, d.nomCommuneProperty, d.codePostalProperty, d.idDepartementCommuneProperty));
        }
    }
}
