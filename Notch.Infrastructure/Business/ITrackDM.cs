namespace Notch.Infrastructure.Business
{
    using System.Collections.Generic;
    using Notch.Domain;
    using System;

    /// <summary>
    /// Operations with tracks.
    /// </summary>
    public interface ITrackDM : IDisposable
    {
        /// <summary>
        /// Returns all tracks.
        /// </summary>
        /// <returns>All tracks in system.</returns>
        IEnumerable<Track> GetTracks();

        /// <summary>
        /// Creates new track.
        /// </summary>
        /// <param name="track">Track to create.</param>
        /// <returns>Id of created track.</returns>
        long AddTrack(Track track);

        /// <summary>
        /// Deletes the track.
        /// </summary>
        /// <param name="trackId">Track's id.</param>
        void DeleteTrack(int trackId);

        /// <summary>
        /// Updates the track info.
        /// </summary>
        /// <param name="track">Track to update.</param>
        void Update(Track track);
    }
}