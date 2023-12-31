﻿using Calculus;
using static System.Console;
using static System.Math;

namespace Physics
{
    public partial class Object : PhysicBody{
    }

    public partial class PotentialObject : PhysicBody{
    }

    public partial class Spring
    {
        public Characteristic Length = Characteristic.Instantiate(1);
        protected Characteristic StiffnessConstant = new Characteristic();
        public Characteristic ExtensionLimit = new Characteristic();

        public static Spring Instantiate(double length, double stiffnessConstant, double extLimit){
            Spring spring = new Spring();
            spring.Length.Value = length;
            spring.StiffnessConstant.Value = stiffnessConstant;
            spring.ExtensionLimit.Value = extLimit;
            
            return spring;
        }      
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




    public class Axis{
        public double Min;
        public double Max;

        public void DisplayRange(string axename){
            WriteLine(axename + ": " + Min + " to " + Max);
        }
    }

    public class CoordinateSystem{

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

        public static Characteristic Instantiate(double Value) { 
            Characteristic characteristic = new Characteristic();
            characteristic.Value = Value;
            return characteristic;
        }

        public virtual void SetValue(double value){
            Value = Math.Abs(value);
        }
    }
    public class ReferCharacteristic{
        public double Value { get; private set; }

        public static ReferCharacteristic Instantiate(double Value)
        {
            ReferCharacteristic characteristic = new ReferCharacteristic();
            characteristic.Value = Value;
            return characteristic;
        }
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

        public virtual void UpdateVector(double xUpdate, double yUpdate)
        {
            XValue += xUpdate;
            YValue += yUpdate;
        }

        public static CartesianVector IntegrateVector(CartesianVector integrableVector, double variable, double variable_exponent)
        {
            IndefiniteIntegration.IntegrableBasic integrableX = IndefiniteIntegration.IntegrableBasic.Instantiate(integrableVector.XValue, variable_exponent);
            IndefiniteIntegration.IntegrableBasic integrableY = IndefiniteIntegration.IntegrableBasic.Instantiate(integrableVector.YValue, variable_exponent);

            IndefiniteIntegration.IntegrableBasic integrateX = IndefiniteIntegration.Integrate(integrableX);
            IndefiniteIntegration.IntegrableBasic integrateY = IndefiniteIntegration.Integrate(integrableY);

            return Instantiate(integrateX.coefficient * Pow(variable, integrateX.variable_exponent), integrateY.coefficient * Pow(variable, integrateY.variable_exponent));

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



        public virtual void DisplayComponenets(){
            WriteLine("X: " + XValue.ToString() + " Y: " + YValue.ToString()); 
        }

        public virtual void DisplayRoundedComponents()
        {
            string roundX = (Round(XValue, 4)).ToString();
            string roundY = (Round(YValue, 4)).ToString();
            WriteLine("X: " + roundX + " Y: " + roundY);
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

    public class Angle{
        public double Radians;
        public double Degrees;

        public static Angle Instantiate(double degrees){
            Angle theta = new Angle();
            
            theta.Degrees = degrees;
            theta.Radians = Trigonometric.ConvertToRadians(degrees);

            return theta;
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

        public static double ConvertToDegrees(double radians) { 
            return (radians * 180) / Math.PI;
        }

        public static double Cotangent(double x){
            return 1 / (Math.Tan(x));
        }
    }
}