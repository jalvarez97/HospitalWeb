using System.Collections.Generic;

namespace HospitalWeb.Clases
{
    public class Medico : Persona
    {
        public Medico() { }

        public Medico(Persona p, int numcColegiado, string especialidad) : base(p.Nombre, p.Edad, p.Genero, p.DocIdentidad
                                                                               ,p.Email, p.NumTelefono, "Medico")
        {
            NumColegiado = numcColegiado;
            Especialidad = especialidad;
        }

        //Propiedades
        public int NumColegiado { get; set; }
        public string Especialidad { get; set; }

        public List<Paciente> Pacientes = new List<Paciente>();

    }
}