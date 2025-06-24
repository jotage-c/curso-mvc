using LocadoraConsole.Testes;
using LocadoraReposDesign.Domain;
using LocadoraReposDesign.Repositories;
using LocadoraReposDesign.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace LocadoraReposDesign.UI
{
    public class MenuConsole
    {
        private readonly ClienteRepository _clienteRepo;
        private readonly VeiculoRepository _veiculoRepo;
        private readonly InMemoryRepository<Locacao> _locacaoRepo;
        private readonly LocacaoService _locacaoService;

        public MenuConsole()
        {
            _clienteRepo = new ClienteRepository();
            _veiculoRepo = new VeiculoRepository();
            _locacaoRepo = new InMemoryRepository<Locacao>();
            _locacaoService = new LocacaoService(_locacaoRepo, _clienteRepo, _veiculoRepo);
        }

        public void Iniciar()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== LOCADORA DE VEÍCULOS ===");
                Console.WriteLine("1 - Cadastrar Cliente");
                Console.WriteLine("2 - Cadastrar Veículo");
                Console.WriteLine("3 - Listar Clientes");
                Console.WriteLine("4 - Listar Veículos");
                Console.WriteLine("5 - Alugar Veículo");
                Console.WriteLine("6 - Devolver Veículo");
                Console.WriteLine("7 - Listar Locações");
                Console.WriteLine("8 - Rodar Simulação de Testes");
                Console.WriteLine("0 - Sair");
                Console.Write("Escolha uma opção: ");

                var opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        CadastrarCliente();
                        break;
                    case "2":
                        CadastrarVeiculo();
                        break;
                    case "3":
                        ListarClientes();
                        break;
                    case "4":
                        ListarVeiculos();
                        break;
                    case "5":
                        AlugarVeiculo();
                        break;
                    case "6":
                        DevolverVeiculo();
                        break;
                    case "7":
                        _locacaoService.ListarLocacoes();
                        break;
                    case "8":
                        Simulador.ExecutarSimulacao(_clienteRepo, _veiculoRepo, _locacaoService);
                        break;
                    case "0":
                        Console.WriteLine("Encerrando...");
                        return;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

                Console.WriteLine("\nPressione ENTER para continuar...");
                Console.ReadLine();
            }
        }

        private void CadastrarCliente()
        {
            Console.Write("Nome do cliente: ");
            var nome = Console.ReadLine();

            Console.Write("CPF do cliente: ");
            var cpf = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(cpf))
            {
                Console.WriteLine("Nome e CPF são obrigatórios.");
                return;
            }

            _clienteRepo.Add(new Cliente { Nome = nome, Cpf = cpf });
            Console.WriteLine("Cliente cadastrado!");
        }

        private void CadastrarVeiculo()
        {
            Console.Write("Marca do veículo: ");
            var marca = Console.ReadLine();

            Console.Write("Modelo do veículo: ");
            var modelo = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(marca) || string.IsNullOrWhiteSpace(modelo))
            {
                Console.WriteLine("Marca e modelo são obrigatórios.");
                return;
            }

            _veiculoRepo.Add(new Veiculo { Marca = marca, Modelo = modelo });
            Console.WriteLine("Veículo cadastrado!");
        }

        private void ListarClientes()
        {
            var clientes = _clienteRepo.GetAll();
            if (!clientes.Any())
            {
                Console.WriteLine("Nenhum cliente cadastrado.");
                return;
            }

            foreach (var c in clientes)
                Console.WriteLine(c);
        }

        private void ListarVeiculos()
        {
            var veiculos = _veiculoRepo.GetAll();
            if (!veiculos.Any())
            {
                Console.WriteLine("Nenhum veículo cadastrado.");
                return;
            }

            foreach (var v in veiculos)
                Console.WriteLine(v);
        }

        private void AlugarVeiculo()
        {
            var clientes = _locacaoService.ListarClientesSemLocacaoAtiva();
            var veiculos = _locacaoService.ListarVeiculosDisponiveis();

            if (!clientes.Any() || !veiculos.Any())
            {
                Console.WriteLine("Sem clientes ou veículos disponíveis.");
                return;
            }

            Console.WriteLine("Clientes disponíveis:");
            foreach (var c in clientes)
                Console.WriteLine(c);

            Console.Write("ID do cliente: ");
            if (!int.TryParse(Console.ReadLine(), out int idCliente))
            {
                Console.WriteLine("ID inválido.");
                return;
            }

            Console.WriteLine("Veículos disponíveis:");
            foreach (var v in veiculos)
                Console.WriteLine(v);

            Console.Write("ID do veículo: ");
            if (!int.TryParse(Console.ReadLine(), out int idVeiculo))
            {
                Console.WriteLine("ID inválido.");
                return;
            }

            _locacaoService.AlugarVeiculo(idCliente, idVeiculo);
        }

        private void DevolverVeiculo()
        {
            Console.Write("ID da locação a ser devolvida: ");
            if (!int.TryParse(Console.ReadLine(), out int idLocacao))
            {
                Console.WriteLine("ID inválido.");
                return;
            }

            _locacaoService.DevolverVeiculo(idLocacao);
        }
    }
}

