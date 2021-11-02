using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clicker.Game
{
    public class ExceptionResource : Exception
    {
        public ExceptionResource()
        {

        }
        public ExceptionResource(string message) : base(message)
        {

        }
        public ExceptionResource(string message, Exception inner) : base(message, inner)
        {

        }


    }
}
