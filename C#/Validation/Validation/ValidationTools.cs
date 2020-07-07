using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation
{
    static class ValidationTools
    {
        public static bool NullCheck(string s)
        {
            if (s == null)
            {
                Console.WriteLine("NullCheck:               [NG]");
                return false;

            }
            Console.WriteLine("NullCheck:               [OK]");
            return true;

        }
    }
}
