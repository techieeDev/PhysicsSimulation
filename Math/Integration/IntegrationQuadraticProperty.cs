namespace Calculus
{
    public partial class IndefiniteIntegration
    {

        public static IntegrableQuadratic Integrate(IntegrableQuadratic Idq)
        {
            IntegrableBasic xp2 = IntegrableBasic.Instantiate(Idq.xpow2coefficient, 2);
            IntegrableBasic xp1 = IntegrableBasic.Instantiate(Idq.xpow1coefficient, 1);
            IntegrableBasic c = IntegrableBasic.Instantiate(Idq.constant, 0);

            IntegrableBasic Ixp2 = Integrate(xp2);
            IntegrableBasic Ixp1 = Integrate(xp1);
            IntegrableBasic Ic = Integrate(c);

            return IntegrableQuadratic.Instantiate(Ixp2.coefficient, Ixp1.coefficient, Ic.coefficient);
        }

        public class IntegrableQuadratic : Integrable
        {
            public double xpow2coefficient { get; private set; }
            public double xpow1coefficient { get; private set; }
            public double constant { get; private set; }

            public static IntegrableQuadratic Instantiate(double a, double b, double c){

                IntegrableQuadratic Idq = new IntegrableQuadratic();
                Idq.xpow2coefficient = a;
                Idq.xpow1coefficient = b;
                Idq.constant = c;
                return Idq;
            }

            public override void DisplayForm(){}
        }
    }
}