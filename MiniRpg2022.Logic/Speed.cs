namespace Videogame;

public class Speed
{
    private int _speed;

    public static Speed From(int value) => new(value);

    private Speed(int speed)
    {
        if (speed < 1 || speed > 10) throw new ArgumentException("Invalid speed", nameof(speed));
        _speed = speed;
    }

    public static implicit operator int(Speed speed) => speed._speed;
}