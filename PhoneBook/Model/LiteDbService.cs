using System;
using LiteDB;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace PhoneBook.Model
{
    public class LiteDbContext
    {
        public readonly LiteDatabase Context;
        public LiteDbContext(IOptions<LiteDbConfig> configs)
        {
            try
            {
                var db = new LiteDatabase(configs.Value.DatabasePath);
                if (db != null)
                    Context = db;
            }
            catch (Exception ex)
            {
                throw new Exception("Can find or create LiteDb database.", ex);
            }
        }

        public class LiteDbConfig
        {
            public string DatabasePath { get; set; }

            public LiteDbConfig()
            {

            }

            public LiteDbConfig(string dbPath)
            {
                DatabasePath = dbPath;
            }
        }
    }

    
}
