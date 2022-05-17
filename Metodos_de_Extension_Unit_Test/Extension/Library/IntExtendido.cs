using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text;

namespace Library
{
    public static class IntExtendido
    {
        public static string FizzBuzz(this Int32 n)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                if(i % 3 == 0)
                {
                    sb.AppendLine("Fizz " + i);
                }
                if(i % 5 == 0)
                {
                    sb.AppendLine("Buzz " + i);
                }
                if(i % 3 == 0 && i % 5 == 0)
                {
                    sb.AppendLine("FizzBuzz " + i);
                }
            }

            return sb.ToString();
        }
    }
}
