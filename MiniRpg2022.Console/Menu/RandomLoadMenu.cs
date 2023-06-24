using MiniRpg2022.Logic.Characteristics;
using Videogame;

namespace MiniRpg2022.Console;

public class RandomLoadMenu : MenuItem
{
    public RandomLoadMenu() : base("Create character randomly")
    {
    }

    public override bool Execute(Configuration configuration)
    {
        var characterRandomization = new CharacterRandomization(configuration);
        var character = characterRandomization.Create();
        configuration.RegisterCharacter(character);

        configuration.Messaging.Show($"{character.Name} properties generated randomly.");
        return false;
    }
}