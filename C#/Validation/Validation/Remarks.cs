using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation
{
    class Remarks : IValidation
    {
        private readonly string _s;

        public Remarks(string s)
        {
            this._s = s;
        }

        public void Validate()
        {
            Console.WriteLine("Remarks:" + _s);

            if (!ValidationTools.NullCheck(_s))
            {
                throw new Exception("Remarks:Nullエラー " + _s);
            }

            if (!ValidationTools.RequiredCheck(_s))
            {
                throw new Exception("Remarks:必須エラー " + _s);
            }

            if (!ValidationTools.DigitsCheck(_s, 3))
            {
                throw new Exception("Remarks:桁数エラー " + _s);
            }

        }
    }
}
