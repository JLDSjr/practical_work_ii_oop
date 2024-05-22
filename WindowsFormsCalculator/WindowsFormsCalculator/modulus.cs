using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsCalculator
{
    public class modulus : operation
    {
        public modulus(string name, string symbol) : base(name, symbol)
        {
        }

        public override result operate(int op1, int op2)
        {
            if (op2 == 0 || op2 == 1) return new integer_result(0);

            int dividend = Math.Abs(op1);
            int divisor = Math.Abs(op2);

            while (dividend >= divisor)
            {
                dividend -= divisor;
            }

            return new integer_result(dividend);
        }

        public override result operate(double op1, double op2)
        {
            return (null);
        }

    }
}
