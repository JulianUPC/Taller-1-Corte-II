using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Régimen_Subsidiado : Paciente
    {
        public Régimen_Subsidiado() { }
        public float Cuota_ModeradaSubsidiado { get; set; }
        public float Cuota_Real { get; set; }
        public float Tarifa_Aplicada { get; set; }
        public string Tope_Maximo { get; set; }

        public Régimen_Subsidiado(float cuota_ModeradaSubsidiado,float cuota_real, float tarifa_aplicada, string tope_Maximo)
        {
            Cuota_ModeradaSubsidiado = cuota_ModeradaSubsidiado;
            Cuota_Real = cuota_real;
            Tarifa_Aplicada = tarifa_aplicada; 
            Tope_Maximo = tope_Maximo;
        }
        public void Calcular_Cuota()
        {
            Tarifa_Aplicada = 0.05f;
            Cuota_ModeradaSubsidiado = Valor_ServicioPrestado * Tarifa_Aplicada;
            Cuota_Real = Cuota_ModeradaSubsidiado;
        }
        public void Calcular_TopeMaximo()
        {
            if(Cuota_ModeradaSubsidiado>=200000)
            {
                Cuota_ModeradaSubsidiado = 200000;
                Tope_Maximo = "Si aplica";
            }
            else
            {
                Tope_Maximo = "No aplica";
            }
        }
        public override string ToString()
        {
            return $"{N_Liquidacion};{Cuota_ModeradaSubsidiado};{Cuota_Real};{Tarifa_Aplicada};{Tope_Maximo}";
        }
    }
}
