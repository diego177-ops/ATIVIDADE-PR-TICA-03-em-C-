using RotaPrime.Interfaces;
using System;

namespace RotaPrime.Classes
{
    public class Pessoa : IExibivel
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }

        public Pessoa()
        {
        }

        public Pessoa(string nome, string telefone)
        {
            Nome = nome;
            Telefone = telefone;
        }

        public virtual void MostrarDados()
        {
            Console.WriteLine("Nome: " + Nome);
            Console.WriteLine("Telefone: " + Telefone);
        }
    }
}