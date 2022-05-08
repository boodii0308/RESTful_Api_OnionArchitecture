using AutoMapper;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Security.Claims;
using WebApplication1.Models;
using WebApplication1.Service.Module;
using HttpDeleteAttribute = System.Web.Http.HttpDeleteAttribute;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPatchAttribute = System.Web.Http.HttpPatchAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using HttpPutAttribute = System.Web.Http.HttpPutAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;



namespace WebApplication1.Controllers
{
    [System.Web.Http.Authorize()]
    public class QuoteController : ApiController
    {
        private readonly QuoteService quoteService;
        private MapperConfiguration config;
        private IMapper mapper;

        public QuoteController()
        {
            quoteService = new QuoteService();
            config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<QuoteDTO, QuoteM>();
                cfg.CreateMap<QuoteM, QuoteDTO>();
            });
            mapper = config.CreateMapper();
        }


        [HttpGet]
        public IHttpActionResult GetAllQuotes()
        {
            IList<QuoteM> Quote = null;

            var allQuote = quoteService.GetAllQuote();

            Quote = (IList<QuoteM>)mapper.Map<IEnumerable<QuoteDTO>, IEnumerable<QuoteM>>(allQuote);
     

            if (Quote.Count == 0)
            {
                return Content(HttpStatusCode.NotFound, "There is no more Quote!!!");
            }

            return Ok(Quote);
        }


        [HttpGet]
        public IHttpActionResult GetAllQuotes(string QuoteType)
        {
            IList<QuoteM> Quote = null;

            var allQuote = quoteService.GetAllQuote(QuoteType);

            Quote = (IList<QuoteM>)mapper.Map<IEnumerable<QuoteDTO>, IEnumerable<QuoteM>>(allQuote);


            if (Quote.Count == 0)
            {
                return Content(HttpStatusCode.NotFound, "There is no Quote with Quotetype = " + QuoteType + " !!!");
            }

            return Ok(Quote);
        }

        [HttpGet]
        [Route("api/quote/{id}")]
        public IHttpActionResult GetUsersById(int id)
        {
            QuoteM Quote = null;
            var qu = quoteService.GetQuoteById(id);
            Quote = mapper.Map<QuoteDTO, QuoteM>(qu);

            if (Quote == null)
            {
                return Content(HttpStatusCode.NotFound, "There is no Quote with id = " + id + " !!!");
            }

            return Ok(Quote);
        }

        [HttpPost]
        public IHttpActionResult PostNewQuote(QuoteM quote)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");
            else {
                QuoteDTO q = mapper.Map<QuoteM, QuoteDTO>(quote);
                quoteService.PostNewQuote(q);
                return Ok();
            }
        }


        [HttpPut]
        public IHttpActionResult PutQuote(QuoteM quote)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid Quote model");

            else
            {
                QuoteDTO exQuote = quoteService.GetQuoteById(quote.QuoteID);

                if (exQuote != null)
                {
                    quoteService.PutUpdate(mapper.Map<QuoteM, QuoteDTO>(quote));
                }
                else
                {
                    quoteService.PostNewQuote(mapper.Map<QuoteM, QuoteDTO>(quote));
                }
                return Ok();
            }
        }
        [HttpPatch]
        public IHttpActionResult PatchQuote(QuoteM quote)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid Quote model");

            else
            {
                QuoteDTO exQuote = quoteService.GetQuoteById(quote.QuoteID);

                if (exQuote != null)
                {
                    quoteService.PutUpdate(mapper.Map<QuoteM, QuoteDTO>(quote));
                }
                else
                {
                    return Content(HttpStatusCode.NotFound, "Quote does not Exists!!!");
                }
                return Ok();
            }   
        }
        [HttpDelete]
        [Route("api/quote/{id}")]
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid Quote id");
            else
            {
                QuoteDTO exQuote = quoteService.GetQuoteById(id);

                if (exQuote != null)
                {
                    quoteService.DeleteQuote(exQuote);
                }
                else
                {
                    return Content(HttpStatusCode.NotFound, "Quote does not Exists!!!");
                }
                return Ok();
            }
        }
    }
}
