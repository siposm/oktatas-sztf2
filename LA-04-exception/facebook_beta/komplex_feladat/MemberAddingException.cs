using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace komplex_feladat
{
    class MemberAddingException : Exception
    {
        string exceptionMessage;

        public string ExceptionMessage
        {
            get { return exceptionMessage; }
        }

        public MemberAddingException(string msg)
        {
            this.exceptionMessage = msg;
        }
    }
}
