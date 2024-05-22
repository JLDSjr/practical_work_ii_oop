using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsCalculator
{
    internal class calculator
    {

        private List<operation> operations;

        public calculator()
        {
            this.operations = new List<operation>();

            this.operations.Add(new add("Add", "+"));
            this.operations.Add(new subtract("Substract", "-"));
            this.operations.Add(new multiply("Multiply", "*"));
            this.operations.Add(new divide("Divide", "/"));
            this.operations.Add(new pow("Pow", "^"));
            this.operations.Add(new modulus("Modulus", "%"));
        }

        public int Exit() { return this.operations.Count + 1; }


        private string FixOperand(string operand)
        {
            CultureInfo currentCulture = CultureInfo.CurrentCulture;

            if (currentCulture.TwoLetterISOLanguageName == "es")
            {
                operand = operand.Replace(".", ",");
            }
            else
            {
                operand = operand.Replace(",", ".");
            }

            return operand;
        }

        private Boolean IsDecimalOperation(string op1, string op2)
        {
            bool DecimalOp = false;

            if (op1.Contains(',') || op2.Contains(',')) DecimalOp = true;

            return DecimalOp;
        }

        public string Perform_operation(int op, string op1, string op2)
        {
            try
            {
                result result = null;

                op1 = FixOperand(op1);
                op2 = FixOperand(op2);

                if (IsDecimalOperation(op1, op2))
                {
                    result = this.operations[op - 1].operate(Double.Parse(op1), Double.Parse(op2));
                }
                else
                {
                    result = this.operations[op - 1].operate(Int32.Parse(op1), Int32.Parse(op2));
                }
                if (result != null)
                {
                    return result.GetValue().ToString();
                }
                else
                    MessageBox.Show("This operation cannot be performed.");
            }
            catch (FormatException)
            {
                MessageBox.Show("This operation cannot be performed.");
            }
            return (null);
        }


        public string Perform_operation(string operation)
        {
            string[] components = operation.Split(' ');
            if (components.Count() != 3)
                MessageBox.Show("Invalid operation");
            else
            {
                try
                {
                    int op = this.GetOperatoinBySign(components[1]);

                    if (op != 0)
                    {
                        return (this.Perform_operation(op, components[0], components[2]));
                    }
                }
                catch (Exception) { MessageBox.Show("This operation cannot be performed."); }
            }
            return (null);
        }

        private int GetOperatoinBySign(string sign)
        {
            for (int i = 0; i < this.operations.Count; i++)
            {
                if (sign == this.operations[i].GetSymbol()) 
                    return i + 1;
            }
            return (0);
        }

    }
}
