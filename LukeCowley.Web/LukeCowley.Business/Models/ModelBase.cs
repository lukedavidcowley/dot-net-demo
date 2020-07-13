using System;
using System.Collections.Generic;
using System.Text;

namespace LukeCowley.Business.Models
{
    public abstract class ModelBase
    {
        public virtual bool IsValid()
        {
            return true;
        }
    }
}
