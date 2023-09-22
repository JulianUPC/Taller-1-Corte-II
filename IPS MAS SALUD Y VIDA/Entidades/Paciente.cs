using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paciente
    {
        public Paciente(){ }
        public string N_Liquidacion { get; set; }
        public string ID_Paciente { get; set; }
        public bool Tipo_Afiliacion { get; set; }
        public float Salario_Devengado { get; set; }
        public float Valor_ServicioPrestado { get; set; }

        public Paciente(string n_Liquidacion, string iD_Paciente, bool tipo_Afiliacion, float salario_Devengado, float valor_ServicioPrestado)
        {
            N_Liquidacion = n_Liquidacion;
            ID_Paciente = iD_Paciente;
            Tipo_Afiliacion = tipo_Afiliacion;
            Salario_Devengado = salario_Devengado;
            Valor_ServicioPrestado = valor_ServicioPrestado;
        }
        
        public override string ToString()
        {
            return $"{N_Liquidacion};{ID_Paciente};{Tipo_Afiliacion};{Salario_Devengado};{Valor_ServicioPrestado}";
        }
    }

}