using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Régimen_Subsidiado : Paciente
    {
        public decimal Cuota_ModeradaSubsidiado { get; set; }

        public Régimen_Subsidiado(decimal cuota_ModeradaSubsidiado)
        {
            Cuota_ModeradaSubsidiado = cuota_ModeradaSubsidiado;
        }
        public override string ToString()
        {
            return $"{Cuota_ModeradaSubsidiado}";
        }
    }
}
