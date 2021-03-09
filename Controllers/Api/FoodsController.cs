using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Defult.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Defult.Controllers.Api
{
    [Route("api/[controller]")]
    public class FoodsController : Controller
    {

        private Data _context;

        public FoodsController(Data data)
        {
            _context = data;
        }
        
                // GET: api/Foods
                [HttpGet]
                public IEnumerable<Food> Get()
                {
                    return _context.Foods.ToList();
                }

                // GET api/Foods/id
                [HttpGet("{id}")]
                public Food Get(int id)
                {
                    var Food = _context.Foods.SingleOrDefault(f =>f.Id==id);

                    if (Food==null)
                    {
                        throw new HttpRequestException(HttpStatusCode.NotFound.ToString());
                    }
                    return (Food);

                }


                // DELETE api/Foods/id
                [HttpDelete("{id}")]
                public void Delete(int id)
                {
                    var Food = _context.Foods.SingleOrDefault(f => f.Id == id);

                    if (Food == null)
                    {
                        throw new HttpRequestException(HttpStatusCode.NotFound.ToString());
                    }
                    _context.Foods.Remove(Food);
                    _context.SaveChanges();
                }
            }
    }
