using System;
using Microsoft.EntityFrameworkCore;

namespace COVID19Relief.Middleware.Services
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {

        }
    }
}
