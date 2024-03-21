using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Andrusenko_WPF_3.Tools.Exceptions
{
    public class DateIsInFutureException : Exception
    {
        public DateIsInFutureException()
        {
        }

        public DateIsInFutureException(string message)
            : base(message)
        {
        }

        public DateIsInFutureException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
