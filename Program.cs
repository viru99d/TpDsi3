using System;
using System.Collections.Generic;

namespace TP3
{
    class GestorCursos
    {
        static public List<TipoPersona> TipoPersonas = new List<TipoPersona>();
        static void Main(string[] args)
        {
            TipoPersonas.Add(new TipoPersona("1-Alumno"));
            TipoPersonas.Add(new TipoPersona("2-Docente"));
            TipoPersonas.Add(new TipoPersona("3-Publico en general"));

            while (true)
            {
                var finalizado = ProcesoCursos();

                if (finalizado) break;
            }
        }

        static public bool ProcesoCursos()
        {
            while (true)
            {
                Console.WriteLine("¿Que desea hacer? \n1- Anotarse a un curso \n2- Realizar una cotización");
            }
        }
    }

    public class Docente
    {
        private string NombreDocente { get; set; }
        private string ApellidoDocente { get; set; }
        private string DomicilioDocente { get; set; }
        private string TelefonoDocente { get; set; }
        private string MailDocente { get; set; }
        private string DniDocente { get; set; }
        private string EspecialidadDocente { get; set; }

        public Docente(string nombreDocente, string apellidoDocente, string domicilioDocente, string telefonoDocente, string mailDocente, string dniDocente, string especialidadDocente)
        {
            NombreDocente = nombreDocente;
            ApellidoDocente = apellidoDocente;
            DomicilioDocente = domicilioDocente;
            TelefonoDocente = telefonoDocente;
            MailDocente = mailDocente;
            DniDocente = dniDocente;
            EspecialidadDocente = especialidadDocente;
        }
    }

    public class RegistroDocente
    {
        public static List<Docente> Docentes = new List<Docente>();

        static RegistroDocente()
        {
            Docentes.Add(new Docente("Juan Pablo", "Martinez", "San Francisco", "3564662463", "JuanPablo@Utn.com", "16073613", "Ingeniero en sistemas"));
            Docentes.Add(new Docente("Martin", "Gomez", "Devoto", "3564623212", "Martin@gmail.com", "17720536", "Ingeniero Quimico"));
            Docentes.Add(new Docente("Micaela", "Ramirez", "Cordoba", "351342312", "Micaela@gmail.com", "32324567", "Ingenieria industrial"));
            Docentes.Add(new Docente("Agustina", "Perez", "San Francisco", "3564365432", "Agustina123@gmail.com", "36543987", "Licenciada en economía"));
            Docentes.Add(new Docente("Juan Carlos", "Gonzalez", "Arroyito", "3566432312", "JuanCarlos32@gmail.com", "20876543", "Licenciado  en ciencias políticas"));
        }
    }


    public class Curso
    {
        private string NombreCurso { get; set; }
        private DateTime FechaInicioCurso { get; set; }
        private DateTime FechaFinalizacionCurso { get; set; }
        private DateTime FechaFinInscripcion { get; set; }
        private List<Docente> Docente { get; set; }
        private string DiasCurso { get; set; }
        private string HorariosCurso { get; set; }
        private int AulaCurso { get; set; }
        private int CupoDisponibleCurso { get; set; }
        private int CupoMinimoCurso { get; set; }

        public Curso(string nombreCurso, DateTime fechaInicioCurso, DateTime fechaFinalizacionCurso, DateTime fechaFinInscripcion, List<Docente> docenteCurso, string diasCurso, string horariosCurso, int aulaCurso, int cupoDisponibleCurso, int cupoMinimoCurso)
        {
            NombreCurso = nombreCurso;
            FechaInicioCurso = fechaInicioCurso;
            FechaFinalizacionCurso = fechaFinalizacionCurso;
            FechaFinInscripcion = fechaFinInscripcion;
            Docente = docenteCurso;
            DiasCurso = diasCurso;
            HorariosCurso = horariosCurso;
            AulaCurso = aulaCurso;
            CupoDisponibleCurso = cupoDisponibleCurso;
            CupoMinimoCurso = cupoMinimoCurso;

        }
    }

    public class RegistroCurso
    {
        public static List<Curso> Cursos = new List<Curso>();

        static RegistroCurso()
        {

        }
    }

    public class Inscripcion
    {
        private Persona Persona { get; set; }
        private Curso Curso { get; set; }

        public Inscripcion(Persona persona, Curso curso)
        {
            Persona = persona;
            Curso = curso;
        }
    }

    public class Persona
    {
        public static List<Persona> Personas = new List<Persona>();
        private string Nombre { get; set; }
        private string Apellido { get; set; }
        private string Dni { get; set; }
        private string Email { get; set; }
        private string Telefono { get; set; }
        private TipoPersona TipoPersona { get; set; }

        public Persona(string nombre, string apellido, string dni, string email, string telefono, TipoPersona tipoPersona)
        {
            Nombre = nombre;
            Apellido = apellido;
            Dni = dni;
            Email = email;
            Telefono = telefono;
            TipoPersona = tipoPersona;
        }

        static public void RegistrarPersona()
        {

            Console.WriteLine("\nREGISTRO DE POSTULANTE");

            Console.WriteLine("\nIngrese nombre:");
            string nombre = Console.ReadLine();

            Console.WriteLine("\nIngrese su apellido:");
            string apellido = Console.ReadLine();

            Console.WriteLine("\nIngrese su dni:");
            string dni = Console.ReadLine();

            Console.WriteLine("\nIngrese su email:");
            string email = Console.ReadLine();

            Console.WriteLine("\nIngrese su telefono:");
            string telefono = Console.ReadLine();

            System.Console.WriteLine("\n Seleccione su categoria:");
            TipoPersona.mostrartipoPersona();


            TipoPersona tipoPersona;
            while (true)
            {
                var opcionElegidaTipoPersona = Console.ReadLine();
                if ((int.TryParse(opcionElegidaTipoPersona, out var value)))
                {
                    if (value >= 1 && value <= GestorCursos.TipoPersonas.Count)
                    {
                        tipoPersona = GestorCursos.TipoPersonas[value - 1];
                        Persona persona = new Persona(nombre, apellido, dni, email, telefono, tipoPersona);
                        Personas.Add(persona);
                        Console.WriteLine(tipoPersona.Tipo);
                        break;
                    }
                    else Console.WriteLine("VALOR INGRESADO INCORRECTO, Ingrese un valor mayor a 1 y menor a " + GestorCursos.TipoPersonas.Count);
                }
            }
        }
    }

    public class TipoPersona
    {
        public string Tipo;

        public TipoPersona(string tipo)
        {
            Tipo = tipo;
        }

        static public void mostrartipoPersona()
        {
            foreach (var tipo in GestorCursos.TipoPersonas)
            {
                Console.WriteLine("" + tipo.Tipo);
            }

        }
    }
}
