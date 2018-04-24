using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _5092_1_HW
{
    class @try:getpayoff
    {
        public @try(Parameters GIP):base(GIP)
        {

        }

        public void multithread()
        {
            Thread t = new Thread(new ParameterizedThreadStart(getpaths1));


        }


    }
}
