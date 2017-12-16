using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Notch.Data.EntityFramework.Entity;
using Notch.Infrastructure.Data;

namespace Notch.Data.EntityFramework
{
    public class TrackEntityFrameworkRepository: IEFRepository<TrackEFEntity>
    {
        private readonly NotchContext _notchContext = new NotchContext();
        public IQueryable<TrackEFEntity> GetAll()
        {
            return _notchContext.TrackEFEntity;
        }

        public IQueryable<TrackEFEntity> FindBy(Expression<Func<TrackEFEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Add(TrackEFEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TrackEFEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(TrackEFEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
