using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Ultility;

public class GenerateCode
{
    private static readonly Random random = new Random();
    public static string GenerateProductCode()
    {

        int proRand = random.Next(100000, 999999);
        return "PRO" + proRand;
    }

    public static string GenerateBuyerCode()
    {

        int proRand = random.Next(100000, 999999);
        return "BUY" + proRand;
    }

    public static string GenerateOrderCode()
    {

        int proRand = random.Next(100000, 999999);
        return "ORD" + proRand;
    }
}
