using MiniRpg2022.Logic.Characteristics;

namespace Videogame;

public partial class Character
{
    public string Name { get; }
    public string Nickname { get; }
    public Birthday Birthday { get; }
    public int Health { get; }
    public IOccupation Occupation { get; }
    public Speed Speed { get; }
    public Dexterity Dexterity { get; }

    private Character(string name, string nickname, Birthday birthday, IOccupation occupation, int speed, int agility)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Invalid name", nameof(name));
        if (nickname is null) throw new ArgumentException("Invalid nickname", nameof(nickname));
        if (birthday is null) throw new ArgumentException("Invalid birthday", nameof(birthday));
        if (occupation is null) throw new ArgumentException("Invalid occupation", nameof(occupation));

        Name = name;
        Nickname = nickname;
        Birthday = birthday;
        Occupation = occupation;
        Health = 100;
        Speed = Speed.From(speed);
        Dexterity = Dexterity.From(agility);
    }
}