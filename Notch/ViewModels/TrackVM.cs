using System.Collections.Generic;

namespace Notch.ViewModels
{
    public class TrackVM
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int Length { get; set; }

        public ICollection<ProducerVM> Producers { get; set; }
    }
}