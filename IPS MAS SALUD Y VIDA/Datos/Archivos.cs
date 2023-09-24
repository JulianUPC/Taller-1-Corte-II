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
        string lugar_RC = "Liquidacion Régimen Contributivo.txt";
        string lugar_RS = "Liquidacion Régimen Subsidiado.txt";
        public void GuardarLiquidacion(Paciente paciente)
        {
            StreamWriter writer = new StreamWriter(lugar, true);
            writer.WriteLine(paciente.ToString());
            writer.Close();
        }
        public void GuardarLiquidacionRC(Régimen_contributivo régimen_Contributivo)
        {
            StreamWriter writer = new StreamWriter(lugar_RC, true);
            writer.WriteLine(régimen_Contributivo.ToString());
            writer.Close();
        }
        public void GuardarLiquidacionRS(Régimen_Subsidiado régimen_Subsidiado)
        {
            StreamWriter writer = new StreamWriter(lugar_RS, true);
            writer.WriteLine(régimen_Subsidiado.ToString());
            writer.Close();
        }
        
        public Paciente Mapper(string linea)
        {
            var paciente = new Paciente();
            string[] datos = linea.Split(';');
            paciente.N_Liquidacion = datos[0];
            paciente.F_Liquidacion = DateTime.Parse(datos[1]);
            paciente.ID_Paciente = datos[2];
            paciente.Nombre_Paciente = datos[3];
            paciente.Tipo_Afiliacion = datos[4];
            paciente.Salario_Devengado = float.Parse(datos[5]);
            paciente.Valor_ServicioPrestado = int.Parse(datos[6]);
            return paciente;
        }
        public Régimen_contributivo Mapper_RC(string linea)
        {
            var régimen_Contributivo = new Régimen_contributivo();
            string[] datos = linea.Split(';');
            régimen_Contributivo.N_Liquidacion = datos[0];
            régimen_Contributivo.Cuota_ModeradaContributivo = float.Parse(datos[1]);
            régimen_Contributivo.Cuota_Real = float.Parse(datos[2]);
            régimen_Contributivo.Tarifa_Aplicada = float.Parse(datos[3]);
            régimen_Contributivo.Tope_Maximo = datos[4];
            return régimen_Contributivo;
        }
        public Régimen_Subsidiado Mapper_RS(string linea)
        {
            var régimen_Subsidiado = new Régimen_Subsidiado();
            string[] datos = linea.Split(';');
            régimen_Subsidiado.N_Liquidacion = datos[0];
            régimen_Subsidiado.Cuota_ModeradaSubsidiado = float.Parse(datos[1]);
            régimen_Subsidiado.Cuota_Real = float.Parse(datos[2]);
            régimen_Subsidiado.Tarifa_Aplicada = float.Parse(datos[3]);
            régimen_Subsidiado.Tope_Maximo = datos[4];
            return régimen_Subsidiado;
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
        public List<Régimen_contributivo> GetAll_RC()
        {
            try
            {
                List<Régimen_contributivo> régimen_Contributivos = new List<Régimen_contributivo>();
                StreamReader reader = new StreamReader(lugar_RC);
                while (!reader.EndOfStream)
                {
                    régimen_Contributivos.Add(Mapper_RC(reader.ReadLine()));
                }
                reader.Close();
                return régimen_Contributivos;
            }
            catch (Exception)
            {

                return null;
            }
        }
        public List<Régimen_Subsidiado> GetAll_RS()
        {
            try
            {
                List<Régimen_Subsidiado> régimen_Subsidiados = new List<Régimen_Subsidiado>();
                StreamReader reader = new StreamReader(lugar_RS);
                while (!reader.EndOfStream)
                {
                    régimen_Subsidiados.Add(Mapper_RS(reader.ReadLine()));
                }
                reader.Close();
                return régimen_Subsidiados;
            }
            catch (Exception)
            {

                return null;
            }
        }

    }
}
