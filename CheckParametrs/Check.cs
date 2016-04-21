using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckParametrs
{
    public abstract class Check
    {
        protected static void CheckRefOnNull(object obj)
        {
            if(ReferenceEquals(obj, null))
                throw new ArgumentNullException();
        }
    }
}
