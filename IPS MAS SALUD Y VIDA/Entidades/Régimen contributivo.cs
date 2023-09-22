using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Régimen_contributivo : Paciente
    {
        public float Cuota_ModeradaContributivo { get; set; }

        public Régimen_contributivo(float cuota_Moderadacontributivo)
        {
            Cuota_ModeradaContributivo = cuota_Moderadacontributivo;
        }
        public void Calcular_Cuota()
        {
            Cuota_ModeradaContributivo = Valor_ServicioPrestado * Calcular_Tarifa();
        }
        float Tarifa;
        public float Calcular_Tarifa()
        {
            if(Salario()== 1)
            {
                Tarifa = 0.15f;
            }  
            else if (Salario()== 2)
            {
                Tarifa = 0.20f;
            }
            else if(Salario()== 3)
            {
                Tarifa = 0.25f;
            }
            return Tarifa;
        }
        public void Tope_Maximo()
        {
            if (Salario()== 1 & Cuota_ModeradaContributivo>=250000)
            {
                Cuota_ModeradaContributivo = 250000;
            }
            else if(Salario() == 2 & Cuota_ModeradaContributivo >= 900000)
            {
                Cuota_ModeradaContributivo = 900000;
            }
            else if( Salario() == 3 & Cuota_ModeradaContributivo >=1500000)
            {
                Cuota_ModeradaContributivo = 1500000;
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
            return $"{Cuota_ModeradaContributivo}";
        }
    }
}
