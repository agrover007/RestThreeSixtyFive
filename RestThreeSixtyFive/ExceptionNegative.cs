using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestThreeSixtyFive
{
    [Serializable]
    internal class ExceptionNegative : Exception
    {
        public ExceptionNegative(string msg)
            : base(msg)
        {
        }
    }

    [Serializable]
    internal class ExceptionMaxConstraint : Exception
    {
        public ExceptionMaxConstraint(string msg)
            : base(msg)
        {
        }
    }
}

