
namespace HospitalWeb.Modelos
{
    public class Persona
    {
        public Persona() { }

        public Persona(int id, string nombre, int edad, bool genero,
                       string docIdentidad, string email, int numTelefono, string ocupacion)
        {
            ID = id;
            Nombre = nombre;
            Edad = edad;
            Genero = genero;
            DocIdentidad = docIdentidad;
            Email = email;
            NumTelefono = numTelefono;
            Ocupacion = ocupacion;
            if (Genero)
                Sexo = "Hombre";
            else
                Sexo = "Mujer";
        }

        //propiedades
        public int ID { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Sexo { get; set; }
        public bool Genero { get; set; }
        public string DocIdentidad { get; set; }
        public string Email { get; set; }
        public int NumTelefono { get; set; }
        public string Ocupacion { get; set; }

    }
}