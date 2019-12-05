using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ifrocean.Exeption
{
    class CoordonneInvalidExeption : Exception
    {
        public class CodePostalCommuneInvalideException : Exception
        {

            public CodePostalCommuneInvalideException()
            {

            }


            public CodePostalCommuneInvalideException(string message) : base(message)
            {

            }
        }
    }
}
