using Newtonsoft.Json;
using RotaPrime.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RotaPrime.Services
{
    public class TransportadoraService
    {
        public List<Cliente> Clientes { get; set; }
        public List<Motorista> Motoristas { get; set; }
        public List<Veiculo> Veiculos { get; set; }
        public List<Carga> Cargas { get; set; }
        public List<Entrega> Entregas { get; set; }

        private string arquivo = "dados.json";

        public TransportadoraService()
        {
            Clientes = new List<Cliente>();
            Motoristas = new List<Motorista>();
            Veiculos = new List<Veiculo>();
            Cargas = new List<Carga>();
            Entregas = new List<Entrega>();
        }

        // ======================================================
        // SALVAR
        // ======================================================

        public void Salvar()
        {
            try
            {
                var dados = new
                {
                    Clientes = Clientes,
                    Motoristas = Motoristas,
                    Veiculos = Veiculos,
                    Cargas = Cargas,
                    Entregas = Entregas
                };

                string json = JsonConvert.SerializeObject(
                    dados,
                    Formatting.Indented
                );

                File.WriteAllText(arquivo, json);

                Console.WriteLine("Dados salvos com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    "Erro ao salvar os dados: " + ex.Message
                );
            }
        }

        // ======================================================
        // CARREGAR
        // ======================================================

        public void Carregar()
        {
            if (!File.Exists(arquivo))
            {
                Console.WriteLine(
                    "Nenhum arquivo de dados encontrado."
                );

                return;
            }

            try
            {
                string json = File.ReadAllText(arquivo);

                dynamic dados = JsonConvert.DeserializeObject(json);

                if (dados == null)
                {
                    Console.WriteLine(
                        "Não foi possível carregar os dados."
                    );

                    return;
                }

                if (dados.Clientes != null)
                {
                    Clientes = JsonConvert.DeserializeObject<List<Cliente>>(
                        dados.Clientes.ToString()
                    ) ?? new List<Cliente>();
                }

                if (dados.Motoristas != null)
                {
                    Motoristas = JsonConvert.DeserializeObject<List<Motorista>>(
                        dados.Motoristas.ToString()
                    ) ?? new List<Motorista>();
                }

                if (dados.Veiculos != null)
                {
                    Veiculos = JsonConvert.DeserializeObject<List<Veiculo>>(
                        dados.Veiculos.ToString()
                    ) ?? new List<Veiculo>();
                }

                if (dados.Cargas != null)
                {
                    Cargas = JsonConvert.DeserializeObject<List<Carga>>(
                        dados.Cargas.ToString()
                    ) ?? new List<Carga>();
                }

                if (dados.Entregas != null)
                {
                    Entregas = JsonConvert.DeserializeObject<List<Entrega>>(
                        dados.Entregas.ToString()
                    ) ?? new List<Entrega>();
                }

                Console.WriteLine(
                    "Dados carregados com sucesso!"
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    "Erro ao carregar os dados: " + ex.Message
                );
            }
        }

        // ======================================================
        // BUSCAR CLIENTE
        // ======================================================

        public Cliente BuscarCliente(int id)
        {
            return Clientes.FirstOrDefault(
                c => c.Id == id
            );
        }

        // ======================================================
        // BUSCAR MOTORISTA
        // ======================================================

        public Motorista BuscarMotorista(int id)
        {
            return Motoristas.FirstOrDefault(
                m => m.Id == id
            );
        }

        // ======================================================
        // BUSCAR VEÍCULO
        // ======================================================

        public Veiculo BuscarVeiculo(int id)
        {
            return Veiculos.FirstOrDefault(
                v => v.Id == id
            );
        }

        // ======================================================
        // BUSCAR CARGA
        // ======================================================

        public Carga BuscarCarga(int id)
        {
            return Cargas.FirstOrDefault(
                c => c.Id == id
            );
        }

        // ======================================================
        // BUSCAR ENTREGA
        // ======================================================

        public Entrega BuscarEntrega(int id)
        {
            return Entregas.FirstOrDefault(
                e => e.Id == id
            );
        }

        // ======================================================
        // RELATÓRIO
        // ======================================================

        public void Relatorio()
        {
            int pendentes = 0;
            int transporte = 0;
            int entregues = 0;
            int atrasadas = 0;

            foreach (Entrega entrega in Entregas)
            {
                if (entrega.Status == "Pendente")
                {
                    pendentes++;
                }

                if (entrega.Status == "Em transporte")
                {
                    transporte++;
                }

                if (entrega.Status == "Entregue")
                {
                    entregues++;
                }

                if (entrega.EstaAtrasada())
                {
                    atrasadas++;
                }
            }

            Console.WriteLine();
            Console.WriteLine("========================================");
            Console.WriteLine("         RELATÓRIO DE ENTREGAS");
            Console.WriteLine("========================================");

            Console.WriteLine(
                "Total de entregas: " + Entregas.Count
            );

            Console.WriteLine(
                "Pendentes: " + pendentes
            );

            Console.WriteLine(
                "Em transporte: " + transporte
            );

            Console.WriteLine(
                "Entregues: " + entregues
            );

            Console.WriteLine(
                "Atrasadas: " + atrasadas
            );
        }
    }
}