public class Rent
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public Client? Cliente { get; set; }

    public int VeiculoId { get; set; }
    public Vehicle? Veiculo { get; set; }

    public DateTime DataRetirada { get; set; }
    public DateTime DataDevolucaoPrevista { get; set; }
    public DateTime? DataDevolvida { get; set; }

    public int QuantidadeDias { get; set; }
    public decimal ValorTotal { get; set; }
    public decimal ValorMulta { get; set; }

    public decimal CalcularValor()
    {
        if (Veiculo == null)
            throw new InvalidOperationException("Veículo não pode ser nulo para calcular valor.");

        var dias = (DataDevolucaoPrevista - DataRetirada).Days + 1;
        QuantidadeDias = dias > 0 ? dias : 1;

        decimal valorBase = QuantidadeDias * Veiculo.ValorDiaria;
        if (DataDevolvida.HasValue && DataDevolvida.Value > DataDevolucaoPrevista)
        {
            ValorMulta = valorBase * 0.15m;
        }
        else
        {
            ValorMulta = 0;
        }

        ValorTotal = valorBase + ValorMulta;
        return ValorTotal;
    }
}