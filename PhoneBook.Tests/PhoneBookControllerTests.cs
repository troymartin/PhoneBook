using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks.Dataflow;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhoneBook.Controllers;
using PhoneBook.Model;

namespace PhoneBook.Tests
{
    [TestClass]
    public class PhoneBookControllerTests
    {
        [TestMethod]
        public void Entries_Returns_Correct_Type()
        {
            var otions = Options.Create(new LiteDbContext.LiteDbConfig(@"MyData.db"));
            var phoneBookController = new PhoneBookController(new LiteDbContext(otions));
            var result = phoneBookController.Entries() as OkObjectResult;
            var entries = result?.Value as List<PhoneBookEntry>;
            Assert.IsNotNull(entries);
            Assert.IsInstanceOfType(entries,typeof(List<PhoneBookEntry>));
        }
    }
}
