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

        SpringSimulation simulation = new SpringSimulation();
        simulation.Tag = "PhySPR";
        simulation.spring = Spring.Instantiate(5, 2.75f, 24f);
        simulation.force = AbsoluteForce.Instantiate(3.20f);
        simulation.Start(mainloop);
    }
}