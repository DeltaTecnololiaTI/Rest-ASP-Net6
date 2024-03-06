using Chassi.API.Projeto.Model;

namespace Chassi.API.Projeto.Repository.Interface
{
    public interface IPessoaRepository
    {
        Pessoa Incluir(Pessoa pessoa);
        Pessoa BuscarPorId(long id);
        List<Pessoa> BuscarTodos();
        Pessoa Atualizar(Pessoa pessoa);
        void Excluir(long id);
        bool Exists(long id);
    }
}
