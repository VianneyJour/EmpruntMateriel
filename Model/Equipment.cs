namespace Model;

public class Equipment
{
    public string Id { get; private init; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string SmallImage { get; set; }
    public string LargeImage { get; set; }
    public int NbOfStoredCopies { get; set; }
    public int NbOfReservedCopies { get; set; }
    public int NbOfFreeCopies { get; set; }
    public int TotalNbOfCopies { get; set; }
    public Person Supervisor { get; set; }
    public List<Copy> Copies { get; set; }
    public Equipment(string id, string name, string description, string smallImage, string largeImage, int nbOfStoredCopies, int nbOfReservedCopies, int nbOfFreeCopies, Person supervisor)
    {
        Id = id;
        Name = name;
        Description = description;
        SmallImage = smallImage;
        LargeImage = largeImage;
        NbOfStoredCopies = nbOfStoredCopies;
        NbOfReservedCopies = nbOfReservedCopies;
        NbOfFreeCopies = nbOfFreeCopies;
        TotalNbOfCopies = nbOfStoredCopies + nbOfReservedCopies + nbOfFreeCopies;
        Supervisor = supervisor;
        Copies = new List<Copy>();
    }
}