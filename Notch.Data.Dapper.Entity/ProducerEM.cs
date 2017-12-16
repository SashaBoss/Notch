using Dapper.Contrib.Extensions;

namespace Notch.Data.Dapper.Entity
{
    using System.Collections.Generic;

    [Table("Producer")]
    public class ProducerEM
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<TrackEM> Tracks { get; set; }
    }
}