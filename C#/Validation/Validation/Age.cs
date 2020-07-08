using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation
{
    class Age : IValidation
    {
        private readonly string _s;

        public Age(string s)
        {
            this._s = s;
        }

        public void Validate()
        {
            Console.WriteLine("Age:" + _s);

            if (!ValidationTools.NullCheck(_s))
            {
                throw new Exception("Age:Nullエラー " + _s);
            }

            if (!ValidationTools.RequiredCheck(_s))
            {
                throw new Exception("Age:必須エラー " + _s);
            }

            if (!ValidationTools.DigitsCheck(_s, 3))
            {
                throw new Exception("Age:桁数エラー " + _s);
            }

        }
    }
}
