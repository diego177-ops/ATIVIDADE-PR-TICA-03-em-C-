using System;

namespace RotaPrime.Classes
{
    public class Cliente : Pessoa
    {
        private static int proximoId = 1;

        public int Id { get; set; }
        public string Endereco { get; set; }

        public Cliente()
        {
        }

        public Cliente(string nome, string telefone, string endereco)
            : base(nome, telefone)
        {
            Id = proximoId++;
            Endereco = endereco;
        }

        public override void MostrarDados()
        {
            Console.WriteLine("ID: " + Id);
            Console.WriteLine("Nome: " + Nome);
            Console.WriteLine("Telefone: " + Telefone);
            Console.WriteLine("Endereço: " + Endereco);
        }
    }
}