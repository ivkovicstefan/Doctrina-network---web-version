using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doctrina___Web.Models
{
    public interface IDoctrinaUserRepository
    {
        public IEnumerable<DoctrinaUser> SearchUsers(string searchText);
    }
}
