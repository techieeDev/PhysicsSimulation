namespace Physics
{
    public partial class PotentialObject
    {
        // a1 = a0 + (F/m)
        // a2 = a1/dt = (a0 + (F/m)) / dt = a0/dt + F/m/dt = a0.m/(dt.m) + F/(m.dt) = (a0.m + F)/m.dt

        protected CartesianVector CalculateExponentialAcceleration(double forceX, double forceY, double deltaTime) {
            double accelerationX = ((Acceleration.XValue * Mass.Value) + forceX) / (Mass.Value * deltaTime);
            double acceleartionY = ((Acceleration.YValue * Mass.Value) + forceY) / (Mass.Value * deltaTime);
            return CartesianVector.Instantiate(accelerationX, acceleartionY);
        }


        protected CartesianVector CalculateExponentialVelocity(double deltaTime)
        {
            double velocityX = (Velocity.XValue / deltaTime) + Acceleration.XValue;
            double velocityY = (Velocity.YValue / deltaTime) + Acceleration.YValue;
            return CartesianVector.Instantiate(velocityX, velocityY);
        }


        protected void UpdateNetForce(double forceX, double forceY)
        {
            double netForceX = forceX + NetForce.XValue;
            double netForceY = forceY + NetForce.YValue;
            NetForce = CartesianForce.Instantiate(netForceX, netForceY);
        }
    }
}