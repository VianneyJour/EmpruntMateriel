namespace Model;

public class Copy
{
    public string Id { get; private init; }
    public Equipment Equipment { get; private init; }
    public Condition Condition { get; set; }
    public Situation Situation { get; set; }

    public Copy(string id, Equipment equipment, Condition condition, Situation situation)
    {
        Id = id;
        Equipment = equipment;
        Condition = condition;
        Situation = situation;
    }
}