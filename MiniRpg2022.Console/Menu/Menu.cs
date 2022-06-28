using Videogame;

namespace MiniRpg2022.Console;

public class Menu
{
    private readonly List<MenuItem> _menuItems;
    private readonly Configuration _configuration;
    private char _key;
    private bool _quit;
    private MenuItem _selectedMenuItem;

    public Menu(Configuration configuration)
    {
        _menuItems = new List<MenuItem>
        {
            new ManualLoadMenu(),
            new ShowDataMenu(),
            new ManualLoadPropertiesMenu(),
            new ShowPropertyMenu(),
            new RandomLoadMenu(),
            new QuitMenu()
        };

        _configuration = configuration;
    }

    public void Execute()
    {
        do
        {
            DisplayMenu();
            ReadOption();

            FindSelectedMenuItem();
            ExecuteMenuItem();
            System.Console.WriteLine();
        }
        while (!_quit);
    }

    private void DisplayMenu() =>
        System.Console.WriteLine(string.Join("\n", _menuItems.Select((p, i) => $"{i + 1}) {p.Text}")));

    private void ReadOption()
    {
        System.Console.Write("Choose an option: ");
        var keyboard = System.Console.ReadLine();
        _key = (keyboard?.Length != 1)? ' ' : keyboard[0];
        System.Console.WriteLine();
    }

    private void FindSelectedMenuItem()
    {
        var index = _key - '0' - 1;
        _selectedMenuItem = index >= 0 && index < _menuItems.Count
            ? _menuItems[index]
            : new NullMenuItem();
    }

    private void ExecuteMenuItem() => _quit = _selectedMenuItem.Execute(_configuration);
}