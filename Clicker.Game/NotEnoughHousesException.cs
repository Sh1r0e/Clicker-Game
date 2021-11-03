using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clicker.Game
{
    public class NotEnoughHousesException : Exception
    {

        public NotEnoughHousesException()
        {

        }
        public NotEnoughHousesException(string message) : base(message)
        {

        }
        public NotEnoughHousesException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
