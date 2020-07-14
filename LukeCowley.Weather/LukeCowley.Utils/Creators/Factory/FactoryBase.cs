using System;
using System.Collections.Generic;
using System.Text;

namespace LukeCowley.Utils.Creators.Factory
{
    public abstract class FactoryBase<T> : ICreator<T>
    {
        protected T _result;
        public virtual T Build()
        {
            return _result;
        }

        public abstract void Configure(int id);
    }
}
