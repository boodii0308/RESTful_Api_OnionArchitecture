using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Repo.Repository;

namespace Repo
{ 
    public interface IUnitOfWork: IDisposable
    {
        IUserRepo Users { get; }
        IQuoteRepo Quotes { get; }

        int Complete();
    }
}
