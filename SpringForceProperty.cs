using static System.Math;

namespace Physics
{
    public partial class Spring
    {
        private double CalculateExtension(double forceMagnitude){
            return forceMagnitude / StiffnessConstant.Value;
        }

        private void UpdateSpringLength(double deltaExt, double deltaTime) {
            Length.Value += deltaExt * deltaTime;
            Length.Value = Clamp(Length.Value, 0, ExtensionLimit.Value);
        }

        public void AddPerpendicularForce(IForce force, double deltaTime)
        {
            // Force magnitude
            double forceMagnitude = force.GetComponents()[1];

            // Calculate extension
            double deltaExtension = CalculateExtension(forceMagnitude);

            // Update spring length
            UpdateSpringLength(deltaExtension, deltaTime);
        }

        public void AddPerpendicularForce(AbsoluteForce force, double deltaTime)
        {
            // Force magnitude
            double forceMagnitude = force.Value;

            // Calculate extension
            double deltaExtension = CalculateExtension(forceMagnitude);

            // Update spring length
            UpdateSpringLength(deltaExtension, deltaTime);

        }
    }
}