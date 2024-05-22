using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsCalculator
{
    public class pow : operation
    {
        public pow(string name, string symbol) : base(name, symbol)
        {
        }
        public override result operate(int op1, int op2)
        {
            int result = op1;

            if (op2 == 0) return new integer_result(1);

            for (int i = 1; i < op2; i++)
            {
                result = result * op1;
            }

            return new integer_result(result);
        }
        public override result operate(double op1, double op2)
        {
            return (null);
        }
    }
}
