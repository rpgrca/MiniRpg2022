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