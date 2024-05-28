using System.ComponentModel.DataAnnotations;

namespace CadProdutos.Models
{
	public class Produto
	{
        public int ProdutoId { get; set; }
        public string? Url { get; set; }
        [Display(Name = "Nome do Produto")]
        public string? Nome { get; set; }
        [Display(Name ="Informações Básicas")]
        public string? Informacoes { get; set; }
        public string? Fabricante { get; set; }
        [Display(Name = "Preço")]
        public decimal Preco { get; set; }
    }
}
