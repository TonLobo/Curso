namespace SisLoja.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string? NomeCliente { get; set; } //= string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
