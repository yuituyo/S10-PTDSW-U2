using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U2_Protype
{
    public abstract class Examen
    {
        protected string Materia;
        protected string Modalidad;
        protected int Cantidad_preguntas;
        protected int Aciertos;
        protected string Maestro;
        protected string Alumno;
        protected string Salon;
        protected float Ponderacion;

        public string materia { set => Materia = value; }
        public string modalidad { set => Modalidad = value; }
        public int cantidad_preguntas { set => Cantidad_preguntas = value; }
        public int aciertos { set => Aciertos = value; }
        public string maestro { set => Maestro = value; }
        public string alumno { set => Alumno = value; }
        public string salon { set => Salon = value; }

        public float ponderacion { set => Ponderacion = value; }

        public abstract Examen Clonar();
        public abstract string Evaluar();
        public abstract string VerClase();
        public abstract void MostrarExamen();
    }


    public class Examenfisica : Examen
    {
        public override Examen Clonar()
        {
            return (Examenfisica)this.MemberwiseClone();
        }

        public override string Evaluar()
        {
            float resultado = (Aciertos / (float)Cantidad_preguntas) * Ponderacion;
            return $"El resultado del examen de {Materia} es: {resultado}";
        }

        public override string VerClase()
        {
            return $"Esta es la clase de {Materia} con el Maestr@: {Maestro}.";
        }

        public override void MostrarExamen()
        {
            Console.WriteLine($"Materia: {Materia}");
            Console.WriteLine($"Modalidad: {Modalidad}");
            Console.WriteLine($"Cantidad de preguntas: {Cantidad_preguntas}");
            Console.WriteLine($"Aciertos: {Aciertos}");
            Console.WriteLine($"Maestro: {Maestro}");
            Console.WriteLine($"Alumno: {Alumno}");
            Console.WriteLine($"Salón: {Salon}");
            Console.WriteLine($"Ponderación: {Ponderacion}");
        }
    }

    public class Examenmatematicas : Examen
    {
        public override Examen Clonar()
        {
            return (Examenmatematicas)this.MemberwiseClone();
        }
        
        public override string Evaluar()
        {
            float resultado = (Aciertos / (float)Cantidad_preguntas) * Ponderacion;
            return $"El resultado del Examen matematicas con clave {Materia} es: {resultado}";
        }

        public override string VerClase()
        {
            return $"Esta es la clase de {Materia} con el Maestr@: {Maestro}.";
        }

        public override void MostrarExamen()
        {
            Console.WriteLine($"Materia: {Materia}");
            Console.WriteLine($"Modalidad: {Modalidad}");
            Console.WriteLine($"Cantidad de preguntas: {Cantidad_preguntas}");
            Console.WriteLine($"Aciertos: {Aciertos}");
            Console.WriteLine($"Maestro: {Maestro}");
            Console.WriteLine($"Alumno: {Alumno}");
            Console.WriteLine($"Salón: {Salon}");
            Console.WriteLine($"Ponderación: {Ponderacion}");
        }
    }

    public class ExamenProgramacion : Examen
    {
        public override Examen Clonar() => (ExamenProgramacion)this.MemberwiseClone();

        public override string Evaluar()
        {
            float resultado = (Aciertos / (float)Cantidad_preguntas) * Ponderacion;
            return $"[Code Review] El puntaje final en {Materia} es: {resultado}";
        }

        public override string VerClase() => $"Laboratorio de {Materia} a cargo de: {Maestro}.";

        public override void MostrarExamen()
        {
            Console.WriteLine("--- EXAMEN DE PROGRAMACIÓN ---");
            Console.WriteLine($"Estudiante: {Alumno} | Materia: {Materia} | Aciertos: {Aciertos}/{Cantidad_preguntas}");
        }
    }

    public class ExamenHistoria : Examen
    {
        public override Examen Clonar() => (ExamenHistoria)this.MemberwiseClone();

        public override string Evaluar()
        {
            float resultado = (Aciertos / (float)Cantidad_preguntas) * Ponderacion;
            return $"Análisis histórico de {Materia} completado. Nota: {resultado}";
        }

        public override string VerClase() => $"Sesión teórica de {Materia}. Docente: {Maestro}.";

        public override void MostrarExamen()
        {
            Console.WriteLine($"--- Reporte de Historia: {Materia} ---");
            Console.WriteLine($"Alumno: {Alumno} | Salón: {Salon} | Nota Final: {Aciertos}");
        }
    }

    public class ExamenQuimica : Examen
    {
        public override Examen Clonar() => (ExamenQuimica)this.MemberwiseClone();

        public override string Evaluar()
        {
            float resultado = (Aciertos / (float)Cantidad_preguntas) * Ponderacion;
            return $"Resultado del laboratorio de {Materia}: {resultado}";
        }

        public override string VerClase() => $"Clase de {Materia} (Maestro: {Maestro}) en el laboratorio químico.";

        public override void MostrarExamen()
        {
            Console.WriteLine($"EXAMEN QUÍMICO - Materia: {Materia}");
            Console.WriteLine($"Aciertos: {Aciertos} | Ponderación: {Ponderacion}");
        }
    }

    public class ExamenLiteratura : Examen
    {
        public override Examen Clonar() => (ExamenLiteratura)this.MemberwiseClone();

        public override string Evaluar()
        {
            float resultado = (Aciertos / (float)Cantidad_preguntas) * Ponderacion;
            return $"La calificación del análisis literario en {Materia} es: {resultado}";
        }

        public override string VerClase() => $"Cátedra de {Materia} con el Prof. {Maestro}.";

        public override void MostrarExamen()
        {
            Console.WriteLine($"Evaluación de Literatura: {Materia}");
            Console.WriteLine($"Alumno: {Alumno} | Modalidad: {Modalidad}");
        }
    }


    public class ExamenIngles : Examen
    {
        public override Examen Clonar() => (ExamenIngles)this.MemberwiseClone();

        public override string Evaluar()
        {
            float resultado = (Aciertos / (float)Cantidad_preguntas) * Ponderacion;
            return $"English Test Score ({Materia}): {resultado}";
        }

        public override string VerClase() => $"Language Class: {Materia} with Teacher: {Maestro}.";

        public override void MostrarExamen()
        {
            Console.WriteLine($"--- English Department ---");
            Console.WriteLine($"Subject: {Materia} | Student: {Alumno} | Score: {Aciertos}");
        }
    }

    public class ExamenGeografia : Examen
    {
        public override Examen Clonar() => (ExamenGeografia)this.MemberwiseClone();

        public override string Evaluar()
        {
            float resultado = (Aciertos / (float)Cantidad_preguntas) * Ponderacion;
            return $"Resultado del examen cartográfico de {Materia}: {resultado}";
        }

        public override string VerClase() => $"Explorando {Materia} con el guía: {Maestro}.";

        public override void MostrarExamen()
        {
            Console.WriteLine($"--- Examen de Geografía ---");
            Console.WriteLine($"Materia: {Materia} | Salón: {Salon} | Aciertos: {Aciertos}");
        }
    }

    internal class Program
        {
            static void Main(string[] args)
            {
            // --- 1. CONFIGURACIÓN DE PLANTILLAS (PROTOTIPOS) ---
            // Definimos los datos generales de cada materia una sola vez.

            var prototipoFisica = new Examenfisica { materia = "Física I", maestro = "Dr. Einstein", cantidad_preguntas = 10, ponderacion = 100, salon = "Lab A" };
            var prototipoMate = new Examenmatematicas { materia = "Cálculo", maestro = "Mtro. Newton", cantidad_preguntas = 15, ponderacion = 100, salon = "Aula 101" };
            var prototipoProg = new ExamenProgramacion { materia = "C# Avanzado", maestro = "Ing. Turing", cantidad_preguntas = 20, ponderacion = 100, salon = "Centro de Cómputo" };
            var prototipoHist = new ExamenHistoria { materia = "Historia", maestro = "Dra. Lynch", cantidad_preguntas = 10, ponderacion = 10, salon = "Aula 202" };
            var prototipoQuim = new ExamenQuimica { materia = "Química", maestro = "Prof. Mendeleev", cantidad_preguntas = 12, ponderacion = 100, salon = "Lab Químico" };
            var prototipoLit = new ExamenLiteratura { materia = "Literatura", maestro = "Lic. Cervantes", cantidad_preguntas = 8, ponderacion = 10, salon = "Biblioteca" };
            var prototipoIng = new ExamenIngles { materia = "English IV", maestro = "Ms. Smith", cantidad_preguntas = 50, ponderacion = 100, salon = "Aula 303" };
            var prototipoGeo = new ExamenGeografia { materia = "Geografía", maestro = "Prof. Humboldt", cantidad_preguntas = 15, ponderacion = 10, salon = "Aula 105" };

            // --- 2. CREACIÓN DE EXÁMENES INDIVIDUALES (CLONACIÓN) ---
            // Aquí es donde ocurre la magia: clonamos y solo cambiamos lo necesario.

            List<Examen> listaExamenes = new List<Examen>();


            Examen e1 = prototipoFisica.Clonar();
            e1.alumno = "Carlos Slim"; e1.aciertos = 9; e1.modalidad = "Presencial";
            listaExamenes.Add(e1);


            Examen e2 = prototipoMate.Clonar();
            e2.alumno = "Ana Lovelace"; e2.aciertos = 15; e2.modalidad = "Virtual";
            listaExamenes.Add(e2);


            Examen e3 = prototipoProg.Clonar();
            e3.alumno = "Bill Gates"; e3.aciertos = 20; e3.modalidad = "Presencial";
            listaExamenes.Add(e3);


            Examen e4 = prototipoHist.Clonar();
            e4.alumno = "Juana de Arco"; e4.aciertos = 7; e4.modalidad = "Escrito";
            listaExamenes.Add(e4);


            Examen e5 = prototipoQuim.Clonar();
            e5.alumno = "Marie Curie"; e5.aciertos = 12; e5.modalidad = "Práctico";
            listaExamenes.Add(e5);


            Examen e6 = prototipoLit.Clonar();
            e6.alumno = "Jorge L. Borges"; e6.aciertos = 8; e6.modalidad = "Ensayo";
            listaExamenes.Add(e6);


            Examen e7 = prototipoIng.Clonar();
            e7.alumno = "William Shakespeare"; e7.aciertos = 48; e7.modalidad = "Oral";
            listaExamenes.Add(e7);


            Examen e8 = prototipoGeo.Clonar();
            e8.alumno = "Marco Polo"; e8.aciertos = 13; e8.modalidad = "Presencial";
            listaExamenes.Add(e8);


            Console.WriteLine("=================================================");
            Console.WriteLine("   REPORTE GENERAL DE EXÁMENES DE LA SEMANA");
            Console.WriteLine("=================================================\n");

            foreach (var examen in listaExamenes)
            {
                Console.WriteLine(examen.VerClase());
                examen.MostrarExamen();
                Console.WriteLine(examen.Evaluar());
                Console.WriteLine(new string('-', 50));
            }

            Console.WriteLine("\nProceso finalizado. Presione cualquier tecla...");
            Console.ReadKey();
        }
        }
    }

