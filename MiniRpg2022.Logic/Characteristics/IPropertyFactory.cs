namespace MiniRpg2022.Logic.Characteristics;

public interface IPropertyFactory
{
    Property CreateFor(string name, int value);
}
