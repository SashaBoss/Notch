namespace Notch.Infrastructure.Data
{
    using Notch.Data.Dapper.Entity;

    public interface ITrackRepository : IRepository<TrackEM, int>
    {
        TrackEM GetByProducer(ProducerEM producer);
    }
}