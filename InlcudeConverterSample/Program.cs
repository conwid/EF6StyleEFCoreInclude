using IncludeConverterSample.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace IncludeConverterSample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (NorthwindContext ctx = new NorthwindContext())
            {
                var query = ctx.Categories.Include(c => c.Products.Select(p => p.OrderDetails.Select(od => od.Order.Customer)));
                var x = await query.ToListAsync();
            }
            Console.ReadLine();
        }
    }
}
