using Physics;
using static System.Math;

namespace AnalyticGeometry
{
    public static class CartesianLine
    {
        public static double CalculateSlope(CartesianVector vector, Point initial){
            // Point management
            double[] components = vector.GetComponents();
            double finalX = components[0];
            double finalY = components[1];

            // Find slope
            double constant = finalY * initial.x - initial.y * finalX;
            double slope = (initial.y + constant) / initial.y;

            return slope;
        }

        public static double CalculateMagnitude(Point point2, Point point1){
            double componentX = point2.x - point1.x;
            double componentY = point2.y - point1.y;

            double magnitude = Pow(componentX, 2) + Pow(componentY, 2);
            magnitude = Sqrt(magnitude);

            return magnitude;
        }

        public static Point CalculateFinalPoint(CartesianVector vector, Point initial)
        {
            double finalX = vector.XValue + initial.x;
            double finalY = vector.YValue + initial.y;

            Point final = new Point();

            final.x = finalX;
            final.y = finalY;

            return final;
        }
    }

    public struct Point
    {
        public double x;
        public double y;

        public static Point Instantiate(double _x, double _y){
            Point p = new Point();
            p.x = _x;
            p.y = _y;
            return p;
        }
        public void Set(double _x, double _y)
        {
            x = _x;
            y = _y;
        }

        public double[] Get()
        {
            return new double[] {
                    x, y
                };
        }
    }
}
