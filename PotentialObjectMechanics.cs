using Calculus;
using static System.Math;

namespace Physics
{
    public partial class PotentialObject
    {
        protected CartesianForce CalculateContractForce(CartesianForce force, double dt)
        {
            double forceContractX = force.XValue / dt;
            double clampedX = Clamp(forceContractX, 0, force.XValue);
            double forceContractY = force.YValue / dt;
            double clampedY = Clamp(forceContractY, 0, force.YValue);
            return CartesianForce.Instantiate(clampedX, clampedY);
        }


        protected void UpdateAcceleration(double forceX, double forceY, double dt) {
            double accelerationX = (Acceleration.XValue + forceX) / (Mass.Value * dt);
            double accelerationY = (Acceleration.YValue + forceY) / (Mass.Value * dt);
            Acceleration = CartesianVector.Instantiate(accelerationX, accelerationY);
        }

        protected void UpdateVelocity(double dt) {
            CartesianVector integrateAcceleration = CartesianVector.IntegrateVector(Acceleration, dt, 1);
            double velocityX = Acceleration.XValue * 0.5f * Pow(dt, 2);
            double velocityY = Acceleration.YValue * 0.5f * Pow(dt, 2);
            Velocity = CartesianVector.Instantiate(velocityX, velocityY) ;
        }

        protected void UpdatePosition(double dt){
            CartesianVector integrateVelocity = CartesianVector.IntegrateVector(Velocity, dt, 1);
            LocalPosition = CartesianVector.Instantiate(LocalPosition.XValue + integrateVelocity.XValue, LocalPosition.YValue + integrateVelocity.YValue);
        }

    }
}