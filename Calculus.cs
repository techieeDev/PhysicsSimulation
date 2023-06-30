using static System.Math;

namespace Calculus
{
    public static partial class Derivation
    {
        public static DifferentiableBasic Differentiate(DifferentiableBasic df)
        {
            double new_coefficient = df.coefficient * df.variable_exponent;
            double new_variable_exponent = df.variable_exponent - 1;

            return DifferentiableBasic.Instantiate(new_coefficient, new_variable_exponent);
        }

        public class DifferentiableBasic : Differentiable
        {
            public double coefficient { get; private set; }
            public double variable_exponent { get; private set; }

            public static DifferentiableBasic Instantiate(double _coefficient, double _variable_exponent)
            {
                DifferentiableBasic df = new DifferentiableBasic();
                df.coefficient = _coefficient;
                df.variable_exponent = _variable_exponent;
                return df;
            }

            public override void DisplayForm()
            {
                Console.WriteLine(coefficient.ToString() + "x^" + variable_exponent.ToString());
            }
        }

    }

}