namespace Videogame;

public class Configuration
{
    private readonly Dictionary<string, IOccupation> _occupations;

    public Configuration()
    {
        _occupations = new Dictionary<string, IOccupation>();
    }

    public void RegisterOccupation(IOccupation occupation) =>
        _occupations.Add(occupation.ToString(), occupation);

    public IEnumerable<string> GetOccupationNames() => _occupations.Select(p => p.Key);
}