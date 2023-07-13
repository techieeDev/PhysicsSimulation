namespace Physics
{
    public class PhysicBody
    {
        public Mass Mass = new Mass();
        public CartesianVector Velocity = CartesianVector.Instantiate(0f, 0f);
        public CartesianVector Acceleration = CartesianVector.Instantiate(0f, 0f);
        public Characteristic Torque = Characteristic.Instantiate(0.1f);
        public Characteristic AngularVelocity = Characteristic.Instantiate(0.1f);

        public CartesianVector LocalPosition = CartesianVector.Instantiate(1f, 1f);
        public Angle LocalRotation = Angle.Instantiate(0f);
    }
}