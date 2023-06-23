using Physics;
using System;

class App
{
    public static Cycle mainloop;
    static void Main(string[] args)
    {
        mainloop = new Cycle();

        mainloop.Start();

        while (true){
            mainloop.Update();
        }

    }
}