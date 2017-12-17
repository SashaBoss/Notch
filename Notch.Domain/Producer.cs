using System.Collections.Generic;

namespace Notch.Domain
{
    public class Producer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Track> Tracks { get; set; }
    }
}
