using System;

namespace videojuego
{
    
    public class datos
    {
        private string tipo;
        private string nombre;
        private string apodo;
       // private DateTime fechaNacimiento;
        //private DateTime edad;
        private double salud;

        public string Tipo { get => tipo; set => tipo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apodo { get => apodo; set => apodo = value; }
        //public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        //public DateTime Edad { get => edad; set => edad = value; }
        public double Salud { get => salud; set => salud = value; }

        /*
             List<tarea> misTareas = new List<tarea>();
             string salida = ""; // bandera para salir del ciclo
             int num=0; // para tener un numero q vaya variando para ciertos datos
            do
            {
                System.Console.WriteLine("Ingrese la descripcion de la tarea");
                string descTarea = Console.ReadLine();
                tarea Ntarea = new tarea(); // por cada tarea reservo memoria 
                Ntarea.NombreDeLaTarea = descTarea; // cargo los campos de la tarea q acabo de reservar
                Ntarea.Importancia = num++;
                Ntarea.Fecha = DateTime.Now.AddDays(num);
                Ntarea.Estado = estadoTarea.pendiente; // todas pendiente al comienzo

                misTareas.Add(Ntarea);  //agrego la tarea q acabo de reservar y cargar en mi lista

               Console.WriteLine("Desea ingresar una nueva tarea ? (s/n)");
               salida = Console.ReadLine(); 
                
            } while (salida!="n");
        */

       

           /* void mostrarDatosPersonajes(List<datos> todosLosPersonajesDatos)
            {
                foreach (datos datosPersonajeX in todosLosPersonajesDatos)
                {
                    Console.WriteLine("Tipo: " + datosPersonajeX.tipo);
                    Console.WriteLine("Nombre: " + datosPersonajeX.nombre);
                    Console.WriteLine("Apodo: " + datosPersonajeX.apodo);
                    Console.WriteLine("Fecha de nacimiento: " + datosPersonajeX.fechaNacimiento);
                    Console.WriteLine("Edad: " + datosPersonajeX.edad);
                    Console.WriteLine("Salud = " + datosPersonajeX.salud);
                }
            }
            */
            
    }
    

    public class caracteristicas
    {
        private int velocidad; // 1 a10
        private int destreza; // 1 a 5
        private int fuerza; // 1 a10
        private int nivel; // 1 a10
        private int armadura; // 1 a10

        public int Velocidad { get => velocidad; set => velocidad = value; }
        public int Destreza { get => destreza; set => destreza = value; }
        public int Fuerza { get => fuerza; set => fuerza = value; }
        public int Nivel { get => nivel; set => nivel = value; }
        public int Armadura { get => armadura; set => armadura = value; }
    }


}

