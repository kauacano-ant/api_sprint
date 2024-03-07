namespace At_api.Models
{
    public class PedidosModel
    {
        public int Id { get; set; }
        public string EnderecoEntrega { get; set; }
        public int usuarioId { get; set; }
        public UsuarioModel Usuario { get; set; }

    }
}
