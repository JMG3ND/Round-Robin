using System;
using System.Collections.Generic;

namespace Round_Robin
{
    class Program
    {
        static List<Proceso> procesos = new List<Proceso>();
        public static int quantum;
        public static void Ingreso_de_procesos()
        {
            nuevo:
            Proceso proceso = new Proceso();
            if (proceso.Nombre != "-")
            {
                procesos.Add(proceso);
                goto nuevo;
            }
        }

        static void Main(string[] args)
        {
            

            Console.Write("\t\tPlanificación de procesos\n\nIntroduzca la unidad de Quantum\n\nQuantum: ");
            reinentar:
            try
            {
                quantum = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.CursorLeft = 9;
                Console.CursorTop--;
                Console.Write("                                          ");
                Console.CursorLeft = 9;
                goto reinentar;
            }

            Console.WriteLine("\n\nEscriba (-) en nombre para dejar de agregar\n\n");
            Console.WriteLine("Introduzca los procesos por orden de llegada: ");

            Ingreso_de_procesos();
            Console.WriteLine("\nIniciación de ejecución de procesos");
            procesamiento();
        }

        static void procesamiento()
        {
            while (procesos.Count != 0)
            {
                for (int x = 0; x < procesos.Count; x++)
                {
                    Console.WriteLine("Proceso: " + procesos[x].Nombre + "| Ráfaga: " + procesos[x].Rafagas + " - " + quantum + " = " + procesos[x].Calculo);
                    procesos[x].Rafagas -= quantum;
                    if (procesos[x].Rafagas <= 0)
                    {
                        Console.WriteLine("\n----------El proceso " + procesos[x].Nombre + " a finalizado----------");
                        procesos.RemoveAt(x);
                        x--;
                    }
                    Console.Write("\n");
                }
            }
            Console.WriteLine("----------Tódo los procesos han finalizado----------\n");
        }
    }

    public class Proceso
    {
        public string Nombre { get; set; }
        public int Rafagas { get; set; }
        public int Calculo { get { return (Rafagas - Program.quantum < 0) ? 0 : Rafagas - Program.quantum; } }
        

        public Proceso()
        {
            Console.Write("Nombre: ");
            this.Nombre = Console.ReadLine();
            if(this.Nombre != "-")
            {
                Rafagas = 0;
                Console.Write("Rafagas: ");
            reintentar:
                try
                {
                    Rafagas = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.CursorLeft = 9;
                    Console.CursorTop--;
                    Console.Write("                                          ");
                    Console.CursorLeft = 9;
                    goto reintentar;
                }
            }
        }
    }
}
