using Microsoft.EntityFrameworkCore;
using T.Models.Models;

namespace T.DataAccess.Data
{
    public class TechTrialContext : DbContext
    {
        public TechTrialContext(DbContextOptions<TechTrialContext> options)
      : base(options)
        {
        }

        public virtual DbSet<Candidato> Candidato { get; set; }
    }
}
