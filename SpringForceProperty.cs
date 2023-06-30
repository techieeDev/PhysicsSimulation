using static System.Math;

namespace Physics
{
    public partial class Spring
    {
        public void AddPerpendicularForce(IForce force)
        {
            // Force magnitude
            double forceMagnitude = force.GetComponents()[1];

            // Calculate extension
            double deltaExtension = forceMagnitude / StiffnessConstant.Value;

            // Update spring length
            Length.Value += deltaExtension;
            Length.Value = Clamp(Length.Value, 0, ExtensionLimit.Value);
        }

        public void AddPerpendicularForce(AbsoluteForce force){

            // Force magnitude
            double forceMagntiude = force.Value;

            // Calculate extension
            double deltaExtension = forceMagntiude / StiffnessConstant.Value;

            // Update spring length
            Length.Value += deltaExtension;
            Length.Value = Clamp(Length.Value, 0, ExtensionLimit.Value);
        }
    }
}