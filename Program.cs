using Newtonsoft.Json;
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
            System.Console.WriteLine("\nGracias por visitarnos, vuelva pronto");
        }

        static public bool ProcesoCursos()
        {
            while (true)
            {
                Console.WriteLine("¿Que desea hacer? \n1- Registrar un nuevo curso \n2- Anotarse a un curso");

                var opcionElegidaInicio = Console.ReadLine();
                Console.Clear();

                while (int.TryParse(opcionElegidaInicio, out _) == false)
                {
                    Console.WriteLine("VALOR INGRESADO INCORRECTO, Ingrese un valor entre 1 y 3");
                }
                if (int.Parse(opcionElegidaInicio) == 1) Curso.RegistrarCurso();
                if (int.Parse(opcionElegidaInicio) == 2)
                {
                    Console.WriteLine("No hay ninguna persona registrada, por favor registrese");
                    Persona.RegistrarPersona();

                    if (Persona.Personas.Count > 0)
                    {
                        Console.Clear();
                        Curso.MostrarCursos();
                        Console.WriteLine("Seleccione el curso al que desea anotarse");
                        Curso cursoElegido;
                        while (true)
                        {
                            var opcionElegidaCurso = Console.ReadLine();
                            if (int.TryParse(opcionElegidaCurso, out var value))
                            {
                                if (value >= 1 && value <= Curso.Cursos.Count)
                                {
                                    cursoElegido = Curso.Cursos[value - 1];
                                    Persona.MostrarPersonas();
                                    Persona personaElegida;
                                    while (true)
                                    {
                                        Console.WriteLine("Seleccione el postulante:");
                                        var opcionElegidaPostulante = Console.ReadLine();
                                        if(int.TryParse(opcionElegidaPostulante, out var value1))
                                        {
                                            if(value1>=1 && value1 <= Persona.Personas.Count)
                                            {
                                                personaElegida = Persona.Personas[value - 1];
                                                DateTime fechaInscripcion = DateTime.Now;
                                                Inscripcion inscripcion = new Inscripcion(personaElegida, cursoElegido, fechaInscripcion);
                                                Inscripcion.Inscripciones.Add(inscripcion);
                                                Console.Clear();
                                                Inscripcion.MostrarInscripcion();
                                                break;
                                            }
                                            else Console.WriteLine("VALOR INGRESADO INCORRECTO, Ingrese un valor mayor a 1 y menor a " + Persona.Personas.Count);
                                        }
                                    }
                                }
                                else Console.WriteLine("VALOR INGRESADO INCORRECTO, Ingrese un valor mayor a 1 y menor a " + GestorCursos.TipoPersonas.Count);
                            }
                        }
                    }
                }

                Console.Clear();
                Console.WriteLine("\nDesea seguir navegando?   \n1- Sí \n2- No");
                var opcionElegidaSeguir = int.Parse(Console.ReadLine());
                Console.Clear();
                if (opcionElegidaSeguir == 1) return false;

                else return true;

            }
        }
    }
    
    public class Docente
    {
        public string NombreDocente { get; set; }
        public string ApellidoDocente { get; set; }
        private string DomicilioDocente { get; set; }
        private string TelefonoDocente { get; set; }
        private string MailDocente { get; set; }
        private string DniDocente { get; set; }
        public string EspecialidadDocente { get; set; }

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

        static public void MostrarDocentes()
        {
            Console.WriteLine("\nLISTA DE DOCENTES:");

            int pos = 1;
            foreach (var docentes in Docentes)
            {
                Console.WriteLine(pos + "-" + docentes.NombreDocente +" "+docentes.ApellidoDocente +" -"+docentes.EspecialidadDocente);
                pos++;
            }
        }
    }

    public class Curso
    {
        public static List<Docente> Docente = new List<Docente>();
        public static List<Curso> Cursos = new List<Curso>();
        public string NombreCurso { get; set; }
        private string DescripcionCurso { get; set; }
        public DateTime FechaInicioCurso { get; set; }
        private DateTime FechaFinalizacionCurso { get; set; }
        private DateTime FechaFinInscripcion { get; set; }
        public string DiasCurso { get; set; }
        public string HorariosCurso { get; set; }
        public int AulaCurso { get; set; }
        private int CupoDisponibleCurso { get; set; }
        private int CupoMinimoCurso { get; set; }
        

    public Curso(string nombreCurso, string descripcionCurso, DateTime fechaInicioCurso, DateTime fechaFinalizacionCurso, DateTime fechaFinInscripcion, string diasCurso, string horariosCurso, int aulaCurso, int cupoDisponibleCurso, int cupoMinimoCurso, List<Docente> docenteCurso)
        {
            NombreCurso = nombreCurso;
            DescripcionCurso = descripcionCurso;
            FechaInicioCurso = fechaInicioCurso;
            FechaFinalizacionCurso = fechaFinalizacionCurso;
            FechaFinInscripcion = fechaFinInscripcion;
            DiasCurso = diasCurso;
            HorariosCurso = horariosCurso;
            AulaCurso = aulaCurso;
            CupoDisponibleCurso = cupoDisponibleCurso;
            CupoMinimoCurso = cupoMinimoCurso;
            Docente = docenteCurso;

        }

        static public void RegistrarCurso()
        {
            Console.WriteLine("\nREGISTRO DE CURSOS");

            Console.WriteLine("\nIngrese el nombre del curso:");
            string nombreCurso = Console.ReadLine();

            Console.WriteLine("\nIngrese a quien está dirigido el curso:");
            string descripcionCurso = Console.ReadLine();

            Console.WriteLine("\nIngrese la fecha de comienzo del curso:");
            DateTime fechaInicioCurso = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("\nIngrese la fecha de finalizacion del curso:");
            DateTime fechaFinalizacionCurso = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("\nIngrese la fecha que finaliza la inscripcion del curso:");
            DateTime fechaFinInscripcion = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("\nIngrese los dias en que se va a dictar el curso:");
            string diasCurso = Console.ReadLine();

            Console.WriteLine("\nIngrese el horario en que se va a dictar el curso:");
            string horariosCurso = Console.ReadLine();

            Console.WriteLine("\nIngrese el numero de aula en que se va a dictar el curso:");
            int aulaCurso = int.Parse(Console.ReadLine());

            Console.WriteLine("\nIngrese el cupo maximo de personas que tiene el curso:");
            int cupoDisponibleCurso = int.Parse(Console.ReadLine());

            Console.WriteLine("\nIngrese el cupo minimo de personas que tiene que tener el curso:");
            int cupoMinimoCurso = int.Parse(Console.ReadLine());

            while (true)
            {
                Console.WriteLine("\nSeleccione el docente que va a dictar el curso:");
                RegistroDocente.MostrarDocentes();
                Docente docenteCurso;

                var opcionElegidaDocente = Console.ReadLine();
                if ((int.TryParse(opcionElegidaDocente, out var value)))
                {
                    if (value >= 1 && value <= RegistroDocente.Docentes.Count)
                    {
                        docenteCurso = RegistroDocente.Docentes[int.Parse(opcionElegidaDocente) - 1];
                        Docente.Add(docenteCurso);

                        Console.WriteLine("\n¿Desea cargar otro docente al curso? \n1-Si \n2-No");
                        var opcionElegidaCargarDocente = Console.ReadLine();
                        Console.Clear();
                       
                        if (int.Parse(opcionElegidaCargarDocente) == 2)
                        {
                            Curso curso = new Curso(nombreCurso,descripcionCurso, fechaInicioCurso, fechaFinalizacionCurso, fechaFinInscripcion, diasCurso, horariosCurso, aulaCurso, cupoDisponibleCurso, cupoMinimoCurso, Docente);
                            Cursos.Add(curso);
                            
                            var cursoJson = JsonConvert.SerializeObject(Cursos, Formatting.Indented);
                            System.IO.File.WriteAllText("Cursos.Json", cursoJson);

                            break;
                        }
                    }
                    else Console.WriteLine("VALOR INGRESADO INCORRECTO, Ingrese un valor mayor a 1 y menor a " + RegistroDocente.Docentes.Count);
                }
            }
        }
        static public void MostrarCursos()
        {
            Console.WriteLine("\n LISTADO DE CURSOS: \n");
            int pos = 1;
            foreach (var cursos in Cursos)
            {
                
                Console.WriteLine("Curso N° " +pos);
                Console.WriteLine("Nombre: "+cursos.NombreCurso);
                Console.WriteLine("Comienza el día " + cursos.FechaInicioCurso);
                Console.WriteLine("Finaliza el día " + cursos.FechaFinalizacionCurso);
                Console.WriteLine("La inscripcion finaliza el día: " + cursos.FechaFinInscripcion);
                Console.WriteLine("El curso es dictado los días " + cursos.DiasCurso);
                Console.WriteLine("El horario en que se dicta el curso es " + cursos.HorariosCurso);
                Console.WriteLine("El curso se dicta en el aula " + cursos.AulaCurso);
                Console.WriteLine("El cupo maximo del curso es " + cursos.CupoDisponibleCurso+" personas");
                Console.WriteLine("El cupo mínimo del curso es " + cursos.CupoMinimoCurso + " personas");
                Console.WriteLine("--------------------------------------");

                pos++;
            }
        }
    }

    public class Inscripcion
    {
        public static List<Inscripcion> Inscripciones = new List<Inscripcion>();
        private DateTime FechaInscripcion { get; set; }
        private Persona Persona { get; set; }
        private Curso Curso { get; set; }

        public Inscripcion(Persona persona, Curso curso, DateTime fechaInscripcion)
        {
            Persona = persona;
            Curso = curso;
            FechaInscripcion = fechaInscripcion;
        }

        static public void MostrarInscripcion()
        {
            foreach(var inscripcion in Inscripciones)
            {
                Console.WriteLine("\nCOMPROBANTE DE INSCRIPCIÓN:");
                Console.WriteLine("Fecha de inscripción: " + inscripcion.FechaInscripcion);
                Console.WriteLine("Nombre del curso: " + inscripcion.Curso.NombreCurso);
                Console.WriteLine("Inicio del curso: " + inscripcion.Curso.FechaInicioCurso);
                Console.WriteLine("Dias que se dicta el curso: " + inscripcion.Curso.DiasCurso);
                Console.WriteLine("Aula en que se dicta el curso: " + inscripcion.Curso.AulaCurso);
                Console.WriteLine("Nombre del postulante: " + inscripcion.Persona.Nombre + " " + inscripcion.Persona.Apellido + " Dni:" + inscripcion.Persona.Dni);
                Console.WriteLine(" ");
            }
            
        }
      
    }

    public class Persona
    {
        public static List<Persona> Personas = new List<Persona>();
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
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

            System.Console.WriteLine("\nSeleccione su categoria:");
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
                        break;
                    }
                    else Console.WriteLine("VALOR INGRESADO INCORRECTO, Ingrese un valor mayor a 1 y menor a " + GestorCursos.TipoPersonas.Count);
                }
            }
        }

        static public void MostrarPersonas()
        {
            Console.WriteLine("\n LISTADO DE POSTULANTES: \n");
            int pos = 1;
            foreach (var personas in Personas)
            {
                
                Console.WriteLine("Persona N°: " + pos);
                Console.WriteLine("Nombre y apellido: " + personas.Nombre +" " +personas.Apellido +" Dni: " +personas.Dni);
                Console.WriteLine("--------------------------------------");

                pos++;
            }
            Console.WriteLine("\n Seleccione el postulante: \n");
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
