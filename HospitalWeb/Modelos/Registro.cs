using System.Collections.Generic;

namespace HospitalWeb.Modelos
{
    public static class Registro
    {     
        public static List<Persona> Personas = new List<Persona>();
        public static List<Medico> Medicos = new List<Medico>();
        public static List<Paciente> Pacientes = new List<Paciente>();

        public static void GenerarRegistros()
        {
            Automatizacion oAutomatiza = new Automatizacion();
            Medicos.AddRange(oAutomatiza.GenerarMedicos(100));
            Pacientes.AddRange(oAutomatiza.GenerarPacientes(1000, Medicos, Medicos.Count));
            Personas.AddRange(Medicos);
            Personas.AddRange(Pacientes);
        }
    }
}