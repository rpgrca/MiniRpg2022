using Videogame;

namespace MiniRpg2022.Console;

public class ManualLoadMenu : MenuItem
{
    public ManualLoadMenu() : base("Create character manually")
    {
    }

    public override bool Execute(Configuration configuration)
    {
        var name = configuration.Messaging.Prompt("Please name your character", v => string.IsNullOrEmpty(v));

        if (NameExistsAndDoNotOverride(configuration, name)) return false;

        var occupation = configuration.Messaging.Choose("Please choose an occupation", configuration.GetOccupationNames());
        var nickname = configuration.Messaging.Prompt("Add a nickname for your character", v => v is null);
        var birthday = configuration.Messaging.PromptDate("Please input your character birthday", "yyyy/MM/dd");

        var character = new Character.Builder()
            .Called(name)
            .AlsoKnownAs(nickname)
            .BornOn(new Birthday.Builder().BornOn(birthday).Build())
            .As(configuration.GetOccupation(occupation))
            .Build();

        configuration.RegisterCharacter(character);
        return false;
    }

    private bool NameExistsAndDoNotOverride(Configuration configuration, string name)
    {
        var character = configuration.GetCharacterOrDefault(name);
        if (character is not null)
        {
            var replace = configuration.Messaging.Choose("Character already exists! Do you wish to override them? (Y/N)", new List<string> { "Y", "N" });
            return replace == "N";
        }

        return false;
    }
}