using Reserva_de_sala_dsm.Models;

namespace Reserva_de_sala_dsm.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetAllAsync();
        Task<Usuario> GetByIdAsync(long id);
        Task<Usuario> GetByEmailAsync(string email);
        Task AddAsync(Usuario usuario);
        void Update(Usuario usuario);
        void Delete(Usuario usuario);
        Task SaveChangeAsync();
    }
}

