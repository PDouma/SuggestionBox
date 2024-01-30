using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using suggestionbox.Models;

namespace suggestionbox.Data
{
    public class suggestionboxContext : DbContext
    {
        public suggestionboxContext (DbContextOptions<suggestionboxContext> options)
            : base(options)
        {
        }

        public DbSet<suggestionbox.Models.Suggestion> Suggestion { get; set; } = default!;
    }
}
