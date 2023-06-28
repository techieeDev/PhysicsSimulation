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
}
