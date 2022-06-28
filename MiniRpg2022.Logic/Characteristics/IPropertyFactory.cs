namespace MiniRpg2022.Logic.Characteristics;

public interface IPropertyFactory
{
    PropertyValue CreateFor(string name, int value);
}
