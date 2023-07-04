using static System.Math;
public static class Algebra
{
    public static string DetermineSign(double n) { 
        if(n > 0) 
            return "+";
        
        else if(n < 0)
            return "-";
        
        else 

            return "";
        
    }

    public static class Quadratic
    {
        public static double CalculateDiscriminant(double a, double b, double c)
        {
            double delta = Pow(b, 2) - 4 * a * c;
            return delta;
        }

        public static double[] XIntercepts(double a, double b, double delta)
        {
            double[] intercepts;
            if(delta > 0) {
                intercepts = new double[2];
                double squaredDelta = Sqrt(delta);  
                double x1 = (-b - squaredDelta) / 2 * a;
                double x2 = (-b + squaredDelta) / 2 * a;
                intercepts[0] = x1;
                intercepts[1] = x2;
            }
            else if (delta == 0)
            {
                intercepts = new double[1];
                double x0 = -b / (2 * a);
                intercepts[0] = x0;
            }
            else
            {
                intercepts = new double[0];
            }
            return intercepts;
        }
    }

}
