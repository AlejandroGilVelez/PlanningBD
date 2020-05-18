using Framework.Models;
using System.Threading.Tasks;

namespace Planning.DataModel.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> ObtenerPorEmail(string email);
    }
}
