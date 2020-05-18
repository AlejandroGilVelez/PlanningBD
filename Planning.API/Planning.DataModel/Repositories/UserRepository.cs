using Framework.Data;
using Framework.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Planning.DataModel.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private new readonly DataContext context;

        public UserRepository(DataContext context) : base(context)
        {
            this.context = context;
        }      

        public async Task<User> ObtenerPorEmail(string email)
        {
            return await context.Users.FirstOrDefaultAsync(x => x.Activo && x.Correo.ToLower() == email.ToLower());
        }
    }
}
