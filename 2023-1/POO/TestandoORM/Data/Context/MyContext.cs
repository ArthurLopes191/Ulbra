using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestandoORM.Data.Context
{
    public class MyContext : DbContext
    {
        protected string DbPath { get; }
        public MyContext()
        {
            string path = Directory.GetCurrentDirectory();
            DbPath = System.IO.Path.Join(path, "gestaoclick.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}