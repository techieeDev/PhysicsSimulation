using Physics;
using System;
using static System.Math;
using static System.Console;
using AnalyticGeometry;

class App
{
    public static Cycle mainloop;

    private static double _timerf = 0;
    private static double _timerf2 = 0;

    private static double ForceAngle = 0;

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

    static void Main(string[] args)
    {
        //Thread thread1 = new Thread(new ThreadStart(ContinuosAngleVariation));

        mainloop = new Cycle();

        mainloop.Start();
        //thread1.Start();

        Physics.Object square = new Physics.Object();
        square.Mass.Value = 1.7;

        Physics.CartesianForce N = CartesianForce.Instantiate(3.72f, 3 * Exp(-3));
        Physics.AbsoluteForce F = AbsoluteForce.Instantiate(0.01);
        Point initial = Point.Instantiate(2, 4);
        Angle theta = Angle.Instantiate(15);
        while (true){
            mainloop.Update();

            if (mainloop.deltaTime > _timerf) {
                square.AddTranslationForce(F, theta);
                WriteLine();
                square.LocalPosition.DisplayComponenets();
                _timerf = mainloop.deltaTime + 1;
            }
            
        }

    }
}