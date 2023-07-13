using System.Collections;
using static System.Math;

namespace Physics
{
    public partial class PotentialObject
    {
        public CartesianForce NetForce = CartesianForce.Instantiate(0f, 0f);

        protected ArrayList AppliedForces = new ArrayList();

        public void AssignTranslationForce(IForce force)
        {
            // Force components
            double[] forceComponents = force.GetComponents();

            // Assign to applied forces
            CartesianForce cartesianForce = CartesianForce.Instantiate(forceComponents[0], forceComponents[1]);
            AppliedForces.Add(cartesianForce);
        }

        protected void ApplyExponentialTranslationForce(ref CartesianForce force, double deltaTime)
        {
            // Force components
            double forceX = force.XValue;
            double forceY = force.YValue;

            // Calculate acceleration
            UpdateAcceleration(forceX, forceY, deltaTime);

            // Update velocity
            UpdateVelocity(deltaTime);

            // Calculate position
            UpdatePosition(deltaTime);

            // Calculate force contract
            force = CalculateContractForce(force, deltaTime);
        }
    }
}