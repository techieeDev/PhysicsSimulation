namespace Physics
{
    public interface IForce{
        public double[] GetComponents();
        public double GetMagnitude();
    }

    public class CartesianForce : CartesianVector, IForce
    {
        public static new CartesianForce Instantiate(double x, double y){
            CartesianForce force = new CartesianForce();

            force.XValue = x;
            force.YValue = y;

            return force;
        }
    }

    public class AbsoluteForce : Characteristic {
        public static new AbsoluteForce Instantiate(double value) {
            AbsoluteForce F = new AbsoluteForce();
            F.Value = value;
            return F;
        }
    }

}