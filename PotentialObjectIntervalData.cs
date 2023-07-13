namespace Physics
{
    partial class PotentialObject
    {
        struct IntervalData
        {
            public object Data { get; private set; }
            public double TimeCapture { get; private set; }
            public static IntervalData Capture(double time, object _data)
            {
                IntervalData data = new IntervalData();
                data.TimeCapture = time;
                data.Data = _data;
                return data;
            }

            public bool IsCaptureExist()
            {
                return TimeCapture > 0;
            }
        }
    }

}