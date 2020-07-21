using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doctrina___Web.Models
{
    public class DoctrinaUserRepository : IDoctrinaUserRepository
    {
        private readonly DoctrinaDBContext _dbContext;

        public DoctrinaUserRepository(DoctrinaDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public IEnumerable<DoctrinaUser> SearchUsers(string searchText)
        {
            return _dbContext.Users.Where(u => u.UserName.Contains(searchText));
        }
    }
}
