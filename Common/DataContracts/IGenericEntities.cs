using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DataContracts
{
    public interface IGenericEntities<T>
    {
        T Id { get; set; }
    }
}
