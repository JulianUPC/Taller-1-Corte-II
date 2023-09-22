using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace presentacion
{
    public class GUI
    {
        public void Menu()
        {
            int Op = 0;
            do
            {
                try
                {
                    Console.Clear();
                    Console.SetCursorPosition(10, 5); Console.WriteLine("IPS MAS SALUD Y VIDA");
                    Console.SetCursorPosition(10, 6); Console.WriteLine("1. Registrar la información");
                    Console.SetCursorPosition(10, 7); Console.WriteLine("2. Visualizar todas las liquidaciones realizadas ");
                    Console.SetCursorPosition(10, 8); Console.WriteLine("3. Consulta por tipo de afiliación ");
                    Console.SetCursorPosition(10, 9); Console.WriteLine("4. Consulta las cuotas moderadoras liquidadas y el valor total liquidado");
                    Console.SetCursorPosition(10, 10); Console.WriteLine("5.Consulta de liquidaciones realizadas en un mes y año especifico ");
                    Console.SetCursorPosition(10, 11); Console.WriteLine("5. Consultar Nombre de Paciente ");
                    Console.SetCursorPosition(10, 12); Console.WriteLine("0. Salir");
                    Console.SetCursorPosition(10, 13); Console.Write("Opcion: "); Op = int.Parse(Console.ReadLine());
                    switch (Op)
                    {
                        case 1:
                            Registrar_Informacion();
                            break;

                        case 2:
                            Tabla_Liquidaciones();
                            break;

                        case 3:
                            Consulta_Afiliacion();
                            break;

                        case 4:
                            Consulta_Cuotas();
                            break;

                        case 5:
                            Consulta_Paciente();
                            break;

                        case 0:
                            Console.SetCursorPosition(10, 23); Console.Write("Finalizando Programa...");
                            Thread.Sleep(1000);
                            break;

                        default:
                            Console.Clear();
                            Console.WriteLine("¡ERROR! Digite una opcion valdia");
                            Console.WriteLine("Pulse cualquier tecla para volver al menú");
                            Console.ReadKey();
                            break;
                    }
                }
                catch (FormatException e)
                {
                    Console.Clear();
                    Console.WriteLine("Error, caracter no válido");
                    Console.ReadKey();
                }
            } while (Op != 0);
        }
        public void Registrar_Informacion()
        {

        }
        public void Tabla_Liquidaciones()
        {

        }
        public void Consulta_Afiliacion()
        { 

        }
        public void Consulta_Cuotas()
        {

        }
        public void Consulta_Paciente()
        {

        }

    }
}
