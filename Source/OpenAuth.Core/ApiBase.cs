using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OpenAuth
{
    public abstract class ApiBase
    {
        public ApiBase(HttpClient apiInvoker)
        { 
            
        }

        public virtual void Execute()
        { 
            
        }
    }
}
