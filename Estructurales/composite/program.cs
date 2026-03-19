using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composito
{
    public abstract class Componente
    {
        string _nombre;
        public Componente(string nombre)
        {
            _nombre = nombre;
        }
        public string Nombre
        {
            get { return _nombre; }
        }
        public abstract void AgregarHijo(Componente c);
        public abstract IList<Componente> ObtenerHijo();
        public abstract int ObtenerTamaño { get; }
    }


    public class Directorio : Componente
    {
        private List<Componente> _hijos;
        public Directorio(String nombre) : base(nombre)
        {
            _hijos = new List<Componente>();
        }
        public override void AgregarHijo(Componente c)
        {
            _hijos.Add(c);
        }
        public override IList<Componente> ObtenerHijo()
        {
            return _hijos.ToArray();
        }
        public override int ObtenerTamaño
        {
            get
            {
                int t = 0;
                foreach (var item in _hijos)
                {
                    t += item.ObtenerTamaño;
                }
                return t;
            }
        }
    }

    public class Archivo : Componente
    {
        int _tamaño;
        public Archivo(String nombre, int tamaño) : base(nombre)
        {
            _tamaño = tamaño;
        }
        public int Tamaño { get { return _tamaño; } }
        public override void AgregarHijo(Componente c)
        {
        }
        public override IList<Componente> ObtenerHijo()
        {
            return null;
        }
        public override int ObtenerTamaño
        {
            get { return _tamaño; }
        }
    }

    internal class Program
    {

        static void Main(string[] args)
        {

            Componente[] paquetes = {
                CrearPaquete("Básico", 100, 50, 200, 80),
                CrearPaquete("Intermedio", 200, 100, 400, 160),
                CrearPaquete("Alto", 300, 150, 600, 300)
             };

            Console.WriteLine("----Seleccione un paquete----");

            for (int i = 0; i < paquetes.Length; i++)
                Console.WriteLine($"{i + 1}. {paquetes[i].Nombre}");

            if (!int.TryParse(Console.ReadLine(), out int opcion) || opcion < 1 || opcion > 3) return;

            Componente seleccionado = paquetes[opcion - 1];

            List<Componente> carrito = new List<Componente>();

            int total = 0;

            foreach (Componente cat in seleccionado.ObtenerHijo())
            {
                IList<Componente> opciones = cat.ObtenerHijo();
                Console.WriteLine($"\n{cat.Nombre}:");


                for (int i = 0; i < opciones.Count; i++)
                    Console.WriteLine($"{i + 1}. {opciones[i].Nombre} (${opciones[i].ObtenerTamaño})");


                if (int.TryParse(Console.ReadLine(), out int sel) && sel > 0 && sel <= opciones.Count)
                {
                    Componente elegido = opciones[sel - 1];
                    carrito.Add(elegido);
                    total += elegido.ObtenerTamaño;
                }
            }

            Console.WriteLine($"\nRESUMEN: {seleccionado.Nombre}");
            
            foreach (Componente c in carrito)
                Console.WriteLine($"{c.Nombre}: ${c.ObtenerTamaño}");

            Console.WriteLine($"TOTAL: ${total}");
            Console.ReadKey();

            Componente CrearPaquete(string n, int m, int r, int c, int d)
            {
                Componente p = new Directorio(n);
                Agregar(p, "Monitor", m, "LG", "HP", "Dell");
                Agregar(p, "RAM", r, "Samsung", "Kingston", "Crucial");
                Agregar(p, "CPU", c, "Intel", "AMD", "Ryzen");
                Agregar(p, "Disco", d, "Samsung", "WD", "Seagate");
                return p;
            }

            void Agregar(Componente p, string cat, int baseP, string m1, string m2, string m3)
            {
                Componente dir = new Directorio(cat);
                dir.AgregarHijo(new Archivo(m1, baseP));
                dir.AgregarHijo(new Archivo(m2, baseP + 20));
                dir.AgregarHijo(new Archivo(m3, baseP + 40));
                p.AgregarHijo(dir);
            }

        }
    }
}
