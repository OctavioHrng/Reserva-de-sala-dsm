using Reserva_de_sala_dsm.Models;

namespace Reserva_de_sala_dsm.Interfaces
{
    public interface IUsuarioService
    {
        //Busca todos os usuários
        Task<IEnumerable<Usuario>> GetAllAsync();
        //Busca o usuário por ID
        Task<Usuario> GetByIdAsync(long id);
        //Cria um novo usuário
        Task<Usuario> CreateAsync(Usuario usuario);
        //Atualiza um usuário
        Task UpdateAsync(Usuario usuario);
        //Deleta um usuário
        Task<Usuario> DeleteAsync(long id);
    }
}
