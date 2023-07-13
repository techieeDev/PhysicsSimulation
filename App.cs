using Physics;
using static System.Math;
using static System.Console;
using static Calculus.Derivation;
using static Calculus.IndefiniteIntegration;

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
        CartesianForce F = CartesianForce.Instantiate(10, 0);
        CartesianForce GravityForce = CartesianForce.Instantiate(0, -9.8f);
        p.Mass.Value = 100;
        p.AssignTranslationForce(F);
        p.StartDynamic(mainloop);

        // ~ Integrate ~ //
        IntegrableQuadratic q = IntegrableQuadratic.Instantiate(2, 3, 1);
        IntegrableQuadratic Q = Integrate(q);
        //WriteLine(Q.xpow2coefficient);

    }
}