using System;
using System.Collections.Generic;
using System.Text;

namespace LukeCowley.Utils.Creators.Builder
{
    public abstract class BuilderBase<T> : ICreator<T>
    {
        protected T _product { get; set; }

        public BuilderBase() 
        {
            _product = default;
        }
        public BuilderBase(T initial)
        {
            _product = initial;
        }
        public T Build()
        {
            return _product;
        }

    }
}
