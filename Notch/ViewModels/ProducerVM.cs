namespace Notch.ViewModels
{
    using System.Collections.Generic;

    public class ProducerVM
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<TrackVM> Tracks { get; set; }
    }
}