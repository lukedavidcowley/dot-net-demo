using System;
using System.Collections.Generic;
using System.Linq;
using LukeCowley.Business.Data;
using LukeCowley.Business.Models;
using Moq;

namespace LukeCowley.Business.Tests.Mocking
{
    public class SolRepositoryBuilder
    {
        private Mock<IRepository<Sol>> _repo;

        public SolRepositoryBuilder()
        {
            _repo = new Mock<IRepository<Sol>>();
            _repo.Setup(r => r.GetAsync()).ReturnsAsync(() => new List<Sol>().AsQueryable());
        }
        public SolRepositoryBuilder ConfigureOneSol()
        {
            _repo.Setup(r => r.GetAsync()).ReturnsAsync(() => new List<Sol>(){ new Sol() }.AsQueryable());
            return this;
        }

        public IRepository<Sol> Build()
        {
            return _repo.Object;
        }
    }
}
