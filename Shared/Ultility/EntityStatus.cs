using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Ultility;

public static class EntityStatus
{
    public enum OrderStatus
    {
        pending = 0, created = 1, check_balance = 2, done = 3, cancel = 4
    }
    public enum ProductStatus 
    {
        Active = 0, Inactive = 1   
    }

}
