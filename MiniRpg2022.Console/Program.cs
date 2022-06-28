using System;
using System.Collections.Generic;

namespace Videogame
{
    class Program
    {
        static void Main (string[] args)
        {
             List<datos> datosPersonajes = new List<datos>();

             cargar(datosPersonajes);

        }

        static void cargar(List <datos> todosLosPersonajesDatos)
        {
            int num = 500;
            string salida = ""; // bandera para salir del ciclo

            do
            {
                num = num - 500;
                Console.WriteLine("Ingrese el tipo del personaje: ");
                string tipo = Console.ReadLine();
                datos NPdatos = new datos(); // por cada personaje reservo memoria para datos del mismo 
                NPdatos.Tipo = tipo;
                Console.WriteLine("Ingrese el nombre del personaje: ");
                string nombre = Console.ReadLine();
                NPdatos.Nombre = nombre;

                Console.WriteLine("Ingrese el apodo del personaje: ");
                string apodo = Console.ReadLine();
                NPdatos.Apodo = apodo;

                /*Console.WriteLine("Ingrese el nombre del personaje: ");
                NPdatos.FechaNacimiento = DateTime.Now.AddDays(num);
                
                DateTime actual = DateTime.UtcNow;
                DateTime tiempodiferencia = actual - NPdatos.fecha;
                NPdatos.Edad = tiempodiferencia;*/

                NPdatos.Salud = 100;

                todosLosPersonajesDatos.Add(NPdatos);

                Console.WriteLine("Desea crear un nuevo personaje ? (s/n)");
                salida = Console.ReadLine(); 

            } while (salida!="n");
        }

    }
    
}