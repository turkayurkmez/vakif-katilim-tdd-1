using System.ComponentModel.DataAnnotations.Schema;

namespace Speakers.Domain
{
    public class Speaker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        [NotMapped]
        public string FullName { get => $"{Name} {LastName}"; }
    }
}
