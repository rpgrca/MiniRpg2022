
using MiniRpg2022.Console;
using Videogame;

namespace MiniRpg2022.Console.UnitTests;

public static class Constants
{
    public static Configuration ObtainConfiguration(IConsole stub) =>
        new(2022, 11, 30, new Messaging(stub));
}