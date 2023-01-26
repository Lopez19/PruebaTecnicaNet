using Microsoft.EntityFrameworkCore;
using PruebaTecnicaNet.Models;

namespace PruebaTecnicaNet.Datos
{
    public class AplicationDbContex : DbContext
    {
        public AplicationDbContex(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Nomina> Nominas { get; set; }
        public DbSet<SpConsultarNomina> SpConsultarNominas { get; set; }
    }
}
