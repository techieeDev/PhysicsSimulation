using System.Diagnostics;

public class Cycle
{
    protected Stopwatch timer = new Stopwatch();
    public double deltaTime;
    
    public void Start()
    {
        timer.Start();
    }

    public void Update()
    {
        double elapsedSeconds = timer.Elapsed.TotalSeconds;
        deltaTime = elapsedSeconds - deltaTime;

        deltaTime = elapsedSeconds;

        Thread.Sleep(16);
    }
}