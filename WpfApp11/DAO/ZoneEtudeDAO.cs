using Ifrocean.Ctrl;
using Ifrocean.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Ifrocean.DAO
{
    public class ZoneEtudeDAO
    {
        public DateTime dateEtudeDAO;
        public string CoordonnéeADAO;
        public string CoordonnéeBDAO;
        public string CoordonnéeCDAO;
        public string CoordonnéeDDAO;
        public float superficieZoneEtudeDAO;
        public int idZoneEtudeDAO;
        public int idPersonneDAO;
        public int idEtudeDAO;
        public int idPlageDAO;
        public ZoneEtudeDAO(DateTime newdateEtude, string newCoordonnéeA, string newCoordonnéeB, string newCoordonnéeC, string newCoordonnéeD, float newsuperficieZoneEtude, int newidZoneEtude, int newidPersonne, int newidEtude, int newidPlage)
        {
            this.dateEtudeDAO = newdateEtude;
            this.CoordonnéeADAO = newCoordonnéeA;
            this.CoordonnéeBDAO = newCoordonnéeB;
            this.CoordonnéeCDAO = newCoordonnéeC;
            this.CoordonnéeDDAO = newCoordonnéeD;
            this.superficieZoneEtudeDAO = newsuperficieZoneEtude;
            this.idZoneEtudeDAO = newidZoneEtude;
            this.idPersonneDAO = newidPersonne;
            this.idEtudeDAO = newidEtude;
            this.idPlageDAO = newidPlage;
        }
        public static ObservableCollection<ZoneEtudeDAO> listeZoneEtude()
        {
            ObservableCollection<ZoneEtudeDAO> l = ZoneEtudeDAL.selectZoneEtude();
            return l;
        }

        public static ZoneEtudeDAO getZoneEtude(int idZoneEtude)
        {
            ZoneEtudeDAO p = ZoneEtudeDAL.getZoneEtude(idZoneEtude);
            return p;
        }
        public static void supprimerZoneEtude(int id)
        {
            ZoneEtudeDAL.supprimerZoneEtude(id);
        }

        public static void insertZoneEtude(ZoneEtudeDAO d)
        {
            ZoneEtudeDAL.insertZoneEtude(d);
        }
        public static int getMaxIdZone(int idEtude,int idPlage)
        {
            int maxIdZone=ZoneEtudeDAL.getMaxIdZone(idEtude, idPlage);
            return maxIdZone;
        }
    }
}
