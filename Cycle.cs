using System.Diagnostics;

public class Cycle
{
    private Stopwatch timer;
    public double deltaTime;

    public void Start()
    {
        timer = new Stopwatch();    
        timer.Start();
    }

    public void Update()
    {
        double elapsedSeconds = timer.Elapsed.TotalSeconds;
        deltaTime = elapsedSeconds - deltaTime;

        deltaTime = elapsedSeconds;
    }
}