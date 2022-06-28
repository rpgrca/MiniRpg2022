namespace Videogame;

public interface IOccupation
{
    string ToString();
}

public class Mage : IOccupation
{
    public override string ToString() => "mage";
}

public class Warrior : IOccupation
{
    public override string ToString() => "warrior";
}

public class Archer : IOccupation
{
    public override string ToString() => "archer";
}

public class Thief : IOccupation
{
    public override string ToString() => "thief";
}