public abstract class PhysicBehaviour
{
  
    public string ID { get; protected set; }
    public static int IDLength = 6;
    public string Tag;

    public virtual void Start(Cycle main)
    {
        ID = IDManager.GenerateBehaviourID(Tag, IDLength);
        
        while (true)
        {
            main.Update();
            Update(main);
        }
    }
    public abstract void Update(Cycle main);

}

