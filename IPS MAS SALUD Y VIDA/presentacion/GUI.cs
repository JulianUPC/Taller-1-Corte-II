using Entidades;
using Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace presentacion
{
    public class GUI
    {
        Paciente paciente = new Paciente();
        Régimen_contributivo Reg_Contributivo = new Régimen_contributivo();
        Régimen_Subsidiado Reg_Subsidiado = new Régimen_Subsidiado();
        Liquidacion_de_Cuota liq_Cuota = new Liquidacion_de_Cuota();
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
                    Console.SetCursorPosition(10, 10); Console.WriteLine("5. Consulta de liquidaciones realizadas en un mes y año especifico ");
                    Console.SetCursorPosition(10, 11); Console.WriteLine("6. Consultar Nombre de Paciente ");
                    Console.SetCursorPosition(10, 12); Console.WriteLine("7. Eliminar Liquidacion");
                    Console.SetCursorPosition(10, 13); Console.WriteLine("8. Modificar el Valor del Servicio de Hospitalizacion Prestado ");
                    Console.SetCursorPosition(10, 14); Console.WriteLine("0. Salir");
                    Console.SetCursorPosition(10, 15); Console.Write("Opcion: "); Op = int.Parse(Console.ReadLine());
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
                            Consultar_Liquidacion();
                            break;

                        case 6:
                            Consulta_Paciente();
                            break;

                        case 7:
                            Eliminar_Liquidacion();
                            break;

                        case 8:
                            Modificar_ValorHospitalizacion();
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

        char Tipo_Afiliacion;
        public void Registrar_Informacion()
        {
            Informacion_Llenar();
            Leer_Datos();
        }

        public void Informacion_Llenar()
        {
            Console.Clear();
            Console.SetCursorPosition(20, 5); Console.WriteLine("REGISTRO DE INFORMACION");
            Console.SetCursorPosition(10, 6); Console.WriteLine("|------------------------------------------------------");
            Console.SetCursorPosition(10, 7); Console.WriteLine("|Numero de Liquidacion: ");
            Console.SetCursorPosition(10, 8); Console.WriteLine("|------------------------------------------------------");
            Console.SetCursorPosition(10, 9); Console.WriteLine("|Fecha de Liquidacion DIA:   /MES:   /AÑO: ");
            Console.SetCursorPosition(10, 10); Console.WriteLine("|------------------------------------------------------");
            Console.SetCursorPosition(10, 11); Console.WriteLine("|Numero de Identificacion del paciente: ");
            Console.SetCursorPosition(10, 12); Console.WriteLine("|------------------------------------------------------");
            Console.SetCursorPosition(10, 13); Console.WriteLine("|Nombre del Paciente: ");
            Console.SetCursorPosition(10, 14); Console.WriteLine("|------------------------------------------------------");
            Console.SetCursorPosition(10, 15); Console.WriteLine("|Tipo de Afiliacion S / C");
            Console.SetCursorPosition(10, 16); Console.WriteLine("|(S) Subsidiado");
            Console.SetCursorPosition(10, 17); Console.WriteLine("|(C) Contributivo");
            Console.SetCursorPosition(10, 18); Console.WriteLine("|Tipo: ");
            Console.SetCursorPosition(10, 19); Console.WriteLine("|------------------------------------------------------");
            Console.SetCursorPosition(10, 20); Console.WriteLine("|Salario devengado del paciente: ");
            Console.SetCursorPosition(10, 21); Console.WriteLine("|------------------------------------------------------");
            Console.SetCursorPosition(10, 22); Console.WriteLine("|valor del servicio de hospitalización prestado: ");
            Console.SetCursorPosition(10, 23); Console.WriteLine("|------------------------------------------------------");
        }

        string auxiliar;
        float Limite;       
        public void Leer_Datos()
        {
            float Valor;
            string dia,mes,año;
            DateTime fecha;

            //NUMERO DE LIQUIDACION
            do
            {
                Console.SetCursorPosition(33, 7); Console.WriteLine("                   "); //Limpia los datos ingresados anteriormente, si es que estos fueron erroneos
                Console.SetCursorPosition(33, 7); auxiliar = Console.ReadLine();
            } while (auxiliar.Length <= 0 || auxiliar.Length > 5); //Establece un limite el cual no puede ser pasado
            paciente.N_Liquidacion = auxiliar.Trim();

            //FECHA DE LIQUIDACION
            do
            {
                Console.SetCursorPosition(36, 9); dia = Console.ReadLine();
                Console.SetCursorPosition(44, 9); mes = Console.ReadLine();
                Console.SetCursorPosition(52, 9); año = Console.ReadLine();
            } while (!Verificar_Fecha(dia) || !Verificar_Fecha(mes) || año.Length > 4);
            fecha = new DateTime(int.Parse(año),int.Parse(mes), int.Parse(dia));
            paciente.F_Liquidacion = fecha;
           

            //NUMERO DE AFILIACION DEL PACIENTE
            do
            {
                Console.SetCursorPosition(49, 11); Console.WriteLine("                   ");
                Console.SetCursorPosition(49, 11); auxiliar = Console.ReadLine();
            } while (auxiliar.Length <= 0 || auxiliar.Length > 10 || !float.TryParse(auxiliar, out _));
            paciente.ID_Paciente = auxiliar.Trim();

            //NOMBRE DEL PACIENTE
            do
            {
                Console.SetCursorPosition(32, 13); Console.WriteLine("                   ");
                Console.SetCursorPosition(32, 13); auxiliar = Console.ReadLine();
            } while (!auxiliar.All(c => char.IsLetter(c) ||c == ' '));
            paciente.Nombre_Paciente = auxiliar.Trim();

            //TIPO DE AFILIACION    
            do
            {
                Console.SetCursorPosition(16, 18); Console.WriteLine("                   ");
                Console.SetCursorPosition(16, 18); auxiliar = Console.ReadLine().ToUpper();
            } while (auxiliar.Length <= 0 || auxiliar.Length >= 2 || auxiliar != "S" && auxiliar != "C");
            Determinar_Afiliacion(auxiliar);
            if (auxiliar == "S")
            {
                Informacion_NoContributiva();   //SI PERTENECE AL REGIMEN SUBSIDIADO
                paciente.Salario_Devengado = 0;
            }
            else
            {
                Leer_DatosContributivos();   //SI NO PERTENECE AL REGIMEN SUBSIDIADO                                  
            }

            //VALOR 
            do
            {
                Console.SetCursorPosition(58, 22); Console.WriteLine("                   ");
                Console.SetCursorPosition(58, 22); auxiliar = Console.ReadLine();
            } while (!float.TryParse(auxiliar, out Limite) || Limite <= 0);
            paciente.Valor_ServicioPrestado = int.Parse(auxiliar);

            Transferir_Valores();
            Procedimientos();   
            Reg_Subsidiado.N_Liquidacion = paciente.N_Liquidacion;
            Reg_Contributivo.N_Liquidacion = paciente.N_Liquidacion;
            liq_Cuota.GuardarLiquidacion(paciente, Reg_Contributivo, Reg_Subsidiado);            
            Console.SetCursorPosition(10, 22); Console.WriteLine("Presione una tecla para salir..");
            Console.ReadKey();
        }

        public void Informacion_NoContributiva()
        {
            Console.SetCursorPosition(11, 20); Console.WriteLine("                                                 ");
            Console.SetCursorPosition(11, 20); Console.WriteLine("Salario devengado del paciente: NO APLICA");
            Console.SetCursorPosition(11, 22); Console.WriteLine("valor del servicio de hospitalización prestado: ");
        }
        public bool Verificar_Fecha(string input)
        {
            return input.Length == 2 && int.TryParse(input, out _);
        }

        public void Leer_DatosContributivos()
        {
            do
            {
                Console.SetCursorPosition(42, 20); Console.WriteLine("                   ");
                Console.SetCursorPosition(42, 20); auxiliar = Console.ReadLine();
            } while (!float.TryParse(auxiliar, out Limite) && Limite <= 0);
            paciente.Salario_Devengado = float.Parse(auxiliar);
          
        }
        public void Transferir_Valores()
        {
            Reg_Contributivo.Salario_Devengado = paciente.Salario_Devengado;
            Reg_Contributivo.Valor_ServicioPrestado = paciente.Valor_ServicioPrestado;
            Reg_Subsidiado.Valor_ServicioPrestado = paciente.Valor_ServicioPrestado;           
        }
        public void Procedimientos()
        {
            Reg_Contributivo.Calcular_Tarifa();
            Reg_Contributivo.Calcular_Cuota();
            Reg_Contributivo.Calular_TopeMaximo();
            Reg_Subsidiado.Calcular_Cuota_RS();
            Reg_Subsidiado.Calcular_TopeMaximo_RS();
        }
        public void Determinar_Afiliacion(string tipo_Afiliacion)
        {
            if (tipo_Afiliacion == "S")
            {
                paciente.Tipo_Afiliacion = "Subsidiado";
            }
            else if (tipo_Afiliacion == "C")
            {
                paciente.Tipo_Afiliacion = "Contributivo";
            }
        }
        public void Tabla_Liquidaciones()
        {
            Console.Clear();
            int i = 7;
            if (liq_Cuota.GetAll() == null)
            {
                Console.SetCursorPosition(10, 10); Console.WriteLine("No hay establecimientos registrados");
                Console.ReadKey();
            }
            else
            {
                Console.SetCursorPosition(1, 5); Console.WriteLine("Consulta de establecimientos");
                Console.SetCursorPosition(1, 6); Console.WriteLine("|  N.IDENTIFIACION  |  T. AFILIACION  | SALARIO | V. SERVICIO | TARIFA APLICADA | VALOR REAL | TOPE MAXIMO | CUOTA MODERADA |");
                Console.SetCursorPosition(1, 7); Console.WriteLine("|                   |                 |         |             |                 |            |             |                |");
                Console.SetCursorPosition(1, 8); Console.WriteLine("|                   |                 |         |             |                 |            |             |                |");
                Console.SetCursorPosition(1, 9); Console.WriteLine("|                   |                 |         |             |                 |            |             |                |");
                Console.SetCursorPosition(1, 10); Console.WriteLine("|                   |                 |         |             |                 |            |             |                |");
                Console.SetCursorPosition(1, 11); Console.WriteLine("|                   |                 |         |             |                 |            |             |                |");
                Console.SetCursorPosition(1, 12); Console.WriteLine("|                   |                 |         |             |                 |            |             |                |");
                Console.SetCursorPosition(1, 13); Console.WriteLine("|                   |                 |         |             |                 |            |             |                |");
                Console.SetCursorPosition(1, 14); Console.WriteLine("|                   |                 |         |             |                 |            |             |                |");
                Console.SetCursorPosition(1, 15); Console.WriteLine("|                   |                 |         |             |                 |            |             |                |");
                Console.SetCursorPosition(1, 16); Console.WriteLine("|                   |                 |         |             |                 |            |             |                |");
                Console.SetCursorPosition(1, 17); Console.WriteLine("|                   |                 |         |             |                 |            |             |                |");
                foreach (var item in liq_Cuota.GetAll())
                {
                    Console.SetCursorPosition(4, i); Console.Write(item.N_Liquidacion);
                    Console.SetCursorPosition(24, i); Console.Write(item.Tipo_Afiliacion);
                    Console.SetCursorPosition(41, i); Console.Write(item.Salario_Devengado);
                    Console.SetCursorPosition(51, i); Console.Write(item.Valor_ServicioPrestado.ToString());
                    if(item.Tipo_Afiliacion == "Contributivo")
                    {
                        foreach (var itemRC in liq_Cuota.GetAll_RC())
                        {
                            Console.SetCursorPosition(65, i); Console.Write(itemRC.Tarifa_Aplicada);
                            Console.SetCursorPosition(83, i); Console.Write(itemRC.Cuota_Real);
                            Console.SetCursorPosition(96, i); Console.Write(itemRC.Tope_Maximo);
                            Console.SetCursorPosition(110, i); Console.Write(itemRC.Cuota_ModeradaContributivo);
                        }
                    }
                    else
                    {
                        foreach (var itemRS in liq_Cuota.GetAll_RS())
                        {
                            Console.SetCursorPosition(65, i); Console.Write(itemRS.Tarifa_Aplicada);
                            Console.SetCursorPosition(83, i); Console.Write(itemRS.Cuota_Real);
                            Console.SetCursorPosition(96, i); Console.Write(itemRS.Tope_Maximo);
                            Console.SetCursorPosition(110, i); Console.Write(itemRS.Cuota_ModeradaSubsidiado);
                        }
                    }
                    i++;
                }
                Console.SetCursorPosition(3, i * 3); Console.WriteLine("Pulse cualquier tecla para volver al menú");
                Console.ReadKey();
            }
        }
        public void Consulta_Afiliacion()
        { 

        }
        public void Consulta_Cuotas()
        {

        }

        public void Consultar_Liquidacion()
        {

        }
        public void Consulta_Paciente()
        {

        }

        public void Eliminar_Liquidacion()
        {

        }
        
        public void Modificar_ValorHospitalizacion()
        {

        }

    }
}
