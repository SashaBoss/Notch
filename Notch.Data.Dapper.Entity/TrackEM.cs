using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Notch.Data.Dapper.Entity
{
    [Table("Track")]
    public class TrackEM
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Length { get; set; }
        public short BPM { get; set; }

        public ICollection<ProducerEM> Producers { get; set; }
    }
}