using static System.Math;

namespace Physics
{
    public partial class PotentialObject
    {
        // a1 = a0 + (F/m)
        // a2 = a1/dt = (a0 + (F/m)) / dt = a0/dt + F/m/dt = a0.m/(dt.m) + F/(m.dt) = (a0.m + F)/m.dt

        protected CartesianForce CalculateContractForce(CartesianForce force, double deltaTime)
        {
            double forceContractX = 1 / (deltaTime * force.XValue * InstantResistance.Value);
            double clampedX = Clamp(forceContractX, double.MinValue, force.XValue);
            double forceContractY = 1 / (deltaTime * force.YValue * InstantResistance.Value);
            double clampedY = Clamp(forceContractY, double.MinValue, force.YValue);
            return CartesianForce.Instantiate(clampedX, clampedY);
        }


        protected void UpdateAcceleration(double forceX, double forceY, double dt) {
            double accelerationX = Acceleration.XValue + (forceX / Mass.Value);
            double accelerationY = Acceleration.YValue + (forceY / Mass.Value);
            Acceleration = CartesianVector.Instantiate(accelerationX, accelerationY);
        }


        protected void UpdateVelocity(double dt) {
            double velocityX = Velocity.XValue + (Acceleration.XValue * dt);
            double velocityY = Velocity.YValue + (Acceleration.YValue * dt);
            Velocity = CartesianVector.Instantiate(velocityX, velocityY);
        }

        protected void UpdatePosition(double deltaTime){

            LocalPosition.UpdateVector(Velocity.XValue * deltaTime * 0.5f, Velocity.YValue * deltaTime * 0.5f);
        }


        protected void UpdateNetForce(double forceX, double forceY)
        {
            double netForceX = forceX + NetForce.XValue;
            double netForceY = forceY + NetForce.YValue;
            NetForce = CartesianForce.Instantiate(netForceX, netForceY);
        }
    }
}