using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedTests
{
    public class PagesException : Exception
    {
        public PagesException()
        {
        }

        public PagesException(string message)
            : base(message)
        {
        }

        public PagesException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
