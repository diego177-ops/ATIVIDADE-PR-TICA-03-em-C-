using RotaPrime.Interfaces;
using System;
using System.Collections.Generic;

namespace RotaPrime.Classes
{
    public class Entrega : IExibivel
    {
        private static int proximoId = 1;

        public int Id { get; set; }

        public int ClienteId { get; set; }

        public int MotoristaId { get; set; }

        public int VeiculoId { get; set; }

        public int CargaId { get; set; }

        public string Origem { get; set; }

        public string Destino { get; set; }

        public DateTime DataPrevista { get; set; }

        public string Status { get; set; }

        public double ValorFrete { get; set; }

        public List<HistoricoEntrega> Historico { get; set; }

        public Entrega()
        {
            Historico = new List<HistoricoEntrega>();
        }

        public Entrega(
            int clienteId,
            int motoristaId,
            int veiculoId,
            int cargaId,
            string origem,
            string destino,
            DateTime dataPrevista,
            double valorFrete)
        {
            Id = proximoId++;

            ClienteId = clienteId;
            MotoristaId = motoristaId;
            VeiculoId = veiculoId;
            CargaId = cargaId;

            Origem = origem;
            Destino = destino;

            DataPrevista = dataPrevista;

            ValorFrete = valorFrete;

            Status = "Pendente";

            Historico = new List<HistoricoEntrega>();

            Historico.Add(
                new HistoricoEntrega("Pendente")
            );
        }

        public void AlterarStatus(string novoStatus)
        {
            if (novoStatus == "Em transporte" &&
                Status == "Entregue")
            {
                Console.WriteLine(
                    "Uma entrega já finalizada não pode voltar para transporte."
                );

                return;
            }

            if (novoStatus == "Entregue" &&
                Status == "Pendente")
            {
                Console.WriteLine(
                    "A entrega precisa estar em transporte antes de ser entregue."
                );

                return;
            }

            Status = novoStatus;

            Historico.Add(
                new HistoricoEntrega(novoStatus)
            );

            Console.WriteLine(
                "Status alterado com sucesso!"
            );
        }

        public bool EstaAtrasada()
        {
            if (Status != "Entregue" &&
                DateTime.Now.Date > DataPrevista.Date)
            {
                return true;
            }

            return false;
        }

        public void MostrarDados()
        {
            Console.WriteLine("ID da entrega: " + Id);
            Console.WriteLine("Cliente ID: " + ClienteId);
            Console.WriteLine("Motorista ID: " + MotoristaId);
            Console.WriteLine("Veículo ID: " + VeiculoId);
            Console.WriteLine("Carga ID: " + CargaId);
            Console.WriteLine("Origem: " + Origem);
            Console.WriteLine("Destino: " + Destino);
            Console.WriteLine(
                "Data prevista: " +
                DataPrevista.ToString("dd/MM/yyyy")
            );
            Console.WriteLine("Status: " + Status);
            Console.WriteLine(
                "Valor do frete: R$ " +
                ValorFrete.ToString("F2")
            );

            if (EstaAtrasada())
            {
                Console.WriteLine(
                    "ATENÇÃO: ENTREGA ATRASADA!"
                );
            }
        }

        public void MostrarHistorico()
        {
            Console.WriteLine();
            Console.WriteLine("HISTÓRICO DA ENTREGA");
            Console.WriteLine("----------------------------");

            foreach (HistoricoEntrega item in Historico)
            {
                item.MostrarHistorico();
            }
        }
    }
}