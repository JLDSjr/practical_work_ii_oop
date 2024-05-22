using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsCalculator
{
    public class divide : operation
    {
        public divide(string name, string symbol) : base(name, symbol)
        {
        }
        public override result operate(int op1, int op2)
        {
            try
            {
                return new double_result(op1 / op2);
            }
            catch (DivideByZeroException)
            {
                return new integer_result(Int32.MaxValue);
            }
        }
        public override result operate(double op1, double op2)
        {
            if (op2 == 0)
                return new double_result(Double.MaxValue);
            else
                return new double_result(op1 / op2);
        }

    }
}
