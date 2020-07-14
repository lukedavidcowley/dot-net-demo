using LukeCowley.Business.Data.Providers;
using LukeCowley.Business.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LukeCowley.Business.Tests.Mocking
{
    public class MarsWeatherDataProviderBuilder
    {
        private Mock<IMarsWeatherDataProvider> _provider;
        public MarsWeatherDataProviderBuilder()
        {
            _provider = new Mock<IMarsWeatherDataProvider>();
            _provider.Setup(p => p.GetRecentSolsAsync()).ReturnsAsync(() => new List<Sol>().AsQueryable());
        }

        public IMarsWeatherDataProvider Build()
        {
            return _provider.Object;
        }
    }
}
