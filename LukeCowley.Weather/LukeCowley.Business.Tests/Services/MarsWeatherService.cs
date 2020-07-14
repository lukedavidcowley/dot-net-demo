using LukeCowley.Business.Services;
using LukeCowley.Business.Tests.Mocking;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LukeCowley.Business.Tests.Services
{
    [TestFixture]
    public class MarsWeatherServiceTests
    {
        [Test]
        public async Task GetSolsAsync_ReturnsEmptyIEnumerableWithEmptyRepo()
        {
            //assemble
            var repo = new SolRepositoryBuilder().Build();
            var provider = new MarsWeatherDataProviderBuilder().Build();

            IMarsWeatherService service = new MarsWeatherService(repo, provider);

            //act
            var sols = await service.GetSolWeekAsync();

            //assert
            Assert.IsTrue(sols.Count() == 0);
        }
        [Test]
        public async Task GetSolsAsyncAsync_ReturnsResultsIfRepositoryIsNotEmpty()
        {
            //assemble
            var repo = new SolRepositoryBuilder()
                .ConfigureOneSol()
                .Build();
            var provider = new MarsWeatherDataProviderBuilder().Build();

            IMarsWeatherService service = new MarsWeatherService(repo, provider);

            //act
            var sols = await service.GetSolWeekAsync();

            //assert
            Assert.IsTrue(sols.Any());
        }

        [Test]
        public Task GetSolsAsyncAsync_ReturnsCorrectResults()
        {
            //assemble

            //act

            //assert

            throw new NotImplementedException();
        }

        [Test]
        public Task UpdateWeatherAsync_CorrectlyUpdatesRepository()
        {
            //assemble

            //act

            //assert

            throw new NotImplementedException();
        }
    }
}
