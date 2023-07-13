using static System.Console;
using static System.Math;

namespace Physics
{
    public partial class PotentialObject
    {

        public void StartDynamic(Cycle updateCycle)
        {
            WriteLine("<- Position ->");
            IntervalData positionIntervalData = new IntervalData();
            while (true)
            {
                CartesianForce[] appliedForces = GetAppliedForces();
                updateCycle.Update();
                double deltaTime = updateCycle.deltaTime;
                for(int i = 0; i<appliedForces.Length; i++)
                {
                    CartesianForce force = CartesianForce.Instantiate(appliedForces[i].XValue, appliedForces[i].YValue);
                    ApplyExponentialTranslationForce(ref force, deltaTime);
                    UpdateAppliedForce(i, force);
 
                }
                CartesianVector position0 = new CartesianVector();
                if(positionIntervalData.IsCaptureExist())
                    position0 = (CartesianVector)positionIntervalData.Data;
                    if (Round(position0.GetMagnitude(), 4) != Round(LocalPosition.GetMagnitude(), 4))
                    {
                        LocalPosition.DisplayRoundedComponents();
                    }
                positionIntervalData = IntervalData.Capture(deltaTime, LocalPosition);


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

        protected void UpdateAppliedForce(int forceIndex, CartesianForce force)
        {
            AppliedForces[forceIndex] = force;
        }
    }
}