namespace Physics
{
    public partial class PotentialObject
    {
        protected CartesianVector CalculateExponentialAcceleration(double deltaTime)
        {
            double accelerationX = Acceleration.XValue / deltaTime;
            double accelerationY = Acceleration.YValue / deltaTime;
            return CartesianVector.Instantiate(accelerationX, accelerationY);
        }

        protected CartesianVector CalculateExponentialVelocity(double deltaTime)
        {
            double velocityX = Velocity.XValue / deltaTime;
            double velocityY = Velocity.YValue / deltaTime;
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