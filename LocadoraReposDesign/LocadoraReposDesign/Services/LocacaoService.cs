using LocadoraReposDesign.Domain;
using LocadoraReposDesign.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraReposDesign.Services
{
    public class LocacaoService
    {
        private readonly IRepository<Locacao> _locacoes;
        private readonly IRepository<Cliente> _clientes;
        private readonly IRepository<Veiculo> _veiculos;

        public LocacaoService(
            IRepository<Locacao> locacoes,
            IRepository<Cliente> clientes,
            IRepository<Veiculo> veiculos)
        {
            _locacoes = locacoes;
            _clientes = clientes;
            _veiculos = veiculos;
        }

        public void AlugarVeiculo(int clienteId, int veiculoId)
        {
            var cliente = _clientes.GetById(clienteId);
            var veiculo = _veiculos.GetById(veiculoId);

            if (cliente == null)
            {
                Console.WriteLine("Cliente não encontrado.");
                return;
            }
            if (veiculo == null)
            {
                Console.WriteLine("Veículo não encontrado.");
                return;
            }
            if (!veiculo.Disponivel)
            {
                Console.WriteLine("Veículo não está disponível.");
                return;
            }

            var locacao = new Locacao
            {
                ClienteId = clienteId,
                VeiculoId = veiculoId,
                DataLocacao = DateTime.Now
            };

            veiculo.Disponivel = false;

            _locacoes.Add(locacao);
            _veiculos.Update(veiculo);

            Console.WriteLine($"Veículo alugado com sucesso! Locação #{locacao.Id}");
        }

        public void DevolverVeiculo(int locacaoId)
        {
            var locacao = _locacoes.GetById(locacaoId);
            if (locacao == null)
            {
                Console.WriteLine("Locação não encontrada.");
                return;
            }

            if (locacao.DataDevolucao != null)
            {
                Console.WriteLine("Este veículo já foi devolvido.");
                return;
            }

            var veiculo = _veiculos.GetById(locacao.VeiculoId);
            if (veiculo == null)
            {
                Console.WriteLine("Veículo não encontrado.");
                return;
            }
            
            locacao.DataDevolucao = DateTime.Now;
            veiculo.Disponivel = true;

            _locacoes.Update(locacao);
            _veiculos.Update(veiculo);

            Console.WriteLine("Veículo devolvido com sucesso.");
        }

        public void ListarLocacoes()
        {
            var todas = _locacoes.GetAll();
            if (!todas.Any())
            {
                Console.WriteLine("Nenhuma locação registrada.");
                return;
            }

            foreach (var l in todas)
            {
                Console.WriteLine(l);
            }
        }
        public List<Cliente> ListarClientesSemLocacaoAtiva()
        {
            var locacoesAtivas = _locacoes.GetAll()
                .Where(l => !l.DataDevolucao.HasValue)
                .Select(l => l.ClienteId)
                .ToHashSet();

            return _clientes.GetAll()
                .Where(c => !locacoesAtivas.Contains(c.Id))
                .ToList();
        }

        public List<Veiculo> ListarVeiculosDisponiveis()
        {
            return _veiculos.GetAll()
                .Where(v => v.Disponivel)
                .ToList();
        }
    }
}
