using RotaPrime.Interfaces;
using System;

namespace RotaPrime.Classes
{
    public class Carga : IExibivel
    {
        private static int proximoId = 1;

        public int Id { get; set; }
        public string Descricao { get; set; }
        public double Peso { get; set; }
        public double Valor { get; set; }

        public Carga()
        {
        }

        public Carga(string descricao, double peso, double valor)
        {
            Id = proximoId++;
            Descricao = descricao;
            Peso = peso;
            Valor = valor;
        }

        public void MostrarDados()
        {
            Console.WriteLine("ID: " + Id);
            Console.WriteLine("Descrição: " + Descricao);
            Console.WriteLine("Peso: " + Peso + " kg");
            Console.WriteLine("Valor da carga: R$ " + Valor.ToString("F2"));
        }
    }
}