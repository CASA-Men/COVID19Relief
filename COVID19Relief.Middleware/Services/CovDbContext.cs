using System;
using Microsoft.EntityFrameworkCore;

namespace COVID19Relief.Middleware.Services
{
    public class CovDbContext : DbContext
    {
        public CovDbContext(DbContextOptions<CovDbContext> options) : base(options)
        {

        }
    }
}
