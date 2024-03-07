namespace At_api.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateOnly DataNasc { get; set; }
    }
}
