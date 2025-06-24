using LocadoraReposDesign.Domain;
using LocadoraReposDesign.Repositories;
using LocadoraReposDesign.Services;

namespace LocadoraConsole.Testes;

public static class Simulador
{
    public static void ExecutarSimulacao(
        ClienteRepository clienteRepo,
        VeiculoRepository veiculoRepo,
        LocacaoService locacaoService)
    {
        Console.WriteLine("== Simulação de teste automático ==");

        // 1. Cadastrar clientes
        var joao = new Cliente { Nome = "João", Cpf = "11111111111" };
        var maria = new Cliente { Nome = "Maria", Cpf = "22222222222" };
        clienteRepo.Add(joao);
        clienteRepo.Add(maria);

        // 2. Cadastrar veículos
        var uno = new Veiculo { Marca = "Fiat", Modelo = "Uno" };
        var gol = new Veiculo { Marca = "Volkswagen", Modelo = "Gol" };
        veiculoRepo.Add(uno);
        veiculoRepo.Add(gol);

        // 3. Alugar veículo para João
        locacaoService.AlugarVeiculo(joao.Id, uno.Id);

        // 4. Tentar alugar de novo o mesmo veículo (deve falhar)
        locacaoService.AlugarVeiculo(maria.Id, uno.Id);

        // 5. Devolver veículo
        locacaoService.DevolverVeiculo(1);

        // 6. Alugar novamente (agora deve funcionar)
        locacaoService.AlugarVeiculo(maria.Id, uno.Id);

        // 7. Listar locações
        locacaoService.ListarLocacoes();
    }
}
