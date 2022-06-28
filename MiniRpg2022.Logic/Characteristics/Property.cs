namespace MiniRpg2022.Logic.Characteristics;

public class Property
{
    public string Name { get; }
    public int Minimum { get; }
    public int Maximum { get; }

    public Property(string name, int minimum, int maximum)
    {
        if (minimum > maximum) throw new ArgumentException("Minimum limit cannot be higher than maximum limit");
        Minimum = minimum;
        Maximum = maximum;
        Name = name;
    }
}