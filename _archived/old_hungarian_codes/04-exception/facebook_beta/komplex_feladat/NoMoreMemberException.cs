using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace komplex_feladat
{
    class NoMoreMemberException : Exception
    {
        string exceptionMessage;

        public string ExceptionMessage
        {
            get { return exceptionMessage; }
        }

        public NoMoreMemberException(string msg)
        {
            this.exceptionMessage = msg;
        }
    }
}
