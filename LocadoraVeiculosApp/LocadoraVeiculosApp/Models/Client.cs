using LocadoraVeiculosApp.Models;
using System.ComponentModel.DataAnnotations;

public class Client
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório.")]
    public string? Nome { get; set; }

    [Required(ErrorMessage = "O e-mail é obrigatório.")]
    [EmailAddress(ErrorMessage = "Formato de e-mail inválido.")]
    public string Email { get; set; }

    [Required]
    public string Telefone { get; set; }

    public List<Rent>? Locacoes { get; set; }
}