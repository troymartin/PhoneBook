using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiteDB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Model;

namespace PhoneBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneBookController : ControllerBase
    {

        private readonly LiteDbContext _context;

        public PhoneBookController(LiteDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Entries")]
        public IActionResult Entries()
        {
            using (var db = new LiteDatabase(@"MyData.db"))
            {
                var entries = db.GetCollection<PhoneBookEntry>("phonebook");
                return Ok(entries.FindAll().ToList());
            }
        }

        [HttpPost]
        [Route("Entries")]
        public IActionResult Entries(PhoneBookEntry entry)
        {
            using (var db = new LiteDatabase(@"MyData.db"))
            {
                var entries = db.GetCollection<PhoneBookEntry>("phonebook");

                var newEntry = new PhoneBookEntry()
                {
                    Name = entry.Name,
                    Number = entry.Number,
                    Notes = entry.Notes
                };

                entries.Insert(newEntry);

                entries.EnsureIndex(x => x.Name);

                var results = entries;
                return Ok(results.FindAll().ToList());
            }
        }
        
    }
}