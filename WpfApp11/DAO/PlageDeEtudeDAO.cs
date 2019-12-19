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
    public class PlageDeEtudeDAO
    {
        public int idEtudeDAO;
        public int idPlageDAO;

        public PlageDeEtudeDAO(int idEtude, int idPlage)
        {

            this.idEtudeDAO = idEtude;
            this.idPlageDAO = idPlage;

        }
        public static void insertPlageDeEtude(PlageDeEtudeDAO d)
        {
            PlageDeEtudeDAL.insertPlageDeEtude(d);
        }
    }
}
