using System;

namespace RotaPrime.Classes
{
    public class Motorista : Pessoa
    {
        private static int proximoId = 1;

        public int Id { get; set; }
        public string CNH { get; set; }

        public Motorista()
        {
        }

        public Motorista(string nome, string telefone, string cnh)
            : base(nome, telefone)
        {
            Id = proximoId++;
            CNH = cnh;
        }

        public override void MostrarDados()
        {
            Console.WriteLine("ID: " + Id);
            Console.WriteLine("Nome: " + Nome);
            Console.WriteLine("Telefone: " + Telefone);
            Console.WriteLine("CNH: " + CNH);
        }
    }
}