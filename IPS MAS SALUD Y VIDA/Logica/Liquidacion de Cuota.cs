using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Liquidacion_de_Cuota
    {
        Paciente paciente = new Paciente();
        Archivos archivos = new Archivos();
        List<Paciente> pacientes;
        List<Régimen_contributivo> contributivos;
        List<Régimen_Subsidiado> subsidiados;

        public Liquidacion_de_Cuota()
        {
            Refresh();
        }

        public void GuardarLiquidacion(Paciente paciente, Régimen_contributivo régimen_Contributivo, Régimen_Subsidiado régimen_Subsidiado)
        {
            bool encontrado = false;
            try
            {
                if (paciente != null)
                {
                    if (pacientes == null)
                    {
                        archivos.GuardarLiquidacionRC(régimen_Contributivo);
                        archivos.GuardarLiquidacionRS(régimen_Subsidiado);
                        archivos.GuardarLiquidacion(paciente);
                    }
                    else
                    {
                        foreach (var item in pacientes)
                        {

                            if (paciente.ID_Paciente == item.ID_Paciente)
                            {                               
                                encontrado = true;
                                Console.SetCursorPosition(10, 20); Console.WriteLine("El paciente que intenta registrar ya se existe");
                            }
                        }
                        if (encontrado == false)
                        {
                            archivos.GuardarLiquidacionRC(régimen_Contributivo);
                            archivos.GuardarLiquidacionRS(régimen_Subsidiado);
                            archivos.GuardarLiquidacion(paciente);
                            Console.SetCursorPosition(10, 20); Console.WriteLine("Registro realizado con exito...");                        
                        }
                    }
                }
                else
                {
                    Console.WriteLine("informacion no puede ser nulo");
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Error al guardar informacion");
            }
        }
        bool encontrado = false;
        public void Eliminar_RegimenC(string N_Liquidacion)
        {
            try
            {
                foreach (var itemRC in GetAll_RC())
                {
                    if (N_Liquidacion == itemRC.N_Liquidacion)
                    {
                        contributivos.Remove(itemRC);
                        archivos.Eliminar_RegimenC(contributivos);
                        Console.WriteLine("regimen eliminado correctamente");
                    }
                }
            }
            catch (Exception)
            {

            }
        }
        public void Eliminar_RegimenS(string N_Liquidacion)
        {
            try
            {
                foreach (var itemRS in GetAll_RS())
                {
                    if (N_Liquidacion == itemRS.N_Liquidacion)
                    {
                        subsidiados.Remove(itemRS);
                        archivos.Eliminar_RegimenS(subsidiados);
                    }
                }
            }
            catch (Exception)
            {

            }
        }
        public void Eliminar_Paciente(string N_Liquidacion)
        {
            
            try
            {
                foreach (var item in GetAll())
                {
                    if (N_Liquidacion == item.N_Liquidacion)
                    {
                        pacientes.Remove(item);
                        archivos.EliminarPaciente(pacientes);
                        Console.WriteLine("paciente eliminado correctamente");
                    }                 
                }
                if (encontrado == false)
                {
                    Console.WriteLine("Establecimiento no existe");
                }
                
            }       
            catch(Exception)
            {
                return;
            }
        }

        void Refresh()
        {
            try
            {
                pacientes = archivos.GetAll();
            }
            catch (Exception)
            {

            }
        }
        void Refresh_RC()
        {
            try
            {
                contributivos = archivos.GetAll_RC();
            }
            catch (Exception)
            {

            }
        }

        void Refresh_RS()
        {
            try
            {
                subsidiados = archivos.GetAll_RS();
            }
            catch (Exception)
            {

            }
        }

        public List<Paciente> GetAll()
        {
            Refresh();
            if (pacientes == null)
            {
                return null;
            }

            return pacientes;
        }

        public List<Régimen_contributivo> GetAll_RC()
        {
            Refresh_RC();
            if (contributivos == null)
            {
                return null;
            }

            return contributivos;
        }

        public List<Régimen_Subsidiado> GetAll_RS()
        {
            Refresh_RS();
            if (subsidiados == null)
            {
                return null;
            }

            return subsidiados;
        }
        
    }
}
