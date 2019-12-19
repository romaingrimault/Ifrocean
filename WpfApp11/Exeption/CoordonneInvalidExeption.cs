using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ifrocean.Exeption
{

        public class CoordonneInvalidExeption : Exception
        {

            public CoordonneInvalidExeption()
            {

            }


            public CoordonneInvalidExeption(string message) : base(message)
            {

            }
        }
}
