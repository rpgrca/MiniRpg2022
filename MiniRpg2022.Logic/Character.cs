namespace Videogame;

public class Character
{
    public string Name { get; }
    public DateOnly Birthday { get; }

    public Character(string name, DateOnly birthday)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Invalid name", nameof(name));
        Name = name;
        Birthday = birthday;
    }
}