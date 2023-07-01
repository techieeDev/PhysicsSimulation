using Physics;

public class ObjectForceSimulation : PhysicBehaviour
{
    public Physics.Object Solid2D;
    public CartesianForce cartesianForce;

    public override void Update(Cycle main)
    {
        Solid2D.AddTranslationForce(cartesianForce, main.deltaTime);
        Console.WriteLine(ID + ": " + Solid2D.LocalPosition.XValue);
    }
}