public class IDManager
{
    static Random Randomizer = new Random();
    public static string GenerateBehaviourID(string tag, int length)
    {
        string numeric = "";
        for(int i = 0; i < length; i++) {
            numeric += Randomizer.Next(0, 9).ToString();
        }
        return tag + "_" + numeric;
    }

    
}