using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsCalculator
{
    public class double_result: result
    {

        private double value;

        public double_result(double value) { this.value = value; }

        public override object GetValue() { return this.value; }

    }
}
