using Chassi.API.Projeto.Model;
using Chassi.API.Projeto.Services.Interface;

namespace Chassi.API.Projeto.Services.Implementations
{
    public class PessoaServicoImplementacao : IPessoaService
    {
        private volatile int count;

        public Pessoa Incluir(Pessoa pessoa)
        {
            return pessoa;
        }
        public Pessoa Atualizar(Pessoa pessoa)
        {
            return pessoa;
        }

        public Pessoa BuscarPorId(long id)
        {
            return new Pessoa { 
                Id = incrementaERetorna(),
                Nome = "Gabriel",
                Sobrenome = "Lopez" ,
                Email = "gabriel@gmail.com",
                Endereço = "Rua Nova, 1",
                Genero = "Masculino"              
            };
        }
        public void Excluir(long id)
        {
            
        }
        public List<Pessoa> BuscarTodos()
        {
            List<Pessoa> pessoas = new List<Pessoa>();
            for (int i = 0; i < 8; i++)
            {
                Pessoa pessoa = MockPessoa(i);
                pessoas.Add(pessoa);
            }
            return pessoas;
        }

        private Pessoa MockPessoa(int i)
        {
            return new Pessoa
            {
                Id = incrementaERetorna(),
                Nome = "Gabriel",
                Sobrenome = "Lopez",
                Email = "gabriel@gmail.com",
                Endereço = "Rua Nova, 1",
                Genero = "Masculino"
            };
        }

        private long incrementaERetorna()
        {
            return Interlocked.Increment(ref count);
        }
    }
}
