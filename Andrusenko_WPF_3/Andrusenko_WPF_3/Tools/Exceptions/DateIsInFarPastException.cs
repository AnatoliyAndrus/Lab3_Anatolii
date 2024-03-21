using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Andrusenko_WPF_3.Tools.Exceptions
{
    public class DateIsInFarPastException: Exception
    {
        public DateIsInFarPastException()
        {
        }

        public DateIsInFarPastException(string message)
            : base(message)
        {
        }

        public DateIsInFarPastException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
