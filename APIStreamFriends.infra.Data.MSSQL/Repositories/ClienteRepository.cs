using APIStreamFriends.domain.domain.Interfaces;
using APIStreamFriends.domain.domain.Models;
using APIStreamFriends.infra.Data.MSSQL.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace APIStreamFriends.infra.Data.MSSQL.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>,
        IClienteRepository
    {
        private MSContext ctx;
        public ClienteRepository(MSContext ctx) : base(context)
        {
            this.ctx = ctx;
        }
    }
}
