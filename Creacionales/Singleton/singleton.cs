using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U2_singleton
{

    class Operador
    {
        public int Id_Operador { get; set; }
        public string Nombre { get; set; }
        public Operador(int id, string nombre)
        {
            Id_Operador = id;
            Nombre = nombre;
        }

        public void AtiendeEmergencia(string tipoEmergencia)
        {
            Console.WriteLine($"Operador {Nombre} atendiendo emergencia de tipo: {tipoEmergencia}");

            switch (tipoEmergencia)
            {
                case "Intento de suicidio":
                    Console.WriteLine("Enviando unidades de apoyo y rescate");
                    break;
                case "Incendio":
                    Console.WriteLine("Enviando bomberos.");
                    break;
                case "Accidente":
                    Console.WriteLine("Enviando paramedicos y oficiales.");
                    break;
                case "Violeta":
                    Console.WriteLine("Enviando una patrulla.");
                    break;
                default:
                    Console.WriteLine("Tipo de emergencia no reconocido.");
                    break;
            }
        }
    }

    class Central_911
    {

        private static Central_911 _instance;
        private static readonly object _lock = new object();

        public string Central { get; private set; }

        private Central_911()
        {
            Central = "Central 911";
        }
        public static Central_911 Obtener_Instancia()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Central_911();
                    }

                }
            }
            return _instance;

        }
        public void ConectarLlamada(Operador operador, string tipoEmergencia)
        {
            Console.WriteLine("\nLlamada conectada con el operador " + operador.Nombre);
            operador.AtiendeEmergencia(tipoEmergencia);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Central_911 Llamada1 = Central_911.Obtener_Instancia();
            Central_911 Llamada2 = Central_911.Obtener_Instancia();

            Operador op1 = new Operador(1, "Ivan");
            Operador op2 = new Operador(2, "Esme");
            Operador op3 = new Operador(3, "Lucero");
            Operador op4 = new Operador(4, "Carlos");
            Operador op5 = new Operador(5, "Jovani");
            Operador op6 = new Operador(6, "Maribel");
            Operador op7 = new Operador(7, "Jacob");
            Operador op8 = new Operador(8, "Roberto");
            Operador op9 = new Operador(9, "Lisan al-gaib");
            Operador op10 = new Operador(10, "Hasan");


            Llamada1.ConectarLlamada(op1, "Incendio");
            Llamada2.ConectarLlamada(op2, "Violeta");
            Llamada1.ConectarLlamada(op3, "Accidente");
            Llamada2.ConectarLlamada(op4, "Intento de suicidio");
            Llamada1.ConectarLlamada(op5, "Incendio");
            Llamada2.ConectarLlamada(op6, "Accidente");
            Llamada1.ConectarLlamada(op7, "Violeta");
            Llamada2.ConectarLlamada(op8, "Incendio");
            Llamada1.ConectarLlamada(op9, "Intento de suicidio");
            Llamada2.ConectarLlamada(op10, "Accidente");

            Console.WriteLine("\n¿Es la misma instancia?");
            Console.WriteLine(ReferenceEquals(Llamada1, Llamada2));

            Console.ReadKey();
        }
    }
    
}


