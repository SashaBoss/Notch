namespace Notch.Bootstrap
{
    using AutoMapper;
    using Notch.Data.Dapper.Entity;
    using Notch.Domain;

    /// <summary>
    /// Application mappings.
    /// </summary>
    public static class ApplicationMapper
    {
        public static void Init()
        {
            Mapper.Initialize((mapper) =>
            {
                mapper.CreateMap<TrackEM, Track>()
                      .ReverseMap();

                mapper.CreateMap<ProducerEM, Product>()
                      .ReverseMap();
            });
        }
    }
}