namespace MiniRpg2022.Logic.Characteristics;

public class Speed : LimitedValueBetween
{
    public static Speed From(int value) => new(value);

    private Speed(int speed) : base(1, 10, speed)
    {
    }

    public static implicit operator int(Speed speed) => speed.Value;
}