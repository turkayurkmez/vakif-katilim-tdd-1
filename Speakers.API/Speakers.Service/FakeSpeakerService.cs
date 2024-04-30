using Speakers.Domain;

namespace Speakers.Service
{
    public class FakeSpeakerService : ISpeakerService
    {
        private List<Speaker> speakers = new List<Speaker>()
            {
                new Speaker{ Name ="Türkay", LastName="Ürkmez"},
                new Speaker{ Name = "Burak", LastName="Ağıt"},
                new Speaker { Name = "Melinda", LastName = "Günebakan" },
                new Speaker { Name = "Melahat", LastName = "Sümbül" },
                new Speaker { Name = "Melike", LastName = "Candan" },
            };

        public IEnumerable<Speaker> GetSpeakers()
        {
            return speakers;
        }

        public IEnumerable<Speaker> SearchSpeakersByName(string name)
        {
            var searchResult = speakers.Where(s => s.FullName.Contains(name, StringComparison.OrdinalIgnoreCase));
            return searchResult;
        }
    }
}
