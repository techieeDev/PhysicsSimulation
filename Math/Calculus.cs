using static Calculus.Derivation;
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

    public static partial class IndefiniteIntegration
    {
        public static IntegrableBasic Integrate(IntegrableBasic Idf) {
            double new_coefficient = Idf.coefficient / (Idf.variable_exponent + 1);
            double new_variable_exponent = Idf.variable_exponent + 1;
            return IntegrableBasic.Instantiate(new_coefficient, new_variable_exponent);
        }

        public class IntegrableBasic : Integrable
        {
            public double coefficient { get; private set; }
            public double variable_exponent { get; private set; }

            public static IntegrableBasic Instantiate(double _coefficient, double _variable_exponent)
            {
                IntegrableBasic Idf = new IntegrableBasic();
                Idf.coefficient = _coefficient;
                Idf.variable_exponent = _variable_exponent;
                return Idf;
            }

            public override void DisplayForm() {
                Console.WriteLine(coefficient.ToString() + "x^" + variable_exponent.ToString());
            }
        }
    }

}