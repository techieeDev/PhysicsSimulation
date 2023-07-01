namespace Calculus
{
    using static System.Math;
    public static partial class Derivation
    {
        public static DifferentiableQuadratic Differentiate(DifferentiableQuadratic dq)
        {
            DifferentiableBasic dxp2 = DifferentiableBasic.Instantiate(dq.xpow2coefficient, 2);
            DifferentiableBasic dxp1 = DifferentiableBasic.Instantiate(dq.xpow1coefficient, 1);

            DifferentiableQuadratic df = DifferentiableQuadratic.Instantiate(dxp2.coefficient, dxp1.coefficient, 0);
            return DifferentiableQuadratic.Instantiate(dxp2.coefficient, dxp1.coefficient, 0);
        }

        public class DifferentiableQuadratic : Differentiable
        {
            public double xpow2coefficient { get; private set; }
            public double xpow1coefficient { get; private set; }
            public double constant { get; private set; }

            public static DifferentiableQuadratic Instantiate(double a, double b, double c){

                DifferentiableQuadratic dq = new DifferentiableQuadratic();
                dq.xpow2coefficient = a;
                dq.xpow1coefficient = b;
                dq.constant = c;
                return dq;
            }

            public override void DisplayForm()
            {
                string c = string.Empty;
                string b = Abs(xpow1coefficient).ToString();
                string exponent = "";

                if(constant != 0) {
                    c = Abs(constant).ToString();
                    exponent = "^2";
                    b += "x";
                }
  

                Console.WriteLine(Abs(xpow2coefficient).ToString() + "x" + exponent + " " + Algebra.DetermineSign(xpow1coefficient) + " " + b + " " + Algebra.DetermineSign(constant) + " " + c);
            }
        }

    }
}
