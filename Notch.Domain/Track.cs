namespace Notch.Domain
{
    using System.Collections.Generic;

    public class Track
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Length { get; set; }
        public short BPM { get; set; }

        public ICollection<Producer> Producers { get; set; }
    }
}