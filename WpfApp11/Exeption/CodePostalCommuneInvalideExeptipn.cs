using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Ifrocean.Erreur
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
