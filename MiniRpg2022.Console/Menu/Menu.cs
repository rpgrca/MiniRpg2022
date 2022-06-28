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
            new LoadMenu(),
            new ShowDataMenu()
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

    private void DisplayMenu() => System.Console.WriteLine(string.Join("\n", _menuItems.Select(p => $"{p.Index}) {p.Text}")));

    private void ReadOption()
    {
        System.Console.Write("Choose an option: ");
        var keyboard = System.Console.ReadLine();
        _key = (keyboard?.Length != 1)? ' ' : keyboard[0];
        System.Console.WriteLine();
    }

    private void FindSelectedMenuItem() => _selectedMenuItem = _menuItems.SingleOrDefault(p => p.Index == _key - '0', new NullMenuItem());

    private void ExecuteMenuItem() => _quit = _selectedMenuItem.Execute(_configuration);
}