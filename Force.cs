namespace Physics
{
    public interface IForce{
        public double[] GetComponents();
        public double GetMagnitude();
    }

    public class CartesianForce : CartesianVector, IForce {}

    public class AbsoluteForce : Characteristic {}

}