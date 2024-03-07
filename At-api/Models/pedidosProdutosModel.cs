namespace At_api.Models
{
    public class pedidosProdutosModel
    {
        public int Id { get; set; }
        public int Quantidade { get; set;}
        public int ProdutoId { get; set; }
        public ProdutosModel Produtos { get; set; }
        public int CategoriaId { get; set; }
        public CategoriasModel Categorias { get; set; }



    }
}
