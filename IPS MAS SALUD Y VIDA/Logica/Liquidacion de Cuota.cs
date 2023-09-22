using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Liquidacion_de_Cuota
    {
        Archivos archivos = new Archivos();
        List<Paciente> pacientes;

        public Liquidacion_de_Cuota()
        {
            Refresh();
        }

        public void GuardarLiquidacion(Paciente paciente)
        {
            bool encontrado = false;
            try
            {
                if (paciente != null)
                {
                    if (pacientes == null)
                    {
                        archivos.GuardarLiquidacion(paciente);
                        Console.WriteLine("iNFORMACION guardado correctamente");
                    }
                    else
                    {
                        foreach (var item in pacientes)
                        {

                            if (paciente.ID_Paciente == item.ID_Paciente)
                            {
                                Console.WriteLine("Informacion ya existe");
                                encontrado = true;
                            }
                        }
                        if (encontrado == false)
                        {
                            archivos.GuardarLiquidacion(paciente);
                            Console.WriteLine("informacion guardado correctamente");
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

        public List<Paciente> GetAll()
        {
            Refresh();
            if (pacientes == null)
            {
                return null;
            }

            return pacientes;
        }
    }
}
