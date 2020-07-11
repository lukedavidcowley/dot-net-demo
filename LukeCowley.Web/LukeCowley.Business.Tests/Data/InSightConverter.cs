using LukeCowley.Business.Data.Converters;
using LukeCowley.Business.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace LukeCowley.Business.Tests.Data
{
    public class InSightConverterTests
    {
        [Test]
        public async Task DeserializationWorks()
        {
            //assemble
            using var streamReader = new StreamReader("G:\\Development\\VelocityWorks\\LukeCowley.Web\\LukeCowley.Business.Tests\\Data\\Dummy\\example-web-response.json");
            var json = await streamReader.ReadToEndAsync();

            //act
            var result = JsonConvert.DeserializeObject<IEnumerable<Sol>>(json, new InSightConverter());

            //assert
            Assert.IsTrue(result.Count() == 5);
        }
    }
}
