using System.ComponentModel.DataAnnotations.Schema;

namespace Chassi.API.Projeto.Model
{
    [Table("pessoa")]
    public class Pessoa
    {        
        [Column("Id")]
        public long Id { get; set; }    
        [Column("Primeiro_Nome")]
        public string Nome { get; set; } = string.Empty;
        [Column("Segundo_Nome")]
        public string Sobrenome { get; set; } = string.Empty;
        [Column("Endereco")]
        public string Endereço { get; set; } = string.Empty;
        [Column("Email")]
        public string Email { get; set; } = string.Empty;
        [Column("Genero")]
        public string Genero { get; set; } = string.Empty;
    }
}
