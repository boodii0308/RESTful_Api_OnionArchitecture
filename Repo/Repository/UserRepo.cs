using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Repo.Repository
{
    public class UserRepo : GenericRepo<UserMaster>, IUserRepo
    {
        private DBEntities context;
        public UserRepo(DBEntities _context) : base(_context)
        {
            context = _context;
        }
    }
}
