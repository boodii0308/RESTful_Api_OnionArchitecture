using Repo;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Repo;
using WebApplication1.Service.Module;


namespace Service
{
    
    public class QuoteService
    {
        public UnitOfWork UnitWork { get; set; }

        public QuoteService()
        {

            DBEntities _entities = new DBEntities();
            UnitWork = new UnitOfWork(_entities);
        }
        public IEnumerable<QuoteDTO> GetAllQuote()
        {
            var quotes = UnitWork.Quotes.GetAll();
            var result = quotes.Select(x => new QuoteDTO {
                QuoteID = x.QuoteID,
                QuoteType =  x.QuoteType,
                Contact = x.Contact,
                Task = x.Task,
                TaskType = x.TaskType,
                DueDate = x.DueDate
            }).ToList();
            return result;
        }
        public IEnumerable<QuoteDTO> GetAllQuote(string Quotete)
        {
            var quotes = UnitWork.Quotes.GetAll().Where(x=> x.QuoteType == Quotete);
            var result = quotes.Select(x => new QuoteDTO
            {
                QuoteID = x.QuoteID,
                QuoteType = x.QuoteType,
                Contact = x.Contact,
                Task = x.Task,
                TaskType = x.TaskType,
                DueDate = x.DueDate
            }).ToList();
            return result;
        }

        public QuoteDTO GetQuoteById(int id)
        {
            var quote = UnitWork.Quotes.GetAll();
            var quot = quote.Where(x => x.QuoteID == id)
                    .Select(x => new QuoteDTO()
                    {
                        QuoteID = x.QuoteID,
                        QuoteType = x.QuoteType,
                        Contact = x.Contact,
                        Task = x.Task,
                        TaskType = x.TaskType,
                        DueDate = x.DueDate
                    }).FirstOrDefault<QuoteDTO>();
            return quot;
        }
     
        public void PostNewQuote(QuoteDTO q)
        {
            var quote = UnitWork;
            quote.Quotes.Add( new QuoteTable(){
                QuoteID = q.QuoteID,
                QuoteType = q.QuoteType,
                Contact = q.Contact,
                Task = q.Task,
                TaskType = q.TaskType,
                DueDate = q.DueDate
            });
            quote.Complete();
        }
        public void PutUpdate(QuoteDTO q)
        {
            var quote = UnitWork;
            QuoteTable quoteTable = UnitWork.Quotes.GetByID(q.QuoteID);
            quoteTable.QuoteType = q.QuoteType;
            quoteTable.Contact = q.Contact;
            quoteTable.Task = q.Task;
            quoteTable.TaskType = q.TaskType;
            quoteTable.DueDate = q.DueDate;
            quote.Quotes.Update(quoteTable);
            quote.Complete();
        }
        public void DeleteQuote(QuoteDTO q)
        {
            var quote = UnitWork;
            QuoteTable quoteTable = UnitWork.Quotes.GetByID(q.QuoteID);
            quote.Quotes.Delete(quoteTable);
            quote.Complete();
        }

    }
}
