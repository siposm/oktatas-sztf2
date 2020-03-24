using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hashing
{
    class HashingException : Exception
    {
        public HashingException(string msg) : base(msg)
        {

        }
    }

    class NoSpaceHashingException : HashingException
    {
        public NoSpaceHashingException(string msg) : base(msg)
        {

        }
    }

    class NoSuchKeyHashingException : HashingException
    {
        public NoSuchKeyHashingException(string msg) : base(msg)
        {

        }
    }
}
