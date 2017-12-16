using Notch.Infrastructure.Data;

namespace Notch.Business
{
    using Notch.Infrastructure.Request;

    using System.Collections.Generic;
    using Notch.Domain;
    using Notch.Infrastructure.Business;

    public class TrackDM : BusinessContextBase, ITrackDM
    {
        public TrackDM(IRequestContext requestContext) : base(requestContext)
        {
        }

        public IEnumerable<Track> GetTracks()
        {
            using (var repo = this.Factory.GetService<ITrackRepository>(this.DataContext))
            {
                var tracks = repo.GetAll();

                return this.EntService.ConvertTo(tracks, default(IEnumerable<Track>));
            }
        }
    }
}