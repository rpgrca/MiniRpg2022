namespace Videogame;

public class Speed
{
    private readonly int _speed;

    public static Speed From(int value) => new(value);

    private Speed(int speed)
    {
        if (speed < 1 || speed > 10) throw new ArgumentException("Invalid speed", nameof(speed));
        _speed = speed;
    }

    public static implicit operator int(Speed speed) => speed._speed;
}

public class Dexterity
{
    private readonly int _dexterity;

    public static Dexterity From(int value) => new(value);

    private Dexterity(int dexterity)
    {
        if (dexterity < 1 || dexterity > 5) throw new ArgumentException("Invalid dexterity", nameof(dexterity));
        _dexterity = dexterity;
    }

    public static implicit operator int(Dexterity dexterity) => dexterity._dexterity;
}