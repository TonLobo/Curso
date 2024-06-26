using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loja.Models
{
    public class Venda
    {
        public int VendaId { get; set; }
        public int CarroId { get; set; }
        public Carro? Carro { get; set; }
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }
        [Display(Name = "Qtd")]
        public int Qtd { get; set; }
        [Display(Name = "Venda")]
        public decimal ValorVenda { get; set; }
        [Display(Name = "Entrada")]
        public decimal? ValorEntrada { get; set; }
        [Display(Name = "A Vista")]
        public bool IsAVista { get; set; }
        public int? Parcelas { get; set; }
        [Display(Name = "Juros")]
        public decimal? ValorJuros { get; set; }
        [Display(Name = "Banco")]
        public string? BancoFinanciamento { get; set; }
        public int VendedorId { get; set; }
        public Usuario? Vendedor { get; set; }
        [Display(Name = "Comissão")]
        public decimal? ComissaoVendedor { get; set; }
        [Display(Name = "Entrega")]
        public DateTime? DataEntrega { get; set; }
    }
}
