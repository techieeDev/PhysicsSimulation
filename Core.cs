using static System.Console;

namespace Physics
{
    public partial class Object
    {
        public Mass Mass = new Mass();
    }

    public class Plane : Object
    {
        public Angle InclinationAngle = new Angle();
        public Length Length = new Length();
        private bool HasReaction;

        public void SetReaction(bool value)
        {
            HasReaction = value;
        }
    }

    public class System
    {
        public Plane Plane = new Plane();
        public Object Solid = new Object();
        public GravitationalForce GravitationalForce = new GravitationalForce();
    }

    public struct Point
    {
        public double x;
        public double y;
        public void Set(double _x, double _y){
            x = _x;
            y = _y;
        }

        public double[] Get(){
            return new double[] {
                    x, y
                };
        }
    }


    public class Axis{
        public double Min;
        public double Max;

        public void DisplayRange(string axename){
            WriteLine(axename + ": " + Min + " to " + Max);
        }
    }

    public class CoordinateSystem
    {
        public Axis XAxis = new Axis();
        public Axis YAxis = new Axis();

        public static CoordinateSystem Instantiate(double XMin, double XMax, double YMin, double YMax){
            CoordinateSystem system = new CoordinateSystem();

            // X Axis

            system.XAxis.Max = XMax; 
            system.XAxis.Min = XMin;

            // Y Axis

            system.YAxis.Max = YMax; 
            system.YAxis.Min = YMin;

            return system;
        }

        public bool IsPointValid(Point h){
            bool IsValid = false;

            if(h.x >= XAxis.Min && h.x <= XAxis.Max)

                if(h.y >= YAxis.Min && h.y <= YAxis.Max) 
                    IsValid = true; 
            
            return IsValid;
        }

        public void DisplayAxesRanges(){
            XAxis.DisplayRange("XAxis");
            YAxis.DisplayRange("YAxis");
        }
    }

    public class Characteristic{
        public double Value { get; set; }

        public virtual void SetValue(double value){
            Value = Math.Abs(value);
        }
    }
    public class ReferCharacteristic{
        public double Value { get; }
    }

    public class CartesianVector {
        public double XValue;
        public double YValue;        

        public static CartesianVector Instantiate(double x, double y){
            CartesianVector vector = new CartesianVector();

            vector.XValue = x;
            vector.YValue = y;

            return vector;
        }

        public virtual void SetXValue(double x) { 
            XValue = x;
        }
        public virtual void SetYValue(double y) {
            YValue = y;
        }
        public virtual double[] GetComponents(){
            return new double[2] { XValue, YValue };
        }

        public virtual double GetMagnitude(){
            double magnitude = Math.Sqrt(Math.Pow(XValue, 2) + Math.Pow(YValue, 2));
            return magnitude;
        }
    }

    public class GravitationalForce : Characteristic {}

    public class Weight : ReferCharacteristic {
        public void SetValueTo(double Value){
            Value = Math.Abs(Value);
        }
    }

    public class Mass : Characteristic{

        public Weight Weight = new Weight();

        public double GetWeight(double gravitational_force){
            return gravitational_force * Value;
        }

        public void SetValue(double value, double gravitational_force){
            Value = Math.Abs(value);
            Weight.SetValueTo(value * gravitational_force);
        }

        public void DisplayValue() {
            WriteLine("Mass: " + Value.ToString());
        }

        public void DisplayWeightValue() {
            WriteLine("Weight: " + Weight.Value);
        }
    }

    public class Length : Characteristic { }

    public class Angle : Characteristic{
        public double Radians;

        public override void SetValue(double value){
            Value = value;
            Value = Math.Clamp(Value, 0, 360);
            Radians = Trigonometric.ConvertToRadians(Value);
        }

        public double GetSin(){
            return Math.Sin(Radians);
        }

        public double GetCos() {
            return Math.Cos(Radians);
        }

        public double GetTangent() {
            return Math.Tan(Radians);
        }
        
        public double GetCotangent(){
            return Trigonometric.Cotangent(Radians);
        }
    }

    public class Trigonometric
    {
        public static double ConvertToRadians(double degrees){
            return (degrees * Math.PI ) / 180;
        }

        public static double Cotangent(double x){
            return 1 / (Math.Tan(x));
        }
    }
}