namespace Model;

public class Stub
{
    public Stub()
    {
        List<Equipment> equips = new List<Equipment>();
        Person supervisor = new Person();
        equips.Add(new Equipment("123","Iphone", "téléphone", "dotnet_bot.png", "dotnet_bot.png", 5, 2, 3, supervisor));
        equips.Add(new Equipment("124","Iphone6", "téléphone", "dotnet_bot.png", "dotnet_bot.png", 5, 2, 3, supervisor));
    }
}