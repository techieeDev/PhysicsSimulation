using Physics;
using System;
using static System.Math;
using static System.Console;
using static Calculus.Derivation;

class App
{
    public static Cycle mainloop;

    private static double _timerf = 0;
    private static double _timerf2 = 0;

    private static double ForceAngle = 0;

    //Thread thread1 = new Thread(new ThreadStart(ContinuosAngleVariation));
    static void ContinuosAngleVariation()
    {
        while (true)
        {
            if (mainloop.deltaTime > _timerf2)
            {
                ForceAngle = new Random().Next(360) * 1.25f;
                _timerf2 = mainloop.deltaTime + 0.5f;
            }

            ForceAngle = Clamp(ForceAngle, -360, 360);
        }
    }

    static void Simulate()
    {
        Physics.Object square = new Physics.Object();
        square.Mass.Value = 1.7;

        Physics.AbsoluteForce F = AbsoluteForce.Instantiate(0.01);
        Angle theta = Angle.Instantiate(15);

        if (mainloop.deltaTime > _timerf)
        {
            square.AddTranslationForce(F, theta);
            WriteLine();
            square.LocalPosition.DisplayComponenets();
            _timerf = mainloop.deltaTime + 1;
        }
    }

    static void SimulateSpring(Spring spring, CartesianForce force)
    {
        if(mainloop.deltaTime > _timerf)
        {
            spring.AddPerpendicularForce(force);
            WriteLine(spring.Length.Value + "m");
            _timerf = mainloop.deltaTime + 1;
        }
    }

    static void Main(string[] args)
    {
        mainloop = new Cycle();
        mainloop.Start();

        DifferentiableQuadratic F = DifferentiableQuadratic.Instantiate(2, -4, 1);
        DifferentiableQuadratic dF = Differentiate(F);
        dF.DisplayForm();

        Spring spring = Spring.Instantiate(8, 4.25f, 21);
        CartesianForce pull = CartesianForce.Instantiate(0, 12);

        // Physics simulation
        while (true){
            mainloop.Update();
            SimulateSpring(spring, pull);

        }

    }
}