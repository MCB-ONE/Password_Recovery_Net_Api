using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PasswordRecovery.Domain.Entities;

namespace PasswordRecovery.Infrastructure.Persistence
{
    public class PasswordRevoceryDbContext : DbContext
    {
        public PasswordRevoceryDbContext(DbContextOptions<PasswordRevoceryDbContext> options) : base(options)
        { }

        public DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfigurationsFromAssembly(typeof(PasswordRevoceryDbContext).Assembly);

            ConfigureDateTimeProperties(modelBuilder);
            
            base.OnModelCreating(modelBuilder);
        }

        protected void ConfigureDateTimeProperties(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(DateTime) || property.ClrType == typeof(DateTime?))
                    {
                        property.SetColumnType("datetime2(0)");
                        property.SetValueConverter(new DateTimeConverter());
                    }
                }
            }
        }

        public class DateTimeConverter : ValueConverter<DateTime, DateTime>
        {
            public DateTimeConverter()
                : base(
                      v => v,
                      v => DateTime.SpecifyKind(DateTime.ParseExact(v.ToString(), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture), DateTimeKind.Utc)
                  )
            { }
        }
    }
}