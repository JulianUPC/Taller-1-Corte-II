using Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Archivos
    {
        string lugar = "Liquidacion.txt";
        public void GuardarLiquidacion(Paciente paciente)
        {
            StreamWriter writer = new StreamWriter(lugar, true);
            writer.WriteLine(paciente.ToString());
            writer.Close();
        }

        public Paciente Mapper(string linea)
        {
            var paciente = new Paciente();
            string[] datos = linea.Split(';');
            paciente.N_Liquidacion = datos[0];
            paciente.ID_Paciente = datos[1];
            paciente.Tipo_Afiliacion = bool.Parse(datos[2]);
            paciente.Salario_Devengado = float.Parse(datos[3]);
            paciente.Valor_ServicioPrestado = float.Parse(datos[4]);
            return paciente;
        }

        public List<Paciente> GetAll()
        {
            try
            {
                List<Paciente> pacientes = new List<Paciente>();
                StreamReader reader = new StreamReader(lugar);
                while (!reader.EndOfStream)
                {
                    pacientes.Add(Mapper(reader.ReadLine()));
                }
                reader.Close();
                return pacientes;
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
