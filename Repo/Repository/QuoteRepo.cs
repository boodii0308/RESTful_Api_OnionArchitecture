using Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Repo.Repository
{
    public class QuoteRepo : GenericRepo<QuoteTable>, IQuoteRepo
    {
        private DBEntities context;
        public QuoteRepo(DBEntities _context) : base(_context)
        {
            context = _context;
        }

    }
}
