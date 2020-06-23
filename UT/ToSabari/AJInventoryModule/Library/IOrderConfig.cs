using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AJInventoryModule.Library
{
    public interface IOrderConfig
    {
        bool IsOrderBanned { get; set; }
    }
}
