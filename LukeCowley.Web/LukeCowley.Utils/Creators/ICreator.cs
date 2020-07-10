using System;
using System.Collections.Generic;
using System.Text;

namespace LukeCowley.Utils.Creators
{
    public interface ICreator<T>
    {
        T Build();
    }
}
