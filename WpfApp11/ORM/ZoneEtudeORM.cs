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
    public class ZoneEtudeORM
    {
        public static ZoneEtudeViewModel getZoneEtude(int idZoneEtude)
        {
            ZoneEtudeDAO pDAO = ZoneEtudeDAO.getZoneEtude(idZoneEtude);
            int idPersonne = pDAO.idPersonneDAO;
            PersonneViewModel personne = PersonenORM.getPersonne(2);
            int idEtude = pDAO.idEtudeDAO;
            EtudeViewModel etude = EtudeORM.getEtude(idEtude);
            int idPlage = pDAO.idPlageDAO;
            PlageViewModel plage = PlageORM.getPlage(idPlage);
            ZoneEtudeViewModel p = new ZoneEtudeViewModel(pDAO.dateEtudeDAO, pDAO.CoordonnéeADAO, pDAO.CoordonnéeBDAO, pDAO.CoordonnéeCDAO, pDAO.CoordonnéeDDAO, pDAO.superficieZoneEtudeDAO, pDAO.idZoneEtudeDAO,personne,etude,plage);
            return p;
        }

        public static ObservableCollection<ZoneEtudeViewModel> listeZoneEtude()
        {
            ObservableCollection<ZoneEtudeDAO> lDAO = ZoneEtudeDAO.listeZoneEtude();
            ObservableCollection<ZoneEtudeViewModel> l = new ObservableCollection<ZoneEtudeViewModel>();
            foreach (ZoneEtudeDAO element in lDAO)
            {
                int idPersonne = element.idPersonneDAO;
                PersonneViewModel personne = PersonenORM.getPersonne(2);
                int idEtude = element.idEtudeDAO;
                EtudeViewModel etude = EtudeORM.getEtude(idEtude);
                int idPlage = element.idPlageDAO;
                PlageViewModel plage = PlageORM.getPlage(idPlage);
                ZoneEtudeViewModel p = new ZoneEtudeViewModel(element.dateEtudeDAO, element.CoordonnéeADAO, element.CoordonnéeBDAO, element.CoordonnéeCDAO, element.CoordonnéeDDAO, element.superficieZoneEtudeDAO, element.idZoneEtudeDAO, personne, etude, plage);
                l.Add(p);
            }
            return l;
        }
        public static void updateZoneEtude(ZoneEtudeViewModel d)
        {
            //ZoneEtudeDAO.updateZoneEtude(new ZoneEtudeDAO(d.idZoneEtudeProperty, d.nomZoneEtudeProperty, d.communeProperty.idCommuneProperty));
        }

        public static void supprimerZoneEtude(int id)
        {
            ZoneEtudeDAO.supprimerZoneEtude(id);
        }

        public static void insertZoneEtude(ZoneEtudeViewModel d)
        {
            ZoneEtudeDAO.insertZoneEtude(new ZoneEtudeDAO(d.dateEtudeProperty, d.coordonneeAProperty, d.coordonneeBProperty, d.coordonneeCProperty, d.coordonneeDProperty,d.superficieEtudeProperty,d.idZoneEtudeProperty,d.personneProperty.idPersonneProperty,d.etudeProperty.idEtudeProperty,d.plageProperty.idPlageProperty));
        }
        public static int getMaxIdZone(EtudeViewModel etude,PlageViewModel plage)
        {
           int idMax= ZoneEtudeDAO.getMaxIdZone(etude.idEtudeProperty, plage.idPlageProperty);
            return idMax;
        }
    }
}
