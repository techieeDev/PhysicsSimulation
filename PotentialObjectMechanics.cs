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
            double accelerationX = (forceX + Acceleration.XValue) / Mass.Value;
            double accelerationY = (forceY + Acceleration.YValue) / Mass.Value;
            Acceleration = CartesianVector.Instantiate(accelerationX, accelerationY);
        }

        protected void UpdateVelocity(double dt) {
            CartesianVector integrateAcceleration = CartesianVector.IntegrateVector(Acceleration, dt, 1);
            Velocity = CartesianVector.Instantiate(integrateAcceleration.XValue, integrateAcceleration.YValue);
        }

        protected void UpdatePosition(double dt){
            CartesianVector integrateVelocity = CartesianVector.IntegrateVector(Velocity, dt, 1);
            LocalPosition = CartesianVector.Instantiate(LocalPosition.XValue + integrateVelocity.XValue, LocalPosition.YValue + integrateVelocity.YValue);
        }

    }
}