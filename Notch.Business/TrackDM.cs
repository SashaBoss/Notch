namespace Notch.Business
{
    using Notch.Infrastructure.Request;
    using Notch.Data.Dapper.Entity;
    using Notch.Infrastructure.Data;
    using System.Collections.Generic;
    using Notch.Domain;
    using Notch.Infrastructure.Business;

    public class TrackDM : BusinessContextBase, ITrackDM
    {
        public TrackDM(IRequestContext requestContext) : base(requestContext)
        {
        }

        public Track GetTrack(int trackId)
        {
            using (var repo = this.Factory.GetService<ITrackRepository>(this.DataContext))
            {
                var track = repo.Get(trackId);

                return this.EntService.ConvertTo(track, default(Track));
            }
        }

        public IEnumerable<Track> GetTracks()
        {
            using (var repo = this.Factory.GetService<ITrackRepository>(this.DataContext))
            {
                var tracks = repo.GetAll();

                return this.EntService.ConvertTo(tracks, default(IEnumerable<Track>));
            }
        }

        public long AddTrack(Track track)
        {
            using (var repo = this.Factory.GetService<ITrackRepository>(this.DataContext))
            {
                var trackEm = this.EntService.ConvertTo<Track, TrackEM>(track);
                var trackId = repo.Insert(trackEm);

                return trackId;
            }
        }

        public void DeleteTrack(int trackId)
        {
            using (var repo = this.Factory.GetService<ITrackRepository>(this.DataContext))
            {
                repo.Delete(trackId);
            }
        }

        public void Update(Track track)
        {
            using (var repo = this.Factory.GetService<ITrackRepository>(this.DataContext))
            {
                repo.Update(this.EntService.ConvertTo<Track, TrackEM>(track));
            }
        }
    }
}