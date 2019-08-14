using APIStreamFriends.domain.domain.Interfaces;
using APIStreamFriends.domain.domain.Models;
using APIStreamFriends.infra.Data.MSSQL.Context;

namespace APIStreamFriends.infra.Data.MSSQL.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>,
        IClienteRepository
    {
        private MSContext ctx;
        public ClienteRepository(MSContext ctx) : base(ctx)
        {
            this.ctx = ctx;
        }
    }
}
