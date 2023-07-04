using static System.Console;

namespace Physics
{
    public partial class PotentialObject
    {

        public void StartDynamic(Cycle updateCycle)
        {
            while (true)
            {
                CartesianForce[] appliedForces = GetAppliedForces();
                updateCycle.Update();
                double deltaTime = updateCycle.deltaTime;
                for(int i = 0; i<appliedForces.Length; i++)
                {
                    ApplyExponentialTranslationForce(ref appliedForces[i], deltaTime);
                }

                Velocity = CalculateExponentialVelocity(deltaTime);

                LocalPosition.DisplayComponenets();
            }

        }

        protected CartesianForce[] GetAppliedForces()
        {
            int forcesCount = AppliedForces.Count;
            CartesianForce[] cartesianForces = new CartesianForce[forcesCount];

            for(int i = 0; i < forcesCount; i++) {
                cartesianForces[i] = (CartesianForce)AppliedForces[i];
            }

            return cartesianForces;
        }
    }
}