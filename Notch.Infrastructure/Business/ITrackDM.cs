namespace Notch.Infrastructure.Business
{
    using System.Collections.Generic;
    using Notch.Domain;
    using System;

    public interface ITrackDM : IDisposable
    {
        IEnumerable<Track> GetTracks();
    }
}