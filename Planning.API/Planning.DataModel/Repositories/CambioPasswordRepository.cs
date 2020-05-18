using Framework.Data;
using Framework.Models;


namespace Planning.DataModel.Repositories
{
    public class CambioPasswordRepository : GenericRepository<CambioPassword>, ICambioPasswordRepository
    {        
        public CambioPasswordRepository(DataContext context) : base(context)
        {            
        }
    }
}
