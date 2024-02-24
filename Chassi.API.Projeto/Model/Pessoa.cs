namespace Chassi.API.Projeto.Model
{
    public class Pessoa
    {
        public long Id { get; set; }    
        public string Nome { get; set; } = string.Empty;
        public string Sobrenome { get; set; } = string.Empty;
        public string Endereço { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Genero { get; set; } = string.Empty;
    }
}
