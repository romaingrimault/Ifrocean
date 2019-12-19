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
    public class PlageDeEtudeORM
    {
        public static void insertPlageDeEtude(PlageDeEtudeViewModel d)
        {
            PlageDeEtudeDAO.insertPlageDeEtude(new PlageDeEtudeDAO(d.etudeProperty.idEtudeProperty,d.plageProperty.idPlageProperty));
        }
    }
}

