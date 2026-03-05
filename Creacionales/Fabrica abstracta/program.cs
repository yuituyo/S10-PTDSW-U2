using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U2_PTDW
{

    public abstract class MaterialFactory
    {
        public abstract Guia CrearGuia();
        public abstract Examen CrearExamen();
    }


    public abstract class Guia
    {
        public abstract void Mostrar();
    }

    public abstract class Examen
    {
        public abstract void Aplicar();
    }


    public class GuiaImpresa : Guia
    {
        public override void Mostrar()
        {
            Console.WriteLine("Mostrando la guia impresa");
        }
    }

    public class ExamenEnPapel : Examen
    {
        public override void Aplicar()
        {
            Console.WriteLine("Se aplica examen en papel");

        }

    }

    public class GuiaPDF : Guia
    {
        public override void Mostrar()
        {
            Console.WriteLine("Mostrando la guia en pdf");
        }
    }

    public class ExamenOnline : Examen
    {

        public override void Aplicar()
        {
            Console.WriteLine("Se aplica examen en linea");
        }
    }


    public class GuiaHibrida : Guia
    {
        public override void Mostrar()
        {
            Console.WriteLine("Guía en Modalidad Híbrida (semipresencial)");
        }
    }

    public class ExamenHibrido : Examen
    {
        public override void Aplicar()
        {
            Console.WriteLine("Se aplica Examen Mixto");
        }
    }


    public class MaterialImpresoFactory : MaterialFactory
    {
        public override Guia CrearGuia()
        {
            return new GuiaImpresa();
        }

        public override Examen CrearExamen()
        {
            return new ExamenEnPapel();
        }
    }

    public class MaterialDigitalFactory : MaterialFactory
    {
        public override Guia CrearGuia()
        {
            return new GuiaPDF();
        }

        public override Examen CrearExamen()
        {
            return new ExamenOnline();
        }
    }


    public class MaterialHibridoFactory : MaterialFactory
    {
        public override Guia CrearGuia()
        {
            return new GuiaHibrida();
        }

        public override Examen CrearExamen()
        {
            return new ExamenHibrido();
        }
    }


    internal class Program
    {


        static void Main(string[] args)
        {
            MaterialFactory fabrica;
            
            int terminar = 1;

            while (terminar != 0)
            {
                Console.WriteLine("1. Material Impreso");
                Console.WriteLine("2. Material Digital");
                Console.WriteLine("3. Material Hibrido");
                Console.WriteLine("Si quiere terminar inserte 0");
                Console.WriteLine("Seleccione una opción de 0 a 3.....");

                terminar = int.Parse(Console.ReadLine());

                fabrica = null;

                switch (terminar)
                {
                    default:
                        Console.WriteLine("Inserte valor valido");
                        break;

                    case 1:
                        fabrica = new MaterialImpresoFactory();
                        break;

                    case 2:
                        fabrica = new MaterialDigitalFactory();
                        break;

                    case 3:
                        fabrica = new MaterialHibridoFactory();
                        break;

                    case 0:
                        return;
                        
                }

                if (fabrica != null)
                {
                    Guia guia = fabrica.CrearGuia();
                    Examen examen = fabrica.CrearExamen();

                    guia.Mostrar();
                    examen.Aplicar();
                }

                Console.ReadKey();
                Console.Clear();
            }


        }

    }
}
