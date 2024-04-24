using api_diploma.Data.Models;
using Microsoft.EntityFrameworkCore;
using File = api_diploma.Data.Models.File;

namespace api_diploma.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Person> People { get; set; }
        public DbSet<Award> Awards { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentTemplate> DocumentTemplates { get; set; }
        public DbSet<File> File { get; set; }
        public DbSet<Injurie> Injurie { get; set; }
        public DbSet<MedicalData> MedicalData { get; set; }
        public DbSet<Parameter> Parameter { get; set; }
        public DbSet<ServiceHistory> ServiceHistory { get; set; }
        public DbSet<CombatParticipation> CombatParticipation { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ChangePersonHistory> ChangePersonHistory { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<CalendarEvent> CalendarEvents { get; set; }
    }
}
