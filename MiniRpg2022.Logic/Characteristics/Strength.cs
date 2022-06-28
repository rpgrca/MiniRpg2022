namespace MiniRpg2022.Logic.Characteristics;

public class Strength : LimitedValueBetween
{
    public static Strength From(int value) => new(value);

    private Strength(int strength) : base(1, 10, strength)
    {
    }

    public static implicit operator int(Strength strength) => strength.Value;
}