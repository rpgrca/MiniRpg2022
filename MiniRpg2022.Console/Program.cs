using System;
using System.Collections.Generic;
using Videogame;

namespace MiniRpg2022.Console;

class Program
{
    static void Main(string[] args)
    {
        var configuration = new Configuration();
        configuration.RegisterOccupation(new Mage());
        configuration.RegisterOccupation(new Warrior());
        configuration.RegisterOccupation(new Archer());
        configuration.RegisterOccupation(new Thief());

        var item = new LoadMenu();
        item.Execute(configuration);


        List<datos> datosPersonajes = new List<datos>();

        cargar(datosPersonajes);

    }

    static void cargar(List<datos> todosLosPersonajesDatos)
    {
        int num = 500;
        string salida = ""; // bandera para salir del ciclo

        do
        {
            num = num - 500;
            System.Console.WriteLine("Ingrese el tipo del personaje: ");
            string tipo = System.Console.ReadLine();
            datos NPdatos = new datos(); // por cada personaje reservo memoria para datos del mismo 
            NPdatos.Tipo = tipo;
            System.Console.WriteLine("Ingrese el nombre del personaje: ");
            string nombre = System.Console.ReadLine();
            NPdatos.Nombre = nombre;

            System.Console.WriteLine("Ingrese el apodo del personaje: ");
            string apodo = System.Console.ReadLine();
            NPdatos.Apodo = apodo;

            /*Console.WriteLine("Ingrese el nombre del personaje: ");
            NPdatos.FechaNacimiento = DateTime.Now.AddDays(num);
            
            DateTime actual = DateTime.UtcNow;
            DateTime tiempodiferencia = actual - NPdatos.fecha;
            NPdatos.Edad = tiempodiferencia;*/

            NPdatos.Salud = 100;

            todosLosPersonajesDatos.Add(NPdatos);

            System.Console.WriteLine("Desea crear un nuevo personaje ? (s/n)");
            salida = System.Console.ReadLine();

        } while (salida != "n");
    }

}

public class Menu
{

}

public interface IMenuItem
{
    int Index { get; }
    string OptionName { get; }
    bool Execute(Configuration configuration);
}

public class LoadMenu : IMenuItem
{
    public int Index => 1;

    public string OptionName => $"{Index}) Create character";

    public bool Execute(Configuration configuration)
    {
        var occupation = Choose("Please choose an occupation", configuration.GetOccupationNames());
        var name = Prompt("Please name your character", v => string.IsNullOrEmpty(v));
        var nickname = Prompt("Add a nickname for your character", v => v is null);

        return true;
    }

    private static string Choose(string prompt, IEnumerable<string> options)
    {
        string? answer;
        do
        {
            System.Console.Write($"- {prompt} [{string.Join(", ", options)}]: ");
            answer = System.Console.ReadLine();
        }
        while (! options.Contains(answer));

        return answer;
    }

    private static string Prompt(string prompt, Func<string?, bool> conditionCallback)
    {
        string? answer;
        do
        {
            System.Console.Write($"- {prompt}: ");
            answer = System.Console.ReadLine();
        }
        while (conditionCallback(answer));

        return answer;
    }
}