using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsCalculator
{
    public abstract class operation
    {
        protected string symbol;
        protected string name;

        public operation(string name, string symbol)
        {
            this.name = name;
            this.symbol = symbol;
        }

        public abstract result operate(int op1, int op2);
        public abstract result operate(double op1, double op2);

        public string GetName() { return this.name; }

        public string GetSymbol() { return this.symbol; }


    }
}
