namespace Videogame;

public class Character
{
    public string Name { get; }
    public string Nickname { get; }
    public Birthday Birthday { get; }
    public int Health { get; }
    public IOccupation Occupation { get; }

    public Character(string name, string nickname, Birthday birthday, IOccupation occupation)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Invalid name", nameof(name));
        if (nickname is null) throw new ArgumentException("Invalid nickname", nameof(nickname));

        Name = name;
        Nickname = nickname;
        Birthday = birthday;
        Occupation = occupation;
        Health = 100;
    }
}
