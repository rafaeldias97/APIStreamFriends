using APIStreamFriends.domain.domain.Interfaces;
using APIStreamFriends.domain.domain.Models;
using APIStreamFriends.infra.Data.MSSQL.Context;

namespace APIStreamFriends.infra.Data.MSSQL.Repositories
{
    public class SeguidorRepository : BaseRepository<Seguidor>,
        ISeguidorRepository
    {
        public SeguidorRepository(MSContext context) : base(context)
        {
        }
    }
}
