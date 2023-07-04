using Physics;
using static System.Math;
using static System.Console;
using static Calculus.Derivation;

class App
{
    public static Cycle mainloop;

    static void Main(string[] args)
    {
        mainloop = new Cycle();
        mainloop.Start();

        // ~ Spring simulation ~ //
        SpringSimulation simulation = new SpringSimulation();
        simulation.Tag = "PhySPR";
        simulation.spring = Spring.Instantiate(5, 2.75f, 24f);
        simulation.force = AbsoluteForce.Instantiate(3.20f);
        // ~ Spring simulation ~ //

        // ~ Object force simulation ~ //
        ObjectForceSimulation simulation1 = new ObjectForceSimulation();
        simulation1.Tag = "PhyObj";
        Physics.Object solid = new Physics.Object();
        solid.Mass.Value = 0.001f;
        simulation1.Solid2D = solid;
        simulation1.cartesianForce = CartesianForce.Instantiate(Exp(-200), Exp(-200));
        // ~ Object force simulation ~ //

        // ~ Potential object ~ //
        PotentialObject p = new PotentialObject();
        CartesianForce F = CartesianForce.Instantiate(6, 6.25f);
        p.Mass.Value = 2.5f;
        p.AddTranslationForce(F);
        p.StartDynamic(mainloop);

    }
}