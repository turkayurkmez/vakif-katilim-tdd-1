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
