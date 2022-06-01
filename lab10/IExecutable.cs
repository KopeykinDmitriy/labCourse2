using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_10
{
    interface IExecutable
    {
        int Code { get; set; } 

        void Print(); 

        object ShallowCopy(); 
    }
}
