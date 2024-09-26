namespace Model;

public class Person
{
    public string Id { get; private init; }
    public string FirstName { get; private init; }
    public string LastName { get; private init; }
    public string Email { get; private init; }
    public Role Role { get; private init; }
}