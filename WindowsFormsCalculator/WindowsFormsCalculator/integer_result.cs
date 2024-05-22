using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsCalculator
{
    public class integer_result : result
    {

        private int value;

        public integer_result(int value) { this.value = value; }
        public override object GetValue() { return this.value; }

    }
}
