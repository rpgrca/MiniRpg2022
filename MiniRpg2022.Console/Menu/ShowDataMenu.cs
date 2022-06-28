using Videogame;

namespace MiniRpg2022.Console;

public class ShowDataMenu : MenuItem
{
    public ShowDataMenu() : base("Show character data")
    {
    }

    public override bool Execute(Configuration configuration)
    {
        var names = configuration.GetCharacterNames();
        if (! names.Any())
        {
            System.Console.WriteLine("No loaded characters still.");
            return false;
        }

        var name = Choose("Choose a character", names);
        DisplayDataFrom(configuration.GetCharacter(name));
        return false;
    }

    private static void DisplayDataFrom(Character character)
    {
        System.Console.WriteLine(Environment.NewLine +
            $"Name: {character.Name}" + Environment.NewLine +
            $"Nickname: {character.Nickname}" + Environment.NewLine +
            $"Occupation: {character.Occupation}" + Environment.NewLine +
            $"Birthday: {character.Birthday}");
    }
}

public class LoadPropertiesMenu : MenuItem
{
    public LoadPropertiesMenu() : base("Load properties")
    {
    }

    public override bool Execute(Configuration configuration)
    {
        var names = configuration.GetCharacterNames();
        if (! names.Any())
        {
            System.Console.WriteLine("No loaded characters still.");
            return false;
        }

        var name = Choose("Choose a character", names);
        var character = configuration.GetCharacter(name);

        foreach (var property in configuration.GetProperties())
        {

        }

        var occupation = Choose("Please choose an occupation", configuration.GetOccupationNames());
        var nickname = Prompt("Add a nickname for your character", v => v is null);
        var birthday = PromptDate("Please input your character birthday", "yyyy/MM/dd");

        var character = new Character.Builder()
            .Called(name)
            .AlsoKnownAs(nickname)
            .BornOn(new Birthday.Builder().BornOn(birthday).Build())
            .As(configuration.GetOccupation(occupation))
            .Build();

        configuration.RegisterCharacter(character);

        return false;
    }

    private void 
}