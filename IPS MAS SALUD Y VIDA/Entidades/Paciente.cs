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
        public DateTime F_Liquidacion { get; set; }
        public string ID_Paciente { get; set; }
        public string Nombre_Paciente { get; set; }
        public string Tipo_Afiliacion { get; set; }
        public float Salario_Devengado { get; set; }
        public int Valor_ServicioPrestado { get; set; }

        public Paciente(string n_Liquidacion,DateTime f_liquidacion, string iD_Paciente,string nombre_paciente, string tipo_Afiliacion, float salario_Devengado, int valor_ServicioPrestado)
        {
            N_Liquidacion = n_Liquidacion;
            F_Liquidacion = f_liquidacion;
            ID_Paciente = iD_Paciente;
            Nombre_Paciente = nombre_paciente;
            Tipo_Afiliacion = tipo_Afiliacion;
            Salario_Devengado = salario_Devengado;
            Valor_ServicioPrestado = valor_ServicioPrestado;
        }
        
        public override string ToString()
        {
            return $"{N_Liquidacion};{F_Liquidacion};{ID_Paciente};{Nombre_Paciente};{Tipo_Afiliacion};{Salario_Devengado};{Valor_ServicioPrestado}";
        }
    }

}