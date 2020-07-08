using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation
{
    class Validator
    {
        private readonly List<IValidation> validationList = new List<IValidation>();

        public List<IValidation> ValidationList
        {
            get
            {
                return validationList;
            }
        }

        public void Validate()
        {
            foreach(IValidation item in validationList)
            {
                item.Validate();
            }
        }

        public static Validator CreateValidator(MyData data)
        {
            Validator validator = new Validator();
            validator.ValidationList.Add(new Job(data.Job));
            validator.ValidationList.Add(new Age(data.Age));
            validator.ValidationList.Add(new Remarks(data.Remarks));

            return validator;
        }
    }
}
