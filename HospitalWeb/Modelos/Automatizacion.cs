using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalWeb.Modelos
{
    public class Automatizacion
    {
        //Datos para generar médicos sin rellenar personas automaticamente
        //e ingresar y asignar pacientes por cada médico de forma aleatoria

        private List<string> lstNombrOcupacionsHombre = new List<string>() { "Pascal","Jhonny", "Samu", "Javi"
                                                                       , "Alex", "Saul", "Wintop", "Manu"
                                                                       , "Oscar", "Joel", "Alejandro", "Alvaro"
                                                                       , "Pol", "Josepe", "Salva"};

        private List<string> lstNombrOcupacionsMujer = new List<string>()  { "Ana","Eva", "Sofia", "Jennifer"
                                                                    , "Melody", "Alexandra", "Sonia", "Sofia"
                                                                    , "Nayara", "Lucia", "Maria", "Susana"
                                                                    , "Laura", "Judith", "Raquel"};

        private List<string> lstEspecialidades = new List<string>() { "Oncologia", "Traumatologia", "Urgencias", "Cardiologia" };

        private List<string> lstEnfermedades = new List<string>() { "Resfriado", "Gastroenteritis", "Venezuelanitis", "Calvitis", "Cirrosis" };

        private Random rnd = new Random();

        public List<Medico> GenerarMedicos(int generar)
        {
            List<Medico> lstMedicos = new List<Medico>();

            Persona oPersona;
            Medico oMedico;

            for (int i = 0; i < generar; i++)
            {
                int nNombreMedico = rnd.Next(0, 14);
                int nDecididor = rnd.Next(0, 1000);
               

                if (nDecididor % 2 == 0)                
                {
                    string sNombre = lstNombrOcupacionsHombre[nNombreMedico];
                    oPersona = new Persona(i,sNombre, rnd.Next(18, 45), true
                                          , rnd.Next(23401238, 777777777) + "M", sNombre + nNombreMedico + "@gmail.com", rnd.Next(638723799, 722999999), "");

                    oMedico = new Medico(oPersona, rnd.Next(1000, 2500), lstEspecialidades[rnd.Next(0, 3)]);
                }
                else
                {
                    string sNombre = lstNombrOcupacionsMujer[nNombreMedico];
                    oPersona = new Persona(i,sNombre, rnd.Next(18, 45), false
                                          , rnd.Next(23401238, 777777777) + "W", sNombre + nNombreMedico + "@gmail.com", rnd.Next(638723799, 722999999), "");

                    oMedico = new Medico(oPersona, rnd.Next(2500, 4000), lstEspecialidades[rnd.Next(0, 3)]);
                }

                lstMedicos.Add(oMedico);
            }

            return lstMedicos;
        }

        public List<Paciente> GenerarPacientes(int generar, List<Medico> lstMedico, int id)
        {
            List<Paciente> lstPacientes = new List<Paciente>();
            Persona oPersona;
            Paciente oPaciente;

            for (int x = 0; x < generar; x++)
            {
                int nNombreMedico = rnd.Next(0, 14);
                int nDecididor = rnd.Next(0, 1000);
                
                if (nDecididor % 2 == 0)
                {
                    string sNombre = lstNombrOcupacionsHombre[nNombreMedico];
                    oPersona = new Persona(id,sNombre, rnd.Next(18, 45), true
                                          , rnd.Next(23401238, 777777777) + "M", sNombre+ nNombreMedico+"@gmail.com", rnd.Next(638723799, 722999999), "");

                    oPaciente = new Paciente(oPersona, lstEnfermedades[rnd.Next(0, 4)], "Ibuprofeno");
                }
                else
                {
                    string sNombre = lstNombrOcupacionsMujer[nNombreMedico];
                    oPersona = new Persona(id,sNombre, rnd.Next(18, 45), false
                                          , rnd.Next(23401238, 777777777) + "W", sNombre + nNombreMedico + "@gmail.com", rnd.Next(638723799, 722999999), "");

                    oPaciente = new Paciente(oPersona, lstEnfermedades[rnd.Next(0, 4)], "Ibuprofeno");
                }

                oPaciente.MedicoAsignado = lstMedico[rnd.Next(0, lstMedico.Count - 1)].NumColegiado;
                lstPacientes.Add(oPaciente);
                id++;
            }

            return lstPacientes;
        }

    }
}