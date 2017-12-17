namespace Notch.Data.EntityFramework
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using Notch.Data.EntityFramework.Entity;

    public class TrackEntityFrameworkRepository: IEFRepository<Track>
    {
        private readonly NotchContext _notchContext = new NotchContext();

        public IQueryable<Track> GetAll()
        {
            return _notchContext.Track;
        }

        public IQueryable<Track> FindBy(Expression<Func<Track, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Add(Track entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Track entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(Track entity)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
