namespace Notch.Infrastructure.Business
{
    using System.Collections.Generic;
    using Notch.Domain;
    using System;

    public interface ITrackDM : IDisposable
    {
        IEnumerable<Track> GetTracks();
        long AddTrack(Track track);
        void DeleteTrack(int trackId);
        void Update(Track track);
    }
}