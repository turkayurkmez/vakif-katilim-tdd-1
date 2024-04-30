using Speakers.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speakers.Service
{
    public class RealSpeakerService : ISpeakerService
    {
        public IEnumerable<Speaker> GetSpeakers()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Speaker> SearchSpeakersByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
