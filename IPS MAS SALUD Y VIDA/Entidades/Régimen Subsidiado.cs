using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Régimen_Subsidiado : Régimen_contributivo
    {
        public Régimen_Subsidiado() { }
        public float Cuota_ModeradaSubsidiado { get; set; }
        public Régimen_Subsidiado(float cuota_ModeradaSubsidiado)
        {
            Cuota_ModeradaSubsidiado = cuota_ModeradaSubsidiado;
        }
        public void Calcular_Cuota_RS()
        {
            Tarifa_Aplicada = 0.05f;
            Cuota_ModeradaSubsidiado = Valor_ServicioPrestado * Tarifa_Aplicada;
            Cuota_Real = Cuota_ModeradaSubsidiado;
        }
        public void Calcular_TopeMaximo_RS()
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
