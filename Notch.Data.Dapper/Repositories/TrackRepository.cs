namespace Notch.Data.Dapper.Repositories
{
    using System;
    using Notch.Data.Dapper.Entity;
    using Notch.Infrastructure.Data;

    public class TrackRepository : RepositoryDapper<TrackEM, int>, ITrackRepository
    {
        public TrackRepository(IDataContext context) : base(context)
        {
        }

        public TrackEM GetByProducer(ProducerEM producer)
        {
            throw new NotImplementedException();
        }
    }
}