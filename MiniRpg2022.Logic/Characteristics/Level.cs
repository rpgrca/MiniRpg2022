namespace MiniRpg2022.Logic.Characteristics;

public class Level : LimitedValueBetween
{
    public static Level From(int value) => new(value);

    private Level(int level) : base(1, 10, level)
    {
    }

    public static implicit operator int(Level level) => level.Value;
}