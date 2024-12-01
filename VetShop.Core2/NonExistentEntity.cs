using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetShop.Core
{
    public class NonExistentEntity : Exception
    {
        public NonExistentEntity(string message)
            : base(message)
        {

        }
    }
}
