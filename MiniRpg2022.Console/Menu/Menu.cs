using Videogame;
using MiniRpg2022.Logic;

namespace MiniRpg2022.Console;

public class Menu : IMenu
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
            _configuration.Messaging.Show("");
        }
        while (!_quit);
    }

    private void DisplayMenu() =>
        _configuration.Messaging.Show(string.Join("\n", _menuItems.Select((p, i) => $"{i + 1}) {p.Text}")));

    private void ReadOption()
    {
        _configuration.Messaging.Show("Choose an option: ");
        var keyboard = _configuration.Messaging.Prompt();
        _key = (keyboard?.Length != 1) ? ' ' : keyboard[0];
        _configuration.Messaging.Show("");
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