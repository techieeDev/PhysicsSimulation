using Physics;
using static System.Console;

public class SpringSimulation : PhysicBehaviour
{
    public Spring spring;
    public AbsoluteForce force;

    public override void Update(Cycle main)
    {
        main.Update();
        spring.AddPerpendicularForce(force, main.deltaTime);
        if(spring.Length.Value != spring.ExtensionLimit.Value)
            WriteLine(ID.ToString() + ": " + Math.Round(spring.Length.Value, 3).ToString() + "m");
    }
}