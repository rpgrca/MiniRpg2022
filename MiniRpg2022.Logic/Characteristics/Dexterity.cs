namespace MiniRpg2022.Logic.Characteristics;

public class Dexterity : LimitedValueBetween
{
    public static Dexterity From(int value) => new(value);

    private Dexterity(int dexterity) : base(1, 5, dexterity)
    {
    }

    public static implicit operator int(Dexterity dexterity) => dexterity.Value;
}