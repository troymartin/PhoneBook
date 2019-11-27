using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Model;

namespace PhoneBook.Extensions
{
    public static class LiteDbServiceExtentions
    {
        public static void AddLiteDb(this IServiceCollection services, string databasePath)
        {
            services.AddTransient<LiteDbContext, LiteDbContext>();
            services.Configure<LiteDbContext.LiteDbConfig>(options => options.DatabasePath = databasePath);
        }
    }
}
