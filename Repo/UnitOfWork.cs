using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using WebApplication1.Repo.Repository;

namespace Repo
{
    public class UnitOfWork: IUnitOfWork
    {
        private DBEntities _context;
        public UnitOfWork(DBEntities context)
        {
            _context = context;
            Users = new UserRepo(_context);
            Quotes = new QuoteRepo(_context);
        }
        public IUserRepo Users { get; set; }
        public IQuoteRepo Quotes { get; set; }


        public int Complete() 
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
        _context.Dispose();
        }
    }
}
