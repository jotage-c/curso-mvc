using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Vehicle
{
    public int Id { get; set; }

    [Required]
    public string Modelo { get; set; }

    [Required]
    public string Marca { get; set; }

    [Required]
    public string Placa { get; set; }

    [Required]
    [Display(Name = "Valor da Diária")]
    [Column(TypeName = "decimal(10, 2)")]
    public decimal ValorDiaria { get; set; }

    public bool EstaLocado { get; set; } = false;

    public List<Rent>? Locacoes { get; set; }
}