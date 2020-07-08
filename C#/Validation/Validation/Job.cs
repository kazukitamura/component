using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation
{
    class Job : IValidation
    {
        private readonly string _s;

        public Job(string s)
        {
            this._s = s;
        }

        public void Validate()
        {
            Console.WriteLine("Job:" + _s);

            if (!ValidationTools.NullCheck(_s))
            {
                throw new Exception("Job:Nullエラー " + _s);
            }

            if (!ValidationTools.RequiredCheck(_s))
            {
                throw new Exception("Job:必須エラー " + _s);
            }

            if (!ValidationTools.DigitsCheck(_s, 5))
            {
                throw new Exception("Job:桁数エラー " + _s);
            }

        }
    }
}
