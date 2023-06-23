namespace Physics
{
    public partial class Object
    {
        public void AddTranslationForce(IForce force){
            double[] components = force.GetComponents();
            
        }

        public void AddTranslationForce(AbsoluteForce absoluteForce){

        }

        public void AddRotationForce(IForce force) { 
            
        }

        public void AddRotationForce(AbsoluteForce absoluteForce)
        {

        }
    }
}