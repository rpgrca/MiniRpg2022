namespace MiniRpg2022.Logic.Characteristics;

public class Armour : LimitedValueBetween
{
    public static Armour From(int value) => new(value);

    private Armour(int armour) : base(1, 10, armour)
    {
    }

    public static implicit operator int(Armour armour) => armour.Value;
}