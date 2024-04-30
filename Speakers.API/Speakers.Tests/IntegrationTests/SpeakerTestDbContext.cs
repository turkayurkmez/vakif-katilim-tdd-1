using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Speakers.Domain;
using Speakers.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speakers.Tests.IntegrationTests
{
    public class SpeakerTestDbContext : SpeakerDbContext
    {
        public SpeakerTestDbContext(DbContextOptions<SpeakerDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            using (StreamReader reader = new StreamReader("../../../Data/speakers.json"))
            {
                var json = reader.ReadToEnd();
                var data = JsonConvert.DeserializeObject<Speaker[]>(json);
                modelBuilder.Entity<Speaker>().HasData(data);
            }
        }
    }
}
