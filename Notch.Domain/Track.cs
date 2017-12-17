namespace Notch.Domain
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The track.
    /// </summary>
    public class Track
    {
        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Length.
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// Gets or sets BPM.
        /// </summary>
        public short BPM { get; set; }

        /// <summary>
        /// Gets or sets Producers of track.
        /// </summary>
        public ICollection<Producer> Producers { get; set; }
    }
}