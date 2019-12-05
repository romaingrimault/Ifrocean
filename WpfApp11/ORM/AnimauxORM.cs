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
    public class AnimauxORM
    {
        public static AnimauxViewModel getAnimaux(int idAnimaux)
        {
            AnimauxDAO pDAO = AnimauxDAO.getAnimaux(idAnimaux);
            AnimauxViewModel p = new AnimauxViewModel( pDAO.nomAnimauxDAO);
            return p;
        }

        public static ObservableCollection<AnimauxViewModel> listeAnimaux()
        {
            ObservableCollection<AnimauxDAO> lDAO = AnimauxDAO.listeAnimaux();
            ObservableCollection<AnimauxViewModel> l = new ObservableCollection<AnimauxViewModel>();
            foreach (AnimauxDAO element in lDAO)
            {
                AnimauxViewModel p = new AnimauxViewModel(element.nomAnimauxDAO);
                l.Add(p);
            }
            return l;
        }
    }
  }

