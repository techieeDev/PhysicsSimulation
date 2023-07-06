using static System.Math;

namespace Physics
{
    public partial class PotentialObject
    {
        // a1 = a0 + (F/m)
        // a2 = a1/dt = (a0 + (F/m)) / dt = a0/dt + F/m/dt = a0.m/(dt.m) + F/(m.dt) = (a0.m + F)/m.dt

        protected CartesianForce CalculateContractForce(CartesianForce force, double dt)
        {
            double forceContractX = force.XValue / dt;
            double clampedX = Clamp(forceContractX, 0, force.XValue);
            double forceContractY = force.YValue / dt;
            double clampedY = Clamp(forceContractY, 0, force.YValue);
            return CartesianForce.Instantiate(clampedX, clampedY);
        }


        protected void UpdateAcceleration(double forceX, double forceY, double dt) {
            double accelerationX = Acceleration.XValue / Mass.Value;
            double accelerationY = Acceleration.YValue / Mass.Value;
            accelerationX += (forceX / Mass.Value);
            accelerationY += (forceY / Mass.Value);
 
            Acceleration = CartesianVector.Instantiate(accelerationX, accelerationY);
        }


        protected void UpdateVelocity(double dt) {
            double velocityX = Acceleration.XValue * dt;
            double velocityY = Acceleration.YValue * dt;
            velocityX += (Acceleration.XValue * dt);
            velocityY += (Acceleration.YValue * dt);

            Velocity = CartesianVector.Instantiate(velocityX, velocityY);
        }

        protected void UpdatePosition(double dt){

            double positionX = (Velocity.XValue * Pow(dt, 2) * 0.5f) + LocalPosition.XValue;
            double positionY = (Velocity.YValue * Pow(dt, 2) * 0.5f) + LocalPosition.YValue;
            LocalPosition = CartesianVector.Instantiate(positionX, positionY);
        }


        protected void UpdateNetForce(double forceX, double forceY)
        {
            double netForceX = forceX + NetForce.XValue;
            double netForceY = forceY + NetForce.YValue;
            NetForce = CartesianForce.Instantiate(netForceX, netForceY);
        }
    }
}