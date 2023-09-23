using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Régimen_contributivo : Paciente
    {
        public Régimen_contributivo() { }       
        public float Cuota_ModeradaContributivo { get; set; }
        public float Cuota_Real { get; set; }
        public float Tarifa_Aplicada { get; set; }
        public string Tope_Maximo { get; set; }

        public Régimen_contributivo(float cuota_Moderadacontributivo, float cuota_Real, float tarifa_Aplicada,string tope_maximo)
        {
            Cuota_ModeradaContributivo = cuota_Moderadacontributivo;
            Cuota_Real = cuota_Real;
            Tarifa_Aplicada = tarifa_Aplicada;         
            Tope_Maximo = tope_maximo;
        }
        public void Calcular_Cuota()
        {
            Cuota_ModeradaContributivo = Valor_ServicioPrestado * Tarifa_Aplicada;
            Cuota_Real = Cuota_ModeradaContributivo;
        }
        float Tarifa;
        public void Calcular_Tarifa()
        {
            if(Salario()== 1)
            {
                Tarifa_Aplicada = 0.15f;
            }  
            else if (Salario()== 2)
            {
                Tarifa_Aplicada = 0.20f;
            }
            else if(Salario()== 3)
            {
                Tarifa_Aplicada = 0.25f;
            }
        }
        public void Calular_TopeMaximo()
        {
            if (Salario()== 1 & Cuota_ModeradaContributivo>=250000)
            {
                Tope_Maximo = "Si Aplico";
                Cuota_ModeradaContributivo = 250000;
            }
            else if(Salario() == 2 & Cuota_ModeradaContributivo >= 900000)
            {
                Tope_Maximo = "Si Aplico";
                Cuota_ModeradaContributivo = 900000;
            }
            else if( Salario() == 3 & Cuota_ModeradaContributivo >=1500000)
            {
                Tope_Maximo = "Si Aplico";
                Cuota_ModeradaContributivo = 1500000;
            }
            else
            {
                Tope_Maximo = "No Aplico";
            }
        }
        int sm;
        public int Salario()
        {         
            if (Salario_Devengado <= 1)
            {
                return 1;
            }
            else if (Salario_Devengado >= 2 & Salario_Devengado <= 5)
            {
                return 2;
            }
            else 
            {
                return 3;
            }
        }
        public override string ToString()
        {
            return $"{N_Liquidacion};{Cuota_ModeradaContributivo};{Cuota_Real};{Tarifa_Aplicada};{Tope_Maximo}";
        }
    }
}
