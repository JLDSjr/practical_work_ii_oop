using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsCalculator
{
    public class multiply : operation
    {
        public multiply(string name, string symbol) : base(name, symbol)
        {
        }

        public override result operate(int op1, int op2)
        {
            return new integer_result(op1 * op2);
        }
        public override result operate(double op1, double op2)
        {
            return new double_result(op1 * op2);
        }

    }
}
