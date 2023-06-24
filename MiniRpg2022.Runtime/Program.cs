using Videogame;
using MiniRpg2022.Console;

namespace MiniRpg2022.Runtime;

class Program
{
    static void Main(string[] args)
    {
        var configuration = new Configuration(2022, 6, 28, new Messaging(new Console.Console()));

        configuration.RegisterOccupation(new Mage());
        configuration.RegisterOccupation(new Warrior());
        configuration.RegisterOccupation(new Archer());
        configuration.RegisterOccupation(new Thief());

        configuration.RegisterProperty(new("speed", 1, 10));
        configuration.RegisterProperty(new("dexterity", 1, 5));
        configuration.RegisterProperty(new("strength", 1, 10));
        configuration.RegisterProperty(new("level", 1, 10));
        configuration.RegisterProperty(new("armour", 1, 10));

        configuration.RegisterName("Raistlin Majere");
        configuration.RegisterName("Tanis Half-Elven");
        configuration.RegisterName("Sturm Brightblade");
        configuration.RegisterName("Goldmoon");


        var menu = new Menu(configuration);
        menu.Execute();

/*
        List<datos> datosPersonajes = new List<datos>();

        cargar(datosPersonajes);*/

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