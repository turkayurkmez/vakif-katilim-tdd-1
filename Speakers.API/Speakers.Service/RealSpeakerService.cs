using Speakers.Domain;
using Speakers.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speakers.Service
{
    public class RealSpeakerService : ISpeakerService
    {

        private SpeakerDbContext dbContext;

        public RealSpeakerService(SpeakerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Speaker Create(Speaker speaker)
        {
            dbContext.Speakers.Add(speaker);
            dbContext.SaveChanges();
            return speaker;
        }

        public Speaker GetSpeaker(int id)
        {
            return dbContext.Speakers.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Speaker> GetSpeakers()
        {
            return dbContext.Speakers.ToList();
        }

        public IEnumerable<Speaker> SearchSpeakersByName(string name)
        {
            return dbContext.Speakers.ToList().Where(s => s.FullName.Contains(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
