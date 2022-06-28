namespace Videogame;

public class Character
{
    public string Name { get; }
    public Birthday Birthday { get; }
    public int Health { get; }

    public Character(string name, Birthday birthday)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Invalid name", nameof(name));

        Name = name;
        Birthday = birthday;
        Health = 100;
    }
}
