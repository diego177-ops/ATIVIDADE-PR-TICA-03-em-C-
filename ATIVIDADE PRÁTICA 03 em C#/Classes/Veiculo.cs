using RotaPrime.Interfaces;
using System;

namespace RotaPrime.Classes
{
    public class Veiculo : IExibivel
    {
        private static int proximoId = 1;

        public int Id { get; set; }
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public int Ano { get; set; }

        public Veiculo()
        {
        }

        public Veiculo(
            string placa,
            string modelo,
            string marca,
            int ano)
        {
            Id = proximoId++;
            Placa = placa;
            Modelo = modelo;
            Marca = marca;
            Ano = ano;
        }

        public void MostrarDados()
        {
            Console.WriteLine("ID: " + Id);
            Console.WriteLine("Placa: " + Placa);
            Console.WriteLine("Modelo: " + Modelo);
            Console.WriteLine("Marca: " + Marca);
            Console.WriteLine("Ano: " + Ano);
        }
    }
}