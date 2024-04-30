namespace Speakers.Domain
{
    public class Speaker
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FullName { get => $"{Name} {LastName}"; }
    }
}
