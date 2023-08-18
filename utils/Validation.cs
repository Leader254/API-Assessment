using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Consume.utils
{
    public class Validation
    {
        public static bool Validate(List<string> inputs)
        {
            var valid = false;
            foreach (var input in inputs)
            {
                if (string.IsNullOrWhiteSpace(input))
                {
                    valid = false;
                    break;
                }
                else
                {
                    valid = true;
                }
            }
            return valid;
        }

    }
}