using RotaPrime.Classes;
using RotaPrime.Services;
using System;

namespace RotaPrime
{
    class Program
    {
        static TransportadoraService sistema = new TransportadoraService();
        static bool executando = true;

        static void Main()
        {
            sistema.Carregar();

            while (executando)
            {
                Console.Clear();

                ExibirCabecalho();
                ExibirMenu();

                Console.Write("Digite uma opção: ");

                string entrada = Console.ReadLine();

                try
                {
                    int opcao = int.Parse(entrada ?? "");

                    Console.Clear();

                    switch (opcao)
                    {
                        case 1:
                            CadastrarCliente();
                            break;

                        case 2:
                            CadastrarMotorista();
                            break;

                        case 3:
                            CadastrarVeiculo();
                            break;

                        case 4:
                            CadastrarCarga();
                            break;

                        case 5:
                            CadastrarEntrega();
                            break;

                        case 6:
                            ListarClientes();
                            break;

                        case 7:
                            ListarMotoristas();
                            break;

                        case 8:
                            ListarVeiculos();
                            break;

                        case 9:
                            ListarCargas();
                            break;

                        case 10:
                            ListarEntregas();
                            break;

                        case 11:
                            ConsultarEntrega();
                            break;

                        case 12:
                            AlterarStatus();
                            break;

                        case 13:
                            ExcluirEntrega();
                            break;

                        case 14:
                            sistema.Salvar();
                            break;

                        case 15:
                            sistema.Carregar();
                            break;

                        case 16:
                            sistema.Relatorio();
                            break;

                        case 17:
                            MostrarHistorico();
                            break;

                        case 0:
                            sistema.Salvar();
                            executando = false;
                            Console.WriteLine("Sistema encerrado.");
                            break;

                        default:
                            Console.WriteLine("Opção inválida.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Digite apenas números.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ocorreu um erro: " + ex.Message);
                }

                if (executando)
                {
                    Console.WriteLine();
                    Console.WriteLine("Pressione ENTER para continuar...");
                    Console.ReadLine();
                }
            }
        }

        // ======================================================
        // CABEÇALHO
        // ======================================================

        static void ExibirCabecalho()
        {
            Console.WriteLine("========================================");
            Console.WriteLine("              CARGOTRACK");
            Console.WriteLine("       SISTEMA DE TRANSPORTADORA");
            Console.WriteLine("========================================");
        }

        // ======================================================
        // MENU
        // ======================================================

        static void ExibirMenu()
        {
            Console.WriteLine();
            Console.WriteLine("1  - Cadastrar cliente");
            Console.WriteLine("2  - Cadastrar motorista");
            Console.WriteLine("3  - Cadastrar veículo");
            Console.WriteLine("4  - Cadastrar carga");
            Console.WriteLine("5  - Cadastrar entrega");
            Console.WriteLine("6  - Listar clientes");
            Console.WriteLine("7  - Listar motoristas");
            Console.WriteLine("8  - Listar veículos");
            Console.WriteLine("9  - Listar cargas");
            Console.WriteLine("10 - Listar entregas");
            Console.WriteLine("11 - Consultar entrega");
            Console.WriteLine("12 - Alterar status");
            Console.WriteLine("13 - Excluir entrega");
            Console.WriteLine("14 - Salvar dados");
            Console.WriteLine("15 - Carregar dados");
            Console.WriteLine("16 - Relatório");
            Console.WriteLine("17 - Histórico da entrega");
            Console.WriteLine("0  - Sair");
            Console.WriteLine();
        }

        // ======================================================
        // CADASTRAR CLIENTE
        // ======================================================

        static void CadastrarCliente()
        {
            Console.WriteLine("===== CADASTRO DE CLIENTE =====");

            Console.Write("Nome: ");
            string nome = Console.ReadLine() ?? "";

            Console.Write("Telefone: ");
            string telefone = Console.ReadLine() ?? "";

            Console.Write("Endereço: ");
            string endereco = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(nome))
            {
                Console.WriteLine("O nome não pode ficar vazio.");
                return;
            }

            Cliente cliente = new Cliente(nome, telefone, endereco);

            sistema.Clientes.Add(cliente);

            Console.WriteLine();
            Console.WriteLine("Cliente cadastrado com ID " + cliente.Id + "!");
        }

        // ======================================================
        // CADASTRAR MOTORISTA
        // ======================================================

        static void CadastrarMotorista()
        {
            Console.WriteLine("===== CADASTRO DE MOTORISTA =====");

            Console.Write("Nome: ");
            string nome = Console.ReadLine() ?? "";

            Console.Write("Telefone: ");
            string telefone = Console.ReadLine() ?? "";

            Console.Write("CNH: ");
            string cnh = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(nome) ||
                string.IsNullOrWhiteSpace(cnh))
            {
                Console.WriteLine("Nome e CNH são obrigatórios.");
                return;
            }

            Motorista motorista = new Motorista(nome, telefone, cnh);

            sistema.Motoristas.Add(motorista);

            Console.WriteLine();
            Console.WriteLine("Motorista cadastrado com ID " + motorista.Id + "!");
        }

        // ======================================================
        // CADASTRAR VEÍCULO
        // ======================================================

        static void CadastrarVeiculo()
        {
            Console.WriteLine("===== CADASTRO DE VEÍCULO =====");

            Console.Write("Placa: ");
            string placa = Console.ReadLine() ?? "";

            Console.Write("Modelo: ");
            string modelo = Console.ReadLine() ?? "";

            Console.Write("Marca: ");
            string marca = Console.ReadLine() ?? "";

            Console.Write("Ano: ");

            int ano;

            if (!int.TryParse(Console.ReadLine(), out ano))
            {
                Console.WriteLine("Ano inválido.");
                return;
            }

            Veiculo veiculo = new Veiculo(
                placa,
                modelo,
                marca,
                ano
            );

            sistema.Veiculos.Add(veiculo);

            Console.WriteLine();
            Console.WriteLine("Veículo cadastrado com ID " + veiculo.Id + "!");
        }

        // ======================================================
        // CADASTRAR CARGA
        // ======================================================

        static void CadastrarCarga()
        {
            Console.WriteLine("===== CADASTRO DE CARGA =====");

            Console.Write("Descrição: ");
            string descricao = Console.ReadLine() ?? "";

            Console.Write("Peso em kg: ");

            double peso;

            if (!double.TryParse(Console.ReadLine(), out peso))
            {
                Console.WriteLine("Peso inválido.");
                return;
            }

            if (peso <= 0)
            {
                Console.WriteLine("O peso deve ser maior que zero.");
                return;
            }

            Console.Write("Valor da carga: R$ ");

            double valor;

            if (!double.TryParse(Console.ReadLine(), out valor))
            {
                Console.WriteLine("Valor inválido.");
                return;
            }

            if (valor < 0)
            {
                Console.WriteLine("O valor não pode ser negativo.");
                return;
            }

            Carga carga = new Carga(
                descricao,
                peso,
                valor
            );

            sistema.Cargas.Add(carga);

            Console.WriteLine();
            Console.WriteLine("Carga cadastrada com ID " + carga.Id + "!");
        }

        // ======================================================
        // CADASTRAR ENTREGA
        // ======================================================

        static void CadastrarEntrega()
        {
            Console.WriteLine("===== CADASTRO DE ENTREGA =====");

            if (sistema.Clientes.Count == 0)
            {
                Console.WriteLine("Cadastre pelo menos um cliente primeiro.");
                return;
            }

            if (sistema.Motoristas.Count == 0)
            {
                Console.WriteLine("Cadastre pelo menos um motorista primeiro.");
                return;
            }

            if (sistema.Veiculos.Count == 0)
            {
                Console.WriteLine("Cadastre pelo menos um veículo primeiro.");
                return;
            }

            if (sistema.Cargas.Count == 0)
            {
                Console.WriteLine("Cadastre pelo menos uma carga primeiro.");
                return;
            }

            ListarClientes();

            Console.Write("Digite o ID do cliente: ");

            int clienteId;

            if (!int.TryParse(Console.ReadLine(), out clienteId))
            {
                Console.WriteLine("ID inválido.");
                return;
            }

            Cliente cliente = sistema.BuscarCliente(clienteId);

            if (cliente == null)
            {
                Console.WriteLine("Cliente não encontrado.");
                return;
            }

            Console.WriteLine();
            ListarMotoristas();

            Console.Write("Digite o ID do motorista: ");

            int motoristaId;

            if (!int.TryParse(Console.ReadLine(), out motoristaId))
            {
                Console.WriteLine("ID inválido.");
                return;
            }

            Motorista motorista = sistema.BuscarMotorista(motoristaId);

            if (motorista == null)
            {
                Console.WriteLine("Motorista não encontrado.");
                return;
            }

            Console.WriteLine();
            ListarVeiculos();

            Console.Write("Digite o ID do veículo: ");

            int veiculoId;

            if (!int.TryParse(Console.ReadLine(), out veiculoId))
            {
                Console.WriteLine("ID inválido.");
                return;
            }

            Veiculo veiculo = sistema.BuscarVeiculo(veiculoId);

            if (veiculo == null)
            {
                Console.WriteLine("Veículo não encontrado.");
                return;
            }

            Console.WriteLine();
            ListarCargas();

            Console.Write("Digite o ID da carga: ");

            int cargaId;

            if (!int.TryParse(Console.ReadLine(), out cargaId))
            {
                Console.WriteLine("ID inválido.");
                return;
            }

            Carga carga = sistema.BuscarCarga(cargaId);

            if (carga == null)
            {
                Console.WriteLine("Carga não encontrada.");
                return;
            }

            Console.WriteLine();

            Console.Write("Origem: ");
            string origem = Console.ReadLine() ?? "";

            Console.Write("Destino: ");
            string destino = Console.ReadLine() ?? "";

            Console.Write("Data prevista (dd/MM/yyyy): ");

            DateTime dataPrevista;

            if (!DateTime.TryParse(Console.ReadLine(), out dataPrevista))
            {
                Console.WriteLine("Data inválida.");
                return;
            }

            Console.Write("Valor do frete: R$ ");

            double valorFrete;

            if (!double.TryParse(Console.ReadLine(), out valorFrete))
            {
                Console.WriteLine("Valor inválido.");
                return;
            }

            if (valorFrete < 0)
            {
                Console.WriteLine("O valor do frete não pode ser negativo.");
                return;
            }

            Entrega entrega = new Entrega(
                clienteId,
                motoristaId,
                veiculoId,
                cargaId,
                origem,
                destino,
                dataPrevista,
                valorFrete
            );

            sistema.Entregas.Add(entrega);

            Console.WriteLine();
            Console.WriteLine("Entrega cadastrada com ID " + entrega.Id + "!");
        }

        // ======================================================
        // LISTAR CLIENTES
        // ======================================================

        static void ListarClientes()
        {
            Console.WriteLine("===== CLIENTES =====");

            if (sistema.Clientes.Count == 0)
            {
                Console.WriteLine("Nenhum cliente cadastrado.");
                return;
            }

            foreach (Cliente cliente in sistema.Clientes)
            {
                cliente.MostrarDados();
                Console.WriteLine("----------------------------");
            }
        }

        // ======================================================
        // LISTAR MOTORISTAS
        // ======================================================

        static void ListarMotoristas()
        {
            Console.WriteLine("===== MOTORISTAS =====");

            if (sistema.Motoristas.Count == 0)
            {
                Console.WriteLine("Nenhum motorista cadastrado.");
                return;
            }

            foreach (Motorista motorista in sistema.Motoristas)
            {
                motorista.MostrarDados();
                Console.WriteLine("----------------------------");
            }
        }

        // ======================================================
        // LISTAR VEÍCULOS
        // ======================================================

        static void ListarVeiculos()
        {
            Console.WriteLine("===== VEÍCULOS =====");

            if (sistema.Veiculos.Count == 0)
            {
                Console.WriteLine("Nenhum veículo cadastrado.");
                return;
            }

            foreach (Veiculo veiculo in sistema.Veiculos)
            {
                veiculo.MostrarDados();
                Console.WriteLine("----------------------------");
            }
        }

        // ======================================================
        // LISTAR CARGAS
        // ======================================================

        static void ListarCargas()
        {
            Console.WriteLine("===== CARGAS =====");

            if (sistema.Cargas.Count == 0)
            {
                Console.WriteLine("Nenhuma carga cadastrada.");
                return;
            }

            foreach (Carga carga in sistema.Cargas)
            {
                carga.MostrarDados();
                Console.WriteLine("----------------------------");
            }
        }

        // ======================================================
        // LISTAR ENTREGAS
        // ======================================================

        static void ListarEntregas()
        {
            Console.WriteLine("===== ENTREGAS =====");

            if (sistema.Entregas.Count == 0)
            {
                Console.WriteLine("Nenhuma entrega cadastrada.");
                return;
            }

            foreach (Entrega entrega in sistema.Entregas)
            {
                entrega.MostrarDados();
                Console.WriteLine("----------------------------");
            }
        }

        // ======================================================
        // CONSULTAR ENTREGA
        // ======================================================

        static void ConsultarEntrega()
        {
            Console.WriteLine("===== CONSULTAR ENTREGA =====");

            Console.Write("Digite o ID da entrega: ");

            int id;

            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("ID inválido.");
                return;
            }

            Entrega entrega = sistema.BuscarEntrega(id);

            if (entrega == null)
            {
                Console.WriteLine("Entrega não encontrada.");
                return;
            }

            Console.WriteLine();
            entrega.MostrarDados();
        }

        // ======================================================
        // ALTERAR STATUS
        // ======================================================

        static void AlterarStatus()
        {
            Console.WriteLine("===== ALTERAR STATUS =====");

            Console.Write("Digite o ID da entrega: ");

            int id;

            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("ID inválido.");
                return;
            }

            Entrega entrega = sistema.BuscarEntrega(id);

            if (entrega == null)
            {
                Console.WriteLine("Entrega não encontrada.");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("Status atual: " + entrega.Status);
            Console.WriteLine();
            Console.WriteLine("1 - Pendente");
            Console.WriteLine("2 - Em transporte");
            Console.WriteLine("3 - Entregue");

            Console.Write("Escolha o novo status: ");

            string opcao = Console.ReadLine();

            string novoStatus;

            switch (opcao)
            {
                case "1":
                    novoStatus = "Pendente";
                    break;

                case "2":
                    novoStatus = "Em transporte";
                    break;

                case "3":
                    novoStatus = "Entregue";
                    break;

                default:
                    Console.WriteLine("Opção inválida.");
                    return;
            }

            entrega.AlterarStatus(novoStatus);
        }

        // ======================================================
        // EXCLUIR ENTREGA
        // ======================================================

        static void ExcluirEntrega()
        {
            Console.WriteLine("===== EXCLUIR ENTREGA =====");

            Console.Write("Digite o ID da entrega: ");

            int id;

            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("ID inválido.");
                return;
            }

            Entrega entrega = sistema.BuscarEntrega(id);

            if (entrega == null)
            {
                Console.WriteLine("Entrega não encontrada.");
                return;
            }

            sistema.Entregas.Remove(entrega);

            Console.WriteLine("Entrega excluída com sucesso!");
        }

        // ======================================================
        // HISTÓRICO
        // ======================================================

        static void MostrarHistorico()
        {
            Console.WriteLine("===== HISTÓRICO DA ENTREGA =====");

            Console.Write("Digite o ID da entrega: ");

            int id;

            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("ID inválido.");
                return;
            }

            Entrega entrega = sistema.BuscarEntrega(id);

            if (entrega == null)
            {
                Console.WriteLine("Entrega não encontrada.");
                return;
            }

            entrega.MostrarHistorico();
        }
    }
}